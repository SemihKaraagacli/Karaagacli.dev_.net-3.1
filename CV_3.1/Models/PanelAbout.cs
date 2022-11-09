using System.ComponentModel.DataAnnotations;

namespace CV_3._1.Models
{
    public class PanelAbout
    {
        [Key]
        public int Id { get; set; }
        public string? Tanıtım { get; set; }
        public string? NelerYapıyorumAd { get; set; }
        public string? NelerYapıyorumIcerik { get; set; }
    }
}
