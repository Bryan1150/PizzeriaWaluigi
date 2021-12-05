using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaWaluigi.Models
{
    public class TarjetaModel
    {
        [Display(Name = "Numero de tarjeta")]
        [Required(ErrorMessage = "Es necesario que ingrese un número")]
        [MaxLength(16, ErrorMessage = "Debe ingresar 16 dígitos")]
        [MinLength(16, ErrorMessage = "Debe ingresar 16 dígitos")]
        public string NumeroTarjeta { get; set; }

        [Display(Name = "Nombre del titular")]
        [Required(ErrorMessage = "Es necesario que ingrese un nombre")]
        public string NombreTarjeta { get; set; }

        [Display(Name = "Fecha de expiracion")]
        [Required(ErrorMessage = "Es necesario que ingrese una fecha")]
        [MaxLength(6, ErrorMessage = "Máximo de 4 cáracteres")]
        [MinLength(4, ErrorMessage = "Minimo de 4 cáracteres")]
        public string FechaExpiracion { get; set; }

        [Display(Name = "Codigo de seguridad")]
        [Required(ErrorMessage = "Es necesario que ingrese un CVV")]
        [MaxLength(4, ErrorMessage = "Máximo de 4 cáracteres")]
        [MinLength(3, ErrorMessage = "Minimo de 4 cáracteres")]
        public string CVV { get; set; }
    }
}