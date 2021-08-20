using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BalnearioGestion.Models
{
    public class ServicioBalneario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Fecha Gestion")]
        [DataType(DataType.Date)]
        public DateTime FechaGestion { get; set; }

        [Required]
        [Display(Name ="Fecha Desde")]
        [DataType(DataType.Date)]
        public DateTime FechaDesde { get; set; }

        [Required]
        [Display(Name = "Fecha Hasta")]
        [DataType(DataType.Date)]
        
        public DateTime FechaHasta { get; set; }
        
        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }


        [Required]
        [Display(Name ="Carpa")]
        
        public bool AlquilaCarpa { get; set; }


        [Required]
        [Display(Name = "Sombrilla")]
        public bool AlquilaSombrilla { get; set; }

        [Required]
        [Range(1,100)]
        [Display(Name = "Número")]
        public int IdAlquila { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:C}")]   
        [Display (Name = "Valor")]
        
        public int Valor { get; set; }
        
        [Required]
        [MaxLength(150)]
        [Display(Name = "Forma de Pago")]

        public string FormaDePago { get; set; }

    }
}
