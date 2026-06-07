using System;
using System.Linq;
using System.Windows.Forms;
using Projeto_DA.Data;
using Projeto_DA.Models;
using Projeto_DA.Views;

namespace Projeto_DA
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // teste admin
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated(); // cria a BD automaticamente em novos dispositivos

                // verifica se já existe um usuário admin, se não existir, cria um
                if (!context.Users.Any())
                {
                    context.Users.Add(new User { Username = "admin", Password = PasswordHasher.HashPassword("123") });
                    context.SaveChanges(); // Сохраняем в базу!
                }
            }
            // ----------------------------------------

            // abrimos o formulário de login
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // se o login for bem-sucedido, abrimos o formula   rio principal
                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}