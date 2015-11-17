using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mariage.Models
{
    [MetadataType(typeof(LieuMetadata))]
    public partial class lieu
    {
    }

    public class LieuMetadata
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Obligatoire")]
        public string titre { get; set; }
        public string description { get; set; }
        [Display(Name = "coordonnées maps")]
        public string coordonneesMaps { get; set; }
        [Required(ErrorMessage = "Obligatoire")]
        public string rue { get; set; }
        [Required(ErrorMessage = "Obligatoire")]
        [Display(Name = "code postal")]
        public string code_postal { get; set; }
        [Required(ErrorMessage = "Obligatoire")]
        public string ville { get; set; }
        [Required(ErrorMessage = "Obligatoire")]
        public string pays { get; set; }
        public string telephone { get; set; }
        public string urlPhoto { get; set; }
        public string siteWeb { get; set; }
    }
}