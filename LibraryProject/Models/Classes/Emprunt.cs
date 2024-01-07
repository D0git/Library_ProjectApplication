using LibraryProject.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models.Classes
{
    public class Emprunt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("LivreId")]
        public Livre Livre { get; set; }
        public int LivreId { get; set; }

        [ForeignKey("AdherentId")]
        public Adherent Adherent { get; set; }
        public int AdherentId { get; set; }

        private DateTime date_empr;
        private DateTime date_retour;
        public float Montant { get; set; }

        public DateTime Date_empr { get => date_empr; set { date_empr = value; this.Montant = this.CalculeMontant(); } }
        public DateTime Date_retour { get => date_retour; set { date_retour = value; this.Montant = this.CalculeMontant(); } }
        public bool EtatRetour { get; set; }

        public float CalculeMontant()
        {
            int joursEmprunt = (int)(date_retour - date_empr).TotalDays;
            float m;
            m = Livre.Prix * joursEmprunt;
            return m;
        }

        public Emprunt() { }

        public Emprunt(Livre livre, Adherent adherent, DateTime date_empr, DateTime date_retour)
        {
            this.Livre = livre; this.Adherent = adherent;
            this.date_empr = date_empr;
            this.date_retour = date_retour;
            this.Montant = this.CalculeMontant();
        }

    }
}
