using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaWaluigi.Models;

namespace PizzeriaWaluigi.Handlers
{
    public class PizzaPersonalizadaHandler : BaseDatosHandler
    {
        ArchivosHandler manejadorDeImagen = new ArchivosHandler();
        public bool InsertarIngrediente(IngredienteModel ingrediente)
        {
            string consultaAgregarIngrediente =
            "INSERT INTO dbo.Noticia(nombrePK, precio, cantidadMaxima, imagen, tipoImagen) " +
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

        public Tuple<byte[], string> ObtenerFoto(string numNoticia)
        {
            string nombreArchivo = "imagen", tipoArchivo = "tipoImagen";
            String Consulta = "SELECT " + nombreArchivo + ", " + tipoArchivo + " FROM Noticia WHERE idNoticiaPK = @id";
            int id = Int32.Parse(numNoticia);
            KeyValuePair<string, object> valoresParametros = new KeyValuePair<string, object>("@id", id);
            return ObtenerArchivo(Consulta, valoresParametros, nombreArchivo, tipoArchivo);
        }
    }
}