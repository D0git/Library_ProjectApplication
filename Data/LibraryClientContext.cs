using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryClient.Models;

namespace LibraryClient.Data
{
    public class LibraryClientContext : DbContext
    {
        public LibraryClientContext (DbContextOptions<LibraryClientContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryClient.Models.Livre> Livres { get; set; } = default!;
        public DbSet<LibraryClient.Models.Auteur> Auteurs { get; set; } = default!;
        public DbSet<LibraryClient.Models.Panier> Paniers { get; set; } = default!;
        public DbSet<LibraryClient.Models.Adherent> Adherents { get; set; } = default!;
        //public LibraryClientContext() { }
    }
}
