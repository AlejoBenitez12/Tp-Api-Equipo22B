using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP_API_Progra_3_equipo_22B.Models;

namespace TP_API_Progra_3_equipo_22B.Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            var articulosDiccionario = new Dictionary<int, Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true;";

                comando.CommandText = @"
            SELECT 
                A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio,
                M.Id AS IdMarca, M.Descripcion AS DescripcionMarca,
                C.Id AS IdCategoria, C.Descripcion AS DescripcionCategoria,
                I.ImagenUrl
            FROM 
                ARTICULOS A
            LEFT JOIN 
                MARCAS M ON A.IdMarca = M.Id
            LEFT JOIN 
                CATEGORIAS C ON A.IdCategoria = C.Id
            LEFT JOIN
                IMAGENES I ON A.Id = I.IdArticulo
            ORDER BY A.Id";

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int idArticulo = (int)lector["Id"];
                    Articulo articuloActual;

                    if (!articulosDiccionario.ContainsKey(idArticulo))
                    {
                        articuloActual = new Articulo();
                        articuloActual.Id = idArticulo;
                        articuloActual.Codigo = (string)lector["Codigo"];
                        articuloActual.Nombre = (string)lector["Nombre"];
                        articuloActual.Descripcion = (string)lector["Descripcion"];

                        if (lector["Precio"] != DBNull.Value)
                            articuloActual.Precio = (decimal)lector["Precio"];

                        if (lector["IdMarca"] != DBNull.Value)
                        {
                            articuloActual.Marca = new Marca();
                            articuloActual.Marca.Id = (int)lector["IdMarca"];
                            articuloActual.Marca.Descripcion = (string)lector["DescripcionMarca"];
                        }
                        else
                        {
                            articuloActual.Marca = new Marca { Descripcion = "Sin Marca" };
                        }
                        if (lector["IdCategoria"] != DBNull.Value)
                        {
                            articuloActual.Categoria = new Categoria();
                            articuloActual.Categoria.Id = (int)lector["IdCategoria"];
                            articuloActual.Categoria.Descripcion = (string)lector["DescripcionCategoria"];
                        }
                        else
                        {
                            articuloActual.Categoria = new Categoria { Descripcion = "Sin Categoría" };
                        }
                        articulosDiccionario.Add(idArticulo, articuloActual);
                    }
                    else
                    {
                        articuloActual = articulosDiccionario[idArticulo];
                    }

                    if (lector["ImagenUrl"] != DBNull.Value)
                    {
                        articuloActual.Imagenes.Add((string)lector["ImagenUrl"]);
                    }
                }

                lista = new List<Articulo>(articulosDiccionario.Values);

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }
    }
}