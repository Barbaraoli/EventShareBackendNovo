using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class EspacoRepositorio : IEspacoRepositorio
    {
        EventShareContext context = new EventShareContext();

        public async Task<List<EventoEspacoTbl>> Get()
        {
            List<EventoEspacoTbl> listaDeEspaco = await context.EventoEspacoTbl.ToListAsync();

            return listaDeEspaco;
        }

        public async Task<EventoEspacoTbl> Get(int id)
        {
            return await context.EventoEspacoTbl.FindAsync(id);
        }
    }
}