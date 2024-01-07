using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models.Classes
{
    public enum Status
    {
        [Display(Name = "Bibliothécaire")]
        Bibliothécaire,

        [Display(Name = "Assistant de bibliothèque")]
        AssistantDeBibliothèque,

        [Display(Name = "Responsable des acquisitions")]
        ResponsableDesAcquisitions,

        [Display(Name = "Catalogueur")]
        Catalogueur,

        [Display(Name = "Référent bibliographique")]
        RéférentBibliographique,

        [Display(Name = "Responsable des programmes et animations")]
        ResponsableDesProgrammesEtAnimations,

        [Display(Name = "Technicien informatique")]
        TechnicienInformatique,

        [Display(Name = "Responsable des archives")]
        ResponsableDesArchives,

        [Display(Name = "Responsable de la gestion des périodiques")]
        ResponsableGestionPériodiques,

        [Display(Name = "Bibliothécaire scolaire")]
        BibliothécaireScolaire
    }
}
