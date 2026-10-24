using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DragonBallBatallasMvc.Models
{
    public class Batalla
    {
        [Key]
        public int BatallaId { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Enemigo { get; set; }

        public string Resultado { get; set; }

        // Clave foránea hacia Guerrero
        public int GuerreroId { get; set; }

        // Propiedad de navegación
        public virtual Guerrero Guerrero { get; set; }
    }
}