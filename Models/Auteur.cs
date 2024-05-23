using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryClient.Models
{
    public class Auteur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string ImageWeb { get; set; }
        public string Image { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateDeces { get; set; }
        public string Biographie { get; set; }

        public Auteur()
        {
        }

        public Auteur(string nom, string prenom, string imageWeb, string imageDesk, DateTime dateNaissance, DateTime dateDeces, string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            ImageWeb = imageWeb;
            Image = imageDesk;
            DateNaissance = dateNaissance;
            DateDeces = dateDeces;
            Biographie = biographie;
        }

        public void Edit(string nom, string prenom, string imageWeb, string imageDesk, DateTime dateNaissance, DateTime dateDeces, string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            Image = imageDesk;
            ImageWeb = imageWeb;
            DateNaissance = dateNaissance;
            DateDeces = dateDeces;
            Biographie = biographie;
        }

    }
}
