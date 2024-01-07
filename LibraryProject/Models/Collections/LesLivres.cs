
using LibraryProject.DAO;
using LibraryProject.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models.Collections
{
    internal class LesLivres
    {
        private readonly LibraryContext context;

        public LesLivres(LibraryContext context)
        {
            this.context = context;
        }

        public bool Ajouter_lv(string titre, Auteur auteur, Genre genre, DateTime dateParution, string description, int nbrExempl, string image, float prix)
        {
            var exist = context.Livres.Any(l => l.Titre == titre && l.AuteurId == auteur.Id);
            if (!exist)
            {
                Livre livre = new Livre(titre, auteur, genre, dateParution, description, nbrExempl, image, prix);
                context.Livres.Add(livre);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Remove(int id)
        {
            var livre = from l in context.Livres
                        where l.Id == id
                        select l;
            var empr = from e in context.Emprunts
                       where e.LivreId == id
                       select e;
            foreach (var e in empr.ToList())
            {
                context.Emprunts.Remove((Emprunt)e);
            }
            var panier = from p in context.Panier
                         where p.LivreId == id
                         select p;
            foreach (var p in panier.ToList())
            {
                context.Panier.Remove((Panier)p);
            }

            context.Livres.Remove((Livre)livre);
            context.SaveChanges();
        }

        public HashSet<Livre> RechercheLivre(string search)
        {
            var livres = context.Livres.Where(l => l.Titre.ToLower().Contains(search.ToLower()) ||
                                                   l.Auteur.Nom.ToLower().Contains(search.ToLower()) ||
                                                   l.Auteur.Prenom.ToLower().Contains(search.ToLower()) ||
                                                   l.Genre.ToString().ToLower().Contains(search.ToLower())).ToHashSet();
            return livres;
        }

        public HashSet<Livre> GetLivres()
        {

            return context.Livres.ToHashSet();
        }
        public Livre GetUnLivre(int id)
        {
            Livre livre = context.Livres.FirstOrDefault(l => l.Id == id);
            return livre;
        }
    }
}

