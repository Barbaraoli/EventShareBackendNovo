using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace EventShareBackend_master.Interfaces
{
    public interface IUsuarioTipoRepositorio
    {
        Task<List<UsuarioTipoTbl>> Get();

        Task<UsuarioTipoTbl> Get(int id);
    }
}