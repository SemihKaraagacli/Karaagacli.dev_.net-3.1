using System.ComponentModel.DataAnnotations;

namespace CV_3._1.Models
{
    public class PanelExperiance
    {
        [Key]
        public int Id { get; set; }
        public string? DeneyimAd { get; set; }
        public string? DeneyimYıl { get; set; }
        public string? DeneyimAlan { get; set; }
        public string? DeneyimIcerik { get; set; }
    }
}
