using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PadraoAspNetCoreMVC.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<Station> Stations { get; set; }
    }
}