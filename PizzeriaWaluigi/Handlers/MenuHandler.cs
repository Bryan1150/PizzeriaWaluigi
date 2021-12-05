using System;
using System.Collections.Generic;
using System.Data;
using PizzeriaWaluigi.Models;

namespace PizzeriaWaluigi.Handlers
{
    public class MenuHandler : BaseDatosHandler
    {
        ArchivosHandler manejadorDeImagen = new ArchivosHandler();

        private List<ProductoModel> ObtenerProducto(string consulta)
        {
            DataTable tabla = LeerBaseDeDatos(consulta);
            List<ProductoModel> lista = ConvertirTablaALista(tabla);
            return lista;
        }
        public List<ProductoModel> ObtenerTodosLosProductos()
        {
            string consulta = "SELECT * FROM Pizerria.dbo.Productos";
            return (ObtenerProducto(consulta));
        }
        public ProductoModel VerProducto(int IdProducto)
        {
            string consulta = "SELECT * FROM Pizerria.dbo.Productos WHERE IdProducto = '" + IdProducto + "';";
            return (ObtenerProducto(consulta)[0]);
        }
        public bool InsertarProducto(ProductoModel producto)
        {
            string consultaAgregarProducto =
            "INSERT INTO Pizerria.dbo.Productos(nombre, descripcion, precio, imagen, categoria, tipoImagen) " +
            "VALUES(@nombre, @descripcion, @precio, @imagen, @categoria, @tipoImagen);";
            Dictionary<string, object> parametrosProducto = new Dictionary<string, object>
            {
                {"@nombre", producto.Nombre},
                {"@precio", producto.Precio },
                {"@descripcion", producto.Descripcion},
                {"@categoria", producto.Categoria},
                {"@tipoImagen", producto.Imagen.ContentType }
            };
            parametrosProducto.Add("@imagen", manejadorDeImagen.ConvertirArchivoABytes(producto.Imagen));
            return (InsertarEnBaseDatos(consultaAgregarProducto, parametrosProducto));
        }

        public Tuple<byte[], string> ObtenerFoto(int idProducto)
        {
            string nombreArchivo = "imagen", tipoArchivo = "tipoImagen";
            String Consulta = "SELECT " + nombreArchivo + ", " + tipoArchivo + " FROM Pizerria.dbo.Productos WHERE IdProducto = @id";
            KeyValuePair<string, object> valoresParametros = new KeyValuePair<string, object>("@id", idProducto);
            return ObtenerArchivo(Consulta, valoresParametros, nombreArchivo, tipoArchivo);
        }
        private List<ProductoModel> ConvertirTablaALista(DataTable tabla)
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            foreach (DataRow columna in tabla.Rows)
                productos.Add(
                new ProductoModel
                {
                    Id = Convert.ToInt32(columna["IdProducto"]),
                    Nombre = Convert.ToString(columna["nombre"]),
                    Precio = Convert.ToDouble(columna["precio"]),
                    Descripcion = Convert.ToString(columna["descripcion"]),
                    Categoria = Convert.ToString(columna["categoria"])
                });
            return productos;
        }
    }
}