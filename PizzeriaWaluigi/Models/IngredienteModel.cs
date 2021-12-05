using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PizzeriaWaluigi.Models
{
    public class IngredienteModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Es necesario que ingrese un nombre para el ingrediente.")]
        public string Nombre { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Es necesario que ingrese un precio para el ingrediente.")]
        public double Precio { get; set; }

        [Display(Name = "Cantidad Maxima")]
        [Required(ErrorMessage = "Es necesario que ingrese una cantidad maxima para el ingrediente.")]
        public int CantidadMaxima { get; set; }

        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Es necesario que ingrese una imagen para el ingrediente.")]
        public HttpPostedFileBase Imagen { get; set; }

        public string TipoArchivoFoto { get; set; }
    }
}