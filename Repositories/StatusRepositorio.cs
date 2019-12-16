using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class StatusRepositorio : IStatusRepositorio
    {
        EventShareContext context = new EventShareContext();
        
        public async Task<List<EventoStatusTbl>> Get()
        {
            return await context.EventoStatusTbl.ToListAsync();
        }
    }
}