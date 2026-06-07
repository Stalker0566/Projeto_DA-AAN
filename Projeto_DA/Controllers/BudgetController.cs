using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class BudgetController
    {
        public dynamic GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Budgets
                    .Include(b => b.CreatedBy)
                    .Include(b => b.ModifiedBy)
                    .Select(b => new
                    {
                        ID = b.ID, 
                        Mês = b.Month,
                        Ano = b.Year,
                        Valor = b.Amount,
                        CriadoPor = b.CreatedBy.Username,
                        AlteradoPor = b.ModifiedBy != null ? b.ModifiedBy.Username : "-"
                    })
                    .ToList();
            }
        }

        public bool Add(int month, int year, decimal amount)
        {
            using (var context = new AppDbContext())
            {
                if (context.Budgets.Any(b => b.Month == month && b.Year == year))
                    return false;

                // --- hack para evitar de ter que criar um método específico para pegar o usuário logado, já que o SessionManager só tem o ID do usuário, e o Budget precisa do objeto inteiro para preencher a relação corretamente
                var currentUser = context.Users.Find(SessionManager.CurrentUserId);

                var budget = new Budget
                {
                    Month = month,
                    Year = year,
                    Amount = amount,
                    CreatedBy = currentUser // damos o objeto inteiro, não só o ID, para que o EF possa preencher a relação corretamente
                };
                context.Budgets.Add(budget);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(int id, int month, int year, decimal amount)
        {
            using (var context = new AppDbContext())
            {
                // se já existe um orçamento para o mesmo mês e ano, mas com ID diferente, retorna false
                if (context.Budgets.Any(b => b.Month == month && b.Year == year && b.ID != id))
                    return false;

                var budget = context.Budgets.Find(id);
                var currentUser = context.Users.Find(SessionManager.CurrentUserId);

                if (budget != null)
                {
                    budget.Month = month;
                    budget.Year = year;
                    budget.Amount = amount;
                    budget.ModifiedBy = currentUser; // recebe o objeto inteiro, não só o ID
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var budget = context.Budgets.Find(id);
                if (budget != null)
                {
                    context.Budgets.Remove(budget);
                    context.SaveChanges();
                }
            }
        }
    }
}