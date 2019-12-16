using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class UsuarioTipoRepositorio : IUsuarioTipoRepositorio
    {
        
        EventShareContext context = new EventShareContext();

        public async Task<List<UsuarioTipoTbl>> Get()
        {
            return await context.UsuarioTipoTbl.ToListAsync();
        }

        public async Task<UsuarioTipoTbl> Get(int id)
        {
            return await context.UsuarioTipoTbl.FindAsync(id);
        }

    }
    
}