using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackEnd.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackEnd.Repositories
{
    public class UsuarioTblRepositorio : IUsuarioTblRepositorio
    {
        EventShareContext context = new EventShareContext();

        public async Task<List<UsuarioTbl>> Get()
        {
            List<UsuarioTbl> listaU = await context.UsuarioTbl.Include(t => t.UsuarioTipo).ToListAsync();

            foreach (var usuario in listaU)
            {
                usuario.UsuarioTipo.UsuarioTbl = null;
            }

            return listaU;
        }

        public async Task<UsuarioTbl> Get(int id)
        {
            return await context.UsuarioTbl.FindAsync(id);
        }

        public async Task<bool> ValidaEmail(UsuarioTbl usuario){
            UsuarioTbl usuarioExiste = await context.UsuarioTbl.FirstOrDefaultAsync(u => u.UsuarioEmail == usuario.UsuarioEmail);

            if(usuarioExiste == null){
                return false;
            }

            return true;
        }

        public async Task<UsuarioTbl> Post(UsuarioTbl usuario)
        {
            UsuarioTbl usuarioCadastrado = usuario;
            // usuarioCadastrado.UsuarioNome = usuario.UsuarioNome.ToLower();

            await context.UsuarioTbl.AddAsync(usuarioCadastrado);
            await context.SaveChangesAsync();
            return usuarioCadastrado;
        }

        public async Task<UsuarioTbl> Put(UsuarioTbl usuario)
        {
            UsuarioTbl usuarioModificado = await context.UsuarioTbl.FindAsync(usuario.UsuarioId);

            // usuarioModificado.UsuarioId = usuario.UsuarioId;
            usuarioModificado.UsuarioNome = usuario.UsuarioNome;
            usuarioModificado.UsuarioEmail = usuario.UsuarioEmail;
            usuarioModificado.UsuarioComunidade = usuario.UsuarioComunidade;
            usuarioModificado.UsuarioSenha = usuario.UsuarioSenha;
            usuarioModificado.UsuarioTipoId = usuario.UsuarioTipoId;

            // context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioTbl> Delete(int id)
        {
           UsuarioTbl usuario = await context.UsuarioTbl.FindAsync(id);

            if(usuario == null)
            {
                return null;
            }

            context.UsuarioTbl.Remove(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }
    }
}