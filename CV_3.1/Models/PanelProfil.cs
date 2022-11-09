using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CV_3._1.Models
{
    public class PanelProfil
    {
        [Key]
        public int Id { get; set; }

        public string? ProfilResmi { get; set; }
        public string? MeslekAlanı { get; set; }
        public string? Mail { get; set; }
        public string? Konum { get; set; }
        public string? KonumAdresi { get; set; }
        public string? Github { get; set; }
        public string? Linkedin { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }

        [NotMapped]
        public IFormFile ProfilDosya { get; set; }
    }
}
