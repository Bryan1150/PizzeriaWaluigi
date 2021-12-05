using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace PizzeriaWaluigi.Models
{
    public class FacturaModel
    {
        [Display(Name = "IdFactura")]
        public string Id { get; set; }

        [Display(Name = "Productos")]
        public IList<ProductoModel> Productos{ get; set; }

        [Display(Name = "Direccion Exacta")]
        [Required(ErrorMessage = "Es necesario que ingrese una direccion.")]
        public string Direccion { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Es necesario que ingrese una provincia.")]
        public string Provincia { get; set; }

        [Display(Name = "Canton")]
        [Required(ErrorMessage = "Es necesario que ingrese una provincia.")]
        public string Canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Es necesario que ingrese un distrito.")]
        public string Distrito { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Es necesario que ingrese un telefono.")]
        public string Telefono { get; set; }

        [Display(Name = "Referencia")]
        [Required(ErrorMessage = "Es necesario que ingrese una referencia.")]
        public string Referencia { get; set; }
    }
}