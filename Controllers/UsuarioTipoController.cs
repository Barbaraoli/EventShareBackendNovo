using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class UsuarioTipoController : ControllerBase
    {
        EventShareContext context = new EventShareContext();
        UsuarioTipoRepositorio repositorio = new UsuarioTipoRepositorio();

        /// <summary>
        /// Método para listar os tipos de usuário
        /// </summary>
        /// <returns>Retorna lista de tipos usuarios</returns>
        [EnableCors]
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioTipoTbl>>> Get() 
        {
            try {
                return await repositorio.Get();
            } catch (System.Exception) {
                throw;
            }
        }

        /// <summary>
        /// Método para buscar o tipo de usuário pelo ID
        /// </summary>
        /// <returns>Retorna o tipo de usuário</returns>
        ///<param name="id"></param>
        [EnableCors]
        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioTipoTbl>> Get(int id) 
        {
            try
            {
                return await repositorio.Get(id);
            }catch(System.Exception)
            {
                throw;
            }
        }

    }
}