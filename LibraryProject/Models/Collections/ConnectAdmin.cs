using LibraryProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models.Collections
{
    internal class ConnectAdmin
    {
        private readonly LibraryContext context;

        public ConnectAdmin(LibraryContext context)
        {
            this.context = context;
        }

        public bool Connexion(string login, string password)
        {
            return context.Admins.Any(a => a.Login == login && a.Password == password);
        }

    }
}

