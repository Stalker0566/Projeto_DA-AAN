using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_DA
{
    public class SessionManager
    {
        // guarda o ID do user
        public static int CurrentUserId { get; set; }

        // guarda o nome do user
        public static string CurrentUsername { get; set; }

        public static void ClearSession()
        {
            CurrentUserId = 0;
            CurrentUsername = string.Empty;
        }
    }
}
