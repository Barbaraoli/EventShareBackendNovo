using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace EventShareBackend_master.Interfaces
{
    public interface IStatusRepositorio
    {
    Task<List<EventoStatusTbl>> Get();

    }
}