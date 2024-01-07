
using LibraryProject.Models.Classes;
using LibraryProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models.Collections
{
    internal class LesPaniers
    {
        private readonly LibraryContext context;

        public LesPaniers(LibraryContext context)
        {
            this.context = context;
        }


        public bool AddPanier(Livre livre, Adherent adherent)
        {
            if (context.Panier.Any(p => p.Livre == livre && p.AdherentId == adherent.Id) || livre.NbrExempl == livre.NbrEmpr) return false;
            Panier panier = new Panier(livre, adherent);
            context.Panier.Add(panier);
            context.SaveChanges();
            return true;
        }


        public HashSet<Panier> ListPanier(int idAdherent)
        {

            var p = from panier in context.Panier
                    join ad in context.Adherents
                    on panier.Id equals ad.Id
                    where ad.Id == idAdherent
                    select panier;
            return p.ToHashSet();
        }

        public void Remove(int id)
        {
            var panier = from p in context.Panier
                         where p.Id == id
                         select p;
            context.Panier.Remove((Panier)panier);
            context.SaveChanges();
        }
    }
}
