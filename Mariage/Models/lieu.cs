//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mariage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class lieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lieu()
        {
            this.etape = new HashSet<etape>();
            this.hebergement = new HashSet<hebergement>();
        }
    
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public string coordonneesMaps { get; set; }
        public string rue { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string urlPhoto { get; set; }
        public string siteWeb { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<etape> etape { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hebergement> hebergement { get; set; }
    }
}
