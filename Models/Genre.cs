using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryClient.Models
{
    public enum Genre
    {
        [Display(Name = "Roman")]
        Roman,
        [Display(Name = "Science Fiction")]
        ScienceFiction,
        [Display(Name = "Policier")]
        Policier,
        [Display(Name = "Fantastique")]
        Fantastique,
        [Display(Name = "Historique")]
        Historique,
        [Display(Name = "Biographie")]
        Biographie,
        [Display(Name = "Jeunesse")]
        Jeunesse,
        [Display(Name = "Poésie")]
        Poésie,
        [Display(Name = "Thriller")]
        Thriller,
        [Display(Name = "Drame")]
        Drame,
        [Display(Name = "Tragédie")]
        Tragedie,
        [Display(Name = "Tragédie Romantique")]
        TragedieRomantique,
        [Display(Name = "Tragédie Historique")]
        TragedieHistorique
    }
}
