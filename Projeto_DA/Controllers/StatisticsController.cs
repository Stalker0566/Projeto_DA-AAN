using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using System;
using System.Linq;

namespace Projeto_DA.Controllers
{
    public class StatisticsController
    {
        public dynamic GetDashboardData()
        {
            using (var context = new AppDbContext())
            {
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;

                // 1. todos os users
                int totalUsers = context.Users.Count();

                // 2. budget 
                var budget = context.Budgets.FirstOrDefault(b => b.Month == currentMonth && b.Year == currentYear);
                decimal budgetAmount = budget != null ? budget.Amount : 0;

                // 3. quanto foi gasto este mês
                decimal totalSpentThisMonth = context.PurchaseItems
                    .Where(pi => pi.Purchase.CreatedDate.Month == currentMonth && pi.Purchase.CreatedDate.Year == currentYear)
                    .Sum(pi => pi.BoughtQuantity * pi.UnitPrice); // Se PurchaseItem tiver um campo UnitPrice, caso contrário, ajuste conforme necessário

                return new
                {
                    TotalUsers = totalUsers,
                    BudgetAmount = budgetAmount,
                    TotalSpent = totalSpentThisMonth,
                    RemainingBudget = budgetAmount - totalSpentThisMonth
                };
            }
        }
        public dynamic GetDecisionSupport()
        {
            using (var context = new AppDbContext())
            {
                // 1. Считаем средний бюджет за все прошлые месяцы
                decimal suggestedBudget = 0;
                if (context.Budgets.Any())
                {
                    suggestedBudget = context.Budgets.Average(b => b.Amount);
                }

                // 2. Вычисляем текущую неделю месяца (от 1 до 4)
                int currentDay = DateTime.Now.Day;
                int currentWeek = (currentDay - 1) / 7 + 1;
                if (currentWeek > 4) currentWeek = 4; // Всё, что после 28 числа - считаем 4-й неделей

                // 3. Вытаскиваем все закрытые покупки, чтобы найти, что покупали в эту же неделю
                var pastItems = context.PurchaseItems
                    .Include(pi => pi.Purchase)
                    .Include(pi => pi.Article)
                    .Where(pi => pi.Purchase.IsClosed)
                    .ToList(); // Выгружаем в память для сложной сортировки

                // 4. Формируем "Умный список покупок"
                var suggestedList = pastItems
                    .Where(pi => {
                        // Определяем, в какую неделю покупался каждый товар в прошлом
                        int itemWeek = (pi.Purchase.CreatedDate.Day - 1) / 7 + 1;
                        if (itemWeek > 4) itemWeek = 4;
                        return itemWeek == currentWeek; // Оставляем только те, что совпадают с текущей неделей
                    })
                    .GroupBy(pi => pi.Article.Name) // Группируем одинаковые товары
                    .Select(g => new {
                        Artigo = g.Key,
                        VezesComprado = g.Count(), // Сколько раз вообще это покупали
                        QtdSugerida = Math.Round(g.Average(pi => pi.BoughtQuantity), 2) // Какую порцию обычно берут
                    })
                    .OrderByDescending(x => x.VezesComprado) // Самые популярные ставим на самый верх
                    .Take(10) // Берем топ-10 советов, чтобы не перегружать экран
                    .ToList();

                return new
                {
                    SuggestedBudget = suggestedBudget,
                    CurrentWeek = currentWeek,
                    SuggestedList = suggestedList
                };
            }
        }
    }
}