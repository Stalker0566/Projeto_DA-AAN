using System.Linq;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class UserController
    {
        public dynamic GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .Select(u => new
                    {
                        ID = u.Id, // se o frontend precisar do ID, caso contrário pode ser omitido
                        Nome = u.Username,
                        Senha = u.Password
                    })
                    .ToList();
            }
        }

        public bool Add(string username, string password)
        {
            using (var context = new AppDbContext())
            {
                if (context.Users.Any(u => u.Username == username))
                    return false; 

                context.Users.Add(new User { Username = username, Password = password });
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(int id, string username, string password)
        {
            using (var context = new AppDbContext())
            {
                if (context.Users.Any(u => u.Username == username && u.Id != id))
                    return false; 

                var user = context.Users.Find(id);
                if (user != null)
                {
                    user.Username = username;
                    user.Password = password;
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
                // nao deixamos eliminar o utilizador atual para evitar problemas de sessão
                if (id == SessionManager.CurrentUserId)
                    throw new System.Exception("Não podes eliminar o utilizador atual!");

                var user = context.Users.Find(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}