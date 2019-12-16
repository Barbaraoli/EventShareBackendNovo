using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace PROJETO.Interfaces
{
    public interface IEventoRepositorio
    {
        Task<EventoTbl> BuscarPorId(int id);
        Task<List<EventoTbl>> ListarEventos();

        Task<int> EventosCadastradosDia(DateTime data);
        Task<List<EventoTbl>> ListarEventosUsuario(int id);
        Task<List<EventoTbl>> BuscarPalavraChave(string nome);
        Task<EventoTbl> BuscarPorNome(string nomeEvento);
        Task<List<EventoTbl>> BuscarPorCategoria(int id);
        Task<List<EventoTbl>> BuscarPorStatus(string status);
        Task<List<EventoTbl>> BuscarPorData(DateTime data);
        Task<List<int>> BuscarEspacoPorData(DateTime data);
        Task<EventoTbl> Post(EventoTbl evento);
        Task<EventoTbl> Put(EventoTbl evento);
        Task<EventoTbl> DeletarEvento(int id);
        Task<EventoTbl> UploadImagem(string imagem);
    }
}