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

        public string genreComplet
        {
            get
            {
                return this.genre == "H" ? "Homme" : "Femme";
            }
        }

        public string nomPrenom
        {
            get
            {
                return this.nom + " " + this.prenom;
            }
            
        }

        public string nomPrenomConjoint { get; set; }
        public string nomPrenomParent { get; set; }


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