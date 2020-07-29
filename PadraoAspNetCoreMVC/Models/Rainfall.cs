using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoAspNetCoreMVC.Models
{
    public class Rainfall
    {
        public int StationId { get; set; }        
        public Station Station { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
