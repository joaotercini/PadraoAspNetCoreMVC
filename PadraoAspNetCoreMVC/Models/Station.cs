using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoAspNetCoreMVC.Models
{
    public class Station
    {
        public int StationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public IEnumerable<Rainfall> Rainfalls { get; set; }
    }
}
