using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mariage.Models
{

    [MetadataType(typeof(EtapeMetadata))]
    public partial class etape
    {
    }

    public class EtapeMetadata
    {
        [Required(ErrorMessage = "Obligatoire")]
        [DataType(DataType.DateTime)]
        public System.DateTime debut { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> fin { get; set; }
    }
}