using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace fyp.Models
{
    public class Corporation
    {
        [Key]

        public int CorporationId { get; set; }

        public string CorporationName { get; set; }

        public string Location { get; set; }
    }
}
