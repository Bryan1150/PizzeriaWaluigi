using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Collections.Generic;

namespace PizzeriaWaluigi.Models
{
    public class PizzaModel
    {
        [Display(Name = "Tamaño")]
        [Required(ErrorMessage = "Es necesario que ingrese un tamaño para la pizza.")]
        public string Nombre { get; set; }

        [Display(Name = "Salsa")]
        [Required(ErrorMessage = "Es necesario que ingrese una salsa para la pizza.")]
        public double Precio { get; set; }

        [Display(Name = "Ingredientes")]
        [Required(ErrorMessage = "Es necesario que ingrese algun ingrediente para la pizza.")]
        public IList<IngredienteModel> Ingredientes { get; set; }
    }
}