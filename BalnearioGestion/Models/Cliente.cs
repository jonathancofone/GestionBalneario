using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BalnearioGestion.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        
        [Required]
        [Display(Name = "Dni/Cuit")]
        public int Dni { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre y Apellido")]
        public string Nombre { get; set; }

        [MaxLength(15)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [MaxLength(100)]
        [Display(Name = "Mail")]
        public string Mail { get; set; }
    }
}
