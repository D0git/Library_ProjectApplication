using LibraryProject.Models.Classes;
using System;
using LibraryProject.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibraryProject.Data
{
    internal class LibraryContext : DbContext
    {
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Panier> Panier { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }


        public LibraryContext() : base("librarydbo")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }//L’instruction modelBuilder.Conventions.Remove de la méthode OnModelCreating empêche le pluralisation des noms de tables. Si vous ne l’avez pas fait
    }
}
