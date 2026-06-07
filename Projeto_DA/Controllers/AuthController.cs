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
                // verifica se o utilizador existe na base de dados
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // guarda o ID e o nome do utilizador na sessão
                    SessionManager.CurrentUserId = user.Id;
                    SessionManager.CurrentUsername = user.Username;
                    return true;
                }
                return false; // login falhou
            }
        }
    }
}
