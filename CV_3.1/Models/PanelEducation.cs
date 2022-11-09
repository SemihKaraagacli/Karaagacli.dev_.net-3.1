using System.ComponentModel.DataAnnotations;

namespace CV_3._1.Models
{
    public class PanelEducation
    {
        [Key]
        public int Id { get; set; }
        public string? OkulAd { get; set; }
        public string? OkulYıl { get; set; }
        public string? OkulAlan { get; set; }
        public string? OkulIcerik { get; set; }
    }
}
