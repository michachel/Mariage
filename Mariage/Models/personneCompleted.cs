using System;
using System.ComponentModel.DataAnnotations;

namespace Mariage.Models
{

    [MetadataType(typeof(PersonneMetadata))]
    public partial class personne
    {

        public bool Valide {
            get
            {
                return Convert.ToBoolean(this.validation);
            }
        }

        public string getNomPrenom()
        {
            return this.nom + " " + this.prenom;
        }

    }

    public class PersonneMetadata
    {

        [Required(ErrorMessage = "Obligatoire")]
        public string nom { get; set; }
        [Required(ErrorMessage = "Obligatoire")]
        public string prenom { get; set; }

        [Display(Name = "Parent")]
        public Nullable<int> idParent { get; set; }

        [Display(Name = "Conjoint")]
        public Nullable<int> idConjoint { get; set; }
        
    }
}