using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROJETO.Interfaces;
using PROJETO.Models;

namespace PROJETO.Repositories
{
    public class EventoTblRepositorio : IEventoRepositorio
    {
        EventShareContext context = new EventShareContext();

        public async Task<EventoTbl> BuscarPorId(int id)
        {
            return await context.EventoTbl.Include(e => e.EventoCategoria).Include(e => e.CriadorUsuario).Include(e => e.EventoEspaco).FirstOrDefaultAsync(e => e.EventoId == id);
        }
        
        public async Task<List<EventoTbl>> ListarEventos()
        {
            return await context.EventoTbl.Include(e => e.EventoCategoria).Include(e => e.EventoEspaco).Include(e => e.EventoStatus).Include(e => e.CriadorUsuario).ToListAsync();
        }

        public async Task<int> EventosCadastradosDia(DateTime data){
            List<EventoTbl> listaDeEventos = await context.EventoTbl.Where(e => e.EventoData == data).Include(e => e.EventoCategoria).Include(e => e.EventoEspaco).Include(e => e.EventoStatus).Include(e => e.CriadorUsuario).ToListAsync();

            return listaDeEventos.Count;
        }

        public async Task<List<EventoTbl>> ListarEventosUsuario(int id){
            return await context.EventoTbl.Where(e => e.CriadorUsuarioId == id).Include(e => e.EventoCategoria).Include(e => e.EventoEspaco).Include(e => e.EventoStatus).Include(e => e.CriadorUsuario).ToListAsync();
        }

        public async Task<List<int>> BuscarEspacoPorData(DateTime data){
            List<EventoTbl> listaDeEventos = await context.EventoTbl.Where(e => e.EventoData != data).ToListAsync();
            List<int> IdsDeEspacosVazios = new List<int>();

         foreach (var item in listaDeEventos){
            IdsDeEspacosVazios.Add(item.EventoEspacoId);
         }
            
            return IdsDeEspacosVazios;
        }

        public async Task<EventoTbl> BuscarPorNome(string nomeEvento){
            string nomeDoEvento = nomeEvento.ToLower();
            var retorno = await context.EventoTbl.Include(Ec => Ec.EventoCategoria).Include(Eesp => Eesp.EventoEspaco).Include(Es => Es.EventoStatus).Include(ecria => ecria.CriadorUsuario).FirstOrDefaultAsync(x => x.EventoNome == nomeEvento);
            return retorno;
        }
    
        public async Task<List<EventoTbl>> BuscarPalavraChave(string nome){
            List<EventoTbl> listaE = await context.EventoTbl.Where(e => e.EventoNome.Contains(nome)).Include(Es => Es.EventoStatus).Include(Ec => Ec.EventoCategoria).Include(Eesp => Eesp.EventoEspaco).ToListAsync();
            return listaE;
        }

        public async Task<List<EventoTbl>> BuscarPorCategoria(int id){
            List<EventoTbl> listaE = await context.EventoTbl.Where(ev => ev.EventoCategoria.CategoriaId == id).Include(Ec => Ec.EventoCategoria).Include(Eesp => Eesp.EventoEspaco).Include(Es => Es.EventoStatus).Include(ecria => ecria.CriadorUsuario).ToListAsync();
            return listaE;
        }

        public async Task<List<EventoTbl>> BuscarPorData(DateTime data){
            List<EventoTbl> listaE = await context.EventoTbl.Where(ev => ev.EventoData == data).ToListAsync();
            return listaE;
        }
        
        public async Task<List<EventoTbl>> BuscarPorStatus(string status){
            List<EventoTbl> listaE = await context.EventoTbl.Where(ev => ev.EventoStatus.EventoStatusNome.Contains(status)).Include(Ec => Ec.EventoCategoria).Include(Eesp => Eesp.EventoEspaco).Include(Es => Es.EventoStatus).Include(ecria => ecria.CriadorUsuario).ToListAsync();
            return listaE;
        }
        public async Task<EventoTbl> Post(EventoTbl evento){
        
            // EventoTbl eventoCadastrado = evento;
            
            await context.EventoTbl.AddAsync(evento);
            await context.SaveChangesAsync();
            return evento;
        }

        public async Task<EventoTbl> Put(EventoTbl evento){
            EventoTbl eventoEncontrado = await context.EventoTbl.FindAsync(evento.EventoId);
            
            eventoEncontrado.EventoHorarioComeco = evento.EventoHorarioComeco;
            eventoEncontrado.EventoHorarioFim = evento.EventoHorarioFim;
            eventoEncontrado.EventoData = evento.EventoData;
            eventoEncontrado.EventoDescricao = evento.EventoDescricao;
            eventoEncontrado.EventoEspacoId = evento.EventoEspacoId;
            eventoEncontrado.EventoCategoriaId = evento.EventoCategoriaId;
            eventoEncontrado.EventoDescricao = evento.EventoDescricao;
            eventoEncontrado.EventoLinkInscricao = evento.EventoLinkInscricao;
            eventoEncontrado.EventoCoffe = evento.EventoCoffe;
            eventoEncontrado.EventoDiversidade = evento.EventoDiversidade;
            eventoEncontrado.EventoNumeroParticipantes = evento.EventoNumeroParticipantes;
            eventoEncontrado.EventoRestrito = evento.EventoRestrito;
            eventoEncontrado.EventoObsAdicional = evento.EventoObsAdicional;
                        
            // context.Entry(eventoEncontrado).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return eventoEncontrado;
        }
        public async Task<EventoTbl> DeletarEvento(int id){
            EventoTbl eventoRetornado = await context.EventoTbl.FindAsync(id);

            context.EventoTbl.Remove(eventoRetornado);
            await context.SaveChangesAsync();
            return eventoRetornado;
        }

        public Task<EventoTbl> UploadImagem(string imagem)
        {
            throw new NotImplementedException();
        }
    }
}
