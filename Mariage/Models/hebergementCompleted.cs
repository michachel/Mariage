using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mariage.Models
{
    [MetadataType(typeof(HebergementMetadata))]
    public partial class hebergement
    {

        public string offertComplet
        {
            get
            {
                return this.estOffert == 0 ? "non" : "oui";
            }
        }

        public string prixComplet
        {
            get
            {
                return this.prix.ToString("C", System.Globalization.CultureInfo.CurrentCulture);
            }
        }
    }

    public class HebergementMetadata
    {

        [Required(ErrorMessage = "Obligatoire")]
        [Display(Name = "Lieu")]
        public int idLieu { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        public int prix { get; set; }

        [Display(Name = "offert")]
        public sbyte estOffert { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        [Display(Name = "début offre")]
        public Nullable<System.DateTime> debutOffert { get; set; }

        [Display(Name = "fin offre")]
        public Nullable<System.DateTime> finOffert { get; set; }

    }
}