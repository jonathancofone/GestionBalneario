using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BalnearioGestion.Models
{
    public class Gastos
    {
        [Key]
        public int IdGastos { get; set; }

        [Required]
        [Display(Name = "Fecha Gestion")]
        [DataType(DataType.Date)]
        public DateTime FechaGestion { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Valor")]

        public int Valor { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Observacion")]

        public string Observacion { get; set; }

    }
}
