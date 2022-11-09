using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CV_3._1.Models
{
    public class PanelProject
    {
        [Key]
        public int Id { get; set; }
        public string? ProjectAd { get; set; }
        public string? ProjectIcerik { get; set; }
        public string? ProjectResim { get; set; }
        public string? ProjectAdres { get; set; }

        [NotMapped]
        public IFormFile ProjectDosya { get; set; }
    }
}
