using System.ComponentModel.DataAnnotations;

namespace fyp.Models
{
    public class CorporationModel
    {
        [Key]
        public int CorporationId { get; set; }
        public string CorporationName { get; set; }
        public string CorporationDescription { get; set; }

        public string CorporationLocation { get; set; }

        [DataType(DataType.Url)]
        public string CorporationUrl { get; set; }



    }
}
