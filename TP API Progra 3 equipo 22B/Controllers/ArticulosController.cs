using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP_API_Progra_3_equipo_22B.Models;
using TP_API_Progra_3_equipo_22B.Negocio;

namespace TP_API_Progra_3_equipo_22B.Controllers
{
    public class ArticulosController : ApiController
    {
        // GET: api/Articulos
        public IHttpActionResult Get()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                List<Articulo> lista = negocio.Listar();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Articulos/5
        public IHttpActionResult Get(int id)
        {
            return Ok("Respuesta temporal: se buscará el artículo con ID: " + id);
        }

        // POST: api/Articulos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Articulos/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Articulos/5
        public void Delete(int id)
        {
        }
    }
}
