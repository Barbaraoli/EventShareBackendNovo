using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspacoController : ControllerBase
    {
      EventShareContext context = new EventShareContext();
      EspacoRepositorio repositorio = new EspacoRepositorio();
        
        /// <summary>
        /// Método para listar os espaços e eventos
        /// </summary>
        /// <returns>Retorna lista de espaços</returns>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet]
       public async Task<ActionResult<List<EventoEspacoTbl>>> Get()
       {
           List<EventoEspacoTbl> listadeEspaco = await repositorio.Get();
           return listadeEspaco;
       }

        /// <summary>
        /// Método para chamar o espaço de eventos pelo ID
        /// </summary>
        /// <returns>Retorna o evento</returns>
        /// <param name="id"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet("{id}")]
       public async Task<ActionResult<EventoEspacoTbl>> Get(int id)
       {
           EventoEspacoTbl EspacoRetornada = await repositorio.Get(id);
           if(EspacoRetornada == null)
           {
               return NotFound("Espaço não encontrado.");
           }

           return EspacoRetornada;
       }
       
        // /// <summary>
        // /// Método para verificar se o espaço está livre
        // /// </summary>
        // /// <returns>Retorna verdadeiro se o espaço está livre, caso contrário retorna falso.</returns>
        // /// <param name="id"></param>
        // [EnableCors]
        // // [Authorize]
        // [HttpGet("info/{id}")]
        // public async Task<ActionResult<bool>> VerificarEspaco(int id){
        //     if(await repositorio.VerificaEspaco(id)){
        //         return Ok(true);
        //     }

        //     return Ok(false);
        // }
    }
}