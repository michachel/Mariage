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
    
    public partial class personnes_hebergements
    {
        public int idPersonne { get; set; }
        public int idHebergement { get; set; }
        public System.DateTime debut { get; set; }
        public System.DateTime fin { get; set; }
        public string numeroReservation { get; set; }
    
        public virtual hebergement hebergement { get; set; }
        public virtual personne personne { get; set; }
    }
}