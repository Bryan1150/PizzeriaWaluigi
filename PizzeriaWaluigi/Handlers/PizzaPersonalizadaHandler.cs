using System;
using System.Collections.Generic;
using System.Data;
using PizzeriaWaluigi.Models;

namespace PizzeriaWaluigi.Handlers
{
    public class PizzaPersonalizadaHandler : BaseDatosHandler
    {
        ArchivosHandler manejadorDeImagen = new ArchivosHandler();

        private List<IngredienteModel> ObtenerIngrediente(string consulta)
        {
            DataTable tabla = LeerBaseDeDatos(consulta);
            List<IngredienteModel> lista = ConvertirTablaALista(tabla);
            return lista;
        }
        public List<IngredienteModel> ObtenerTodosLosIngredientes()
        {
            string consulta = "SELECT * FROM Pizerria.dbo.Ingredientes";
            return (ObtenerIngrediente(consulta));
        }
        public bool InsertarIngrediente(IngredienteModel ingrediente)
        {
            string consultaAgregarIngrediente =
            "INSERT INTO Pizerria.dbo.Ingredientes(nombrePK, precio, cantidadMaxima, imagen, tipoImagen) " +
            "VALUES(@nombre, @precio, @cantidadMaxima, @imagen, @tipoImagen);";
            Dictionary<string, object> parametrosIngrediente = new Dictionary<string, object>
            {
                {"@nombre", ingrediente.Nombre},
                {"@precio", ingrediente.Precio },
                {"@cantidadMaxima", ingrediente.CantidadMaxima },
                {"@tipoImagen", ingrediente.Imagen.ContentType }        
            };
            parametrosIngrediente.Add("@imagen", manejadorDeImagen.ConvertirArchivoABytes(ingrediente.Imagen));
            return (InsertarEnBaseDatos(consultaAgregarIngrediente, parametrosIngrediente));
        }

        public Tuple<byte[], string> ObtenerFoto(string nombreIngrediente)
        {
            string nombreArchivo = "imagen", tipoArchivo = "tipoImagen";
            String Consulta = "SELECT " + nombreArchivo + ", " + tipoArchivo + " FROM Pizerria.dbo.Ingredientes WHERE nombrePK = @nombre";
            KeyValuePair<string, object> valoresParametros = new KeyValuePair<string, object>("@nombre", nombreIngrediente);
            return ObtenerArchivo(Consulta, valoresParametros, nombreArchivo, tipoArchivo);
        }
        private List<IngredienteModel> ConvertirTablaALista(DataTable tabla)
        {
            List<IngredienteModel> ingredientes = new List<IngredienteModel>();
            foreach (DataRow columna in tabla.Rows)
                ingredientes.Add(
                new IngredienteModel
                {
                    Nombre = Convert.ToString(columna["nombrePK"]),
                    Precio = Convert.ToDouble(columna["precio"]),
                    CantidadMaxima = Convert.ToInt32(columna["cantidadMaxima"]),                
                });
            return ingredientes;
        }
    }
}