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
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime DateNaissance { get; set; }

        public Employee()
        {
        }


        public Employee(string nom, string prenom, Status status, string adresse, string email, string phone, string image, DateTime dateNaissance)

        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Email = email;
            Phone = phone;
            Image = image;
            DateNaissance = dateNaissance;
        }
    }
}