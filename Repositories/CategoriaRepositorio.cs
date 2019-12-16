using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        EventShareContext context = new EventShareContext();
        public async Task<List<EventoCategoriaTbl>> Get()
        {
            return await context.EventoCategoriaTbl.ToListAsync();
        }

        public async Task<EventoCategoriaTbl> Get(int id){
            EventoCategoriaTbl categoriaEncontrada = await context.EventoCategoriaTbl.FindAsync(id);

            return categoriaEncontrada;
        }
        public async Task<EventoCategoriaTbl> Post(EventoCategoriaTbl categoria)
        {
            await context.EventoCategoriaTbl.AddAsync(categoria);
            await context.SaveChangesAsync();

            return categoria;
        }

        public async Task<EventoCategoriaTbl> Put(int id, EventoCategoriaTbl categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return categoria;
        }
         public async Task<EventoCategoriaTbl> Delete(int id)
        {
            EventoCategoriaTbl categoriaRetornada = await context.EventoCategoriaTbl.FindAsync(id);

            context.EventoCategoriaTbl.Remove(categoriaRetornada);
            await context.SaveChangesAsync();
            return categoriaRetornada;
        }
    }
}