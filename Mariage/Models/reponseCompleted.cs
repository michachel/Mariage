﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mariage.Models
{
    [MetadataType(typeof(ReponseMetadata))]
    public partial class reponse
    {
    }

    public class ReponseMetadata
    {
        
        [Display(Name = "Liste des participants")]
        public string listeParticipants { get; set; }
        
        [Display(Name = "Mode de transport pendant le mariage")]
        public string modeTransport { get; set; }
        
        [Display(Name = "Mode de transport d'arrivée sur Toulouse")]
        public string arriveeTransport { get; set; }

        [Display(Name = "Date d'arrivée estimée sur Toulouse")]
        public Nullable<System.DateTime> dateArrivee { get; set; }
        
        [Display(Name = "Lieu de couchage du Samedi soir")]
        public string hotelSamediSoir { get; set; }
    }
}