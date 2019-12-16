using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StatusController : ControllerBase
    {
        EventShareContext context = new EventShareContext();
        StatusRepositorio repositorio = new StatusRepositorio();

        /// <summary>
        /// Método para listar os status existentes
        /// </summary>
        /// <returns>Retorna lista de status</returns>
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<EventoStatusTbl>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
             catch(System.Exception)
            {
                 throw;
            }
        }

    }
}