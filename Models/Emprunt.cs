using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryClient.Models
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

        public DateTime Date_empr {  get; set; }
        public DateTime Date_retour { get; set; }
        public float Montant { get; set; }
        public bool EtatRetour { get; set; }

        

        public Emprunt() { }

        public Emprunt(Livre livre, Adherent adherent, DateTime date_empr, DateTime date_retour, float montant, bool etatRetour)
        {
            this.Livre=livre; this.Adherent=adherent;
            this.Date_empr = date_empr;
            this.Date_retour = date_retour;
            this.Montant = montant;
            this.EtatRetour = etatRetour;
        }

    }
}
