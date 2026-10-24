using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DragonBallBatallasMvc.Models
{
    public class Guerrero
    {
        [Key]
        public int GuerreroId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Raza { get; set; }

        public virtual ICollection<Batalla> Batallas { get; set; }
    }
}