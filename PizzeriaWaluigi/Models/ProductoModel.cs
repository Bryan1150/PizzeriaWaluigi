using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Collections.Generic;

namespace PizzeriaWaluigi.Models
{
    public class ProductoModel
    {
        [Display(Name = "IdProducto")]
        public string Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Es necesario que ingrese un nombre para el producto.")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public int Descripcion { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Es necesario que ingrese un precio para el producto.")]
        public double Precio { get; set; }

        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Es necesario que ingrese una imagen para el producto.")]
        public HttpPostedFileBase Imagen { get; set; }

        public string TipoArchivoFoto { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Es necesario que ingrese una categoria para el producto.")]
        public string Categoria { get; set; }

    }
}