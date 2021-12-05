using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Collections.Generic;

namespace PizzeriaWaluigi.Models
{
    public class ComboModel : ProductoModel
    {
        [Display(Name = "TipoPizza")]
        [Required(ErrorMessage = "Es necesario que ingrese una categoria para el producto.")]
        public string TipoPizza { get; set; }

        [Display(Name = "Extras")]
        [Required(ErrorMessage = "Es necesario que ingrese algun extra para la pizza.")]
        public IList<IngredienteModel> Extras { get; set; }
    }
}