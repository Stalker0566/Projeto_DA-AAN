using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class AuthController
    {
        public bool Login(string username, string password)
        {
            using (var context = new AppDbContext())
            {
                // Busca o utilizador pelo username
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    // Verifica a senha utilizando o PasswordHasher (com suporte a fallback)
                    if (PasswordHasher.VerifyPassword(password, user.Password))
                    {
                        // Se a password estava guardada em texto limpo, fazemos o upgrade automático para hash!
                        if (!user.Password.Contains(':'))
                        {
                            try
                            {
                                user.Password = PasswordHasher.HashPassword(password);
                                context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                // Log do erro ou ignorar para não bloquear o login se falhar a escrita
                                Console.WriteLine($"Erro ao fazer upgrade da palavra-passe: {ex.Message}");
                            }
                        }

                        // guarda o ID e o nome do utilizador na sessão
                        SessionManager.CurrentUserId = user.Id;
                        SessionManager.CurrentUsername = user.Username;
                        return true;
                    }
                }
                return false; // login falhou
            }
        }
    }
}
