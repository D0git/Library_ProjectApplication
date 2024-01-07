
using System;
using LibraryProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models.Classes
{
    public class Panier
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

        public Panier() { }
        public Panier(Livre livre, Adherent adherent)
        {
            Livre = livre;
            Adherent = adherent;

        }



    }
}
