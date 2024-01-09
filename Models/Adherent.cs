using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;

namespace LibraryClient.Models
{
    public class Adherent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public Adherent() { }

        public Adherent(string nom, string prenom, string adresse, string email, string phone, DateTime dateNaissance, string login, string password)
        {
            
            this.Nom = nom;
            this.Prenom = prenom;
            this.Adresse = adresse;
            this.Email = email;
            this.Phone = phone;
            this.DateNaissance = dateNaissance;
            this.Login = login;
            this.Password = password;
        }

        


        public bool Connexion(string login, string password)
        {
            return this.Login.Equals(login) && this.Password.Equals(password);
        }


    }
}
