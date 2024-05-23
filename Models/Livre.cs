using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryClient.Models
{
    public class Livre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titre { get; set; }
        public DateTime DateParution { get; set; }
        public string Description { get; set; }
        public int NbrExempl { get; set; }
        public int NbrEmpr { get; set; }
        public string Image { get; set; }
        public string ImageWeb { get; set; }
        public float Prix { get; set; }


        [ForeignKey("AuteurId")]
        public Auteur Auteur { get; set; }
        public int AuteurId { get; set; }


        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        public Livre() { }

        public Livre(string titre, Auteur auteur, Genre genre, DateTime dateParution, string description, int nbrExempl, int n, string image, string imageWeb, float prix)
        {

            this.Titre = titre;
            this.Auteur = auteur;
            this.Genre = genre;
            this.DateParution = dateParution;
            this.Description = description;
            this.NbrExempl = nbrExempl;
            this.NbrEmpr = n;
            this.Image = image;
            this.ImageWeb = imageWeb;
            this.Prix = prix;
        }

        public void Editer_livre(string titre, Auteur auteur, Genre genre, DateTime dateParution, string description, int nbrExempl, int nbrEmpr, string image, string imageWeb, float prix)
        {
            this.Titre = titre;
            this.Auteur = auteur;
            this.Genre = genre;
            this.DateParution = dateParution;
            this.Description = description;
            this.NbrExempl = nbrExempl;
            this.NbrEmpr = nbrEmpr;
            this.Image = image;
            this.ImageWeb = imageWeb;
            this.Prix = prix;


        }
    }
}
