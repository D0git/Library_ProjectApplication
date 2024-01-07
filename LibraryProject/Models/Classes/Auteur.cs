using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models.Classes
{
    public class Auteur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Image { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateDeces  { get; set; }
        public string Biographie { get; set; }

        public Auteur()
        {
        }

        public Auteur(string nom, string prenom, string image, DateTime dateNaissance, DateTime dateDeces, string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            Image = image;
            DateNaissance = dateNaissance;
            DateDeces = dateDeces;
            Biographie = biographie;
        }
        public Auteur(string nom, string prenom, string image, DateTime dateNaissance,  string biographie)
        {
            Nom = nom;
            Prenom = prenom;
            Image = image;
            DateNaissance = dateNaissance;
   
            Biographie = biographie;
        }
    }
}
