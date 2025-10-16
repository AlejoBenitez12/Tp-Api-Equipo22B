using System;
using System.Collections.Generic;
using System.Web.Http;
using TP_API_Progra_3_equipo_22B.Models;
using TP_API_Progra_3_equipo_22B.Negocio;

namespace TP_API_Progra_3_equipo_22B.Controllers
{
    [RoutePrefix("api/articulos")]
    public class ArticulosController : ApiController
    {
        // GET: api/articulos
        [HttpGet]
        [Route("")]
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

        // GET: api/articulos/5
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articulo = negocio.BuscarPorId(id);
                if (articulo == null)
                {
                    return NotFound();
                }
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/articulos
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] ArticuloDTO nuevoArticulo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Agregar(nuevoArticulo);
                return Ok("Artículo agregado exitosamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/articulos/5
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] ArticuloDTO articuloModificado)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Modificar(articuloModificado, id);
                return Ok("Artículo modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/articulos/5
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                var articulo = negocio.BuscarPorId(id);
                if (articulo == null)
                {
                    return NotFound();
                }
                negocio.Eliminar(id);
                return Ok("Artículo eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/articulos/1/imagenes
        [HttpPost]
        [Route("{idArticulo}/imagenes")]
        public IHttpActionResult AgregarImagenes(int idArticulo, [FromBody] List<string> urls)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                var articulo = negocio.BuscarPorId(idArticulo);
                if (articulo == null)
                {
                    return NotFound();
                }
                negocio.AgregarImagenes(idArticulo, urls);
                return Ok("Imágenes agregadas exitosamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}