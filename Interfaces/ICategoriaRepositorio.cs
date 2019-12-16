using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace EventShareBackend_master.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<EventoCategoriaTbl>> Get();

        Task<EventoCategoriaTbl> Get(int id);
        Task<EventoCategoriaTbl> Post(EventoCategoriaTbl categoria);

        Task<EventoCategoriaTbl> Put(int id, EventoCategoriaTbl categoria);

        Task<EventoCategoriaTbl> Delete(int id);  
    }
}