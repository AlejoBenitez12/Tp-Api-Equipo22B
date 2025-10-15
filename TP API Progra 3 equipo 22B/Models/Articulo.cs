using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_API_Progra_3_equipo_22B.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; } 
        public Categoria Categoria { get; set; } 
        public decimal Precio { get; set; }
        public List<string> Imagenes { get; set; } 
        public Articulo()
        {
            Imagenes = new List<string>();
        }
    }
}