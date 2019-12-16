
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventShareBackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;
using tst.Repositorio;

namespace EventShareBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class UsuarioTblController : ControllerBase
    {
        EventShareContext context = new EventShareContext();

        UsuarioTblRepositorio repositorio = new UsuarioTblRepositorio();

        UploadRepositorio upload = new UploadRepositorio();

        /// <summary>
        /// Método para listar os usuário cadastrados
        /// </summary>
        /// <returns>Retorna lista de usuarios</returns>
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioTbl>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para buscar um usuario pelo ID
        /// </summary>
        /// <returns>Retorna o usuário</returns>
        /// <param name="id"></param>
        [EnableCors]
        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioTbl>> Get(int id)
        {
            UsuarioTbl usuario = await repositorio.Get(id);

            if(usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return usuario;
        }

        /// <summary>
        /// Esse método tem o objetivo de pegar as informações do usuário logado.
        /// </summary>
        /// <returns>Retorna o usuário</returns>
        [Authorize]
        [HttpGet("perfilusuario")]
        public async Task<ActionResult<UsuarioTbl>> PegarUsuario(){
            try
            {
                var idUsuario = HttpContext.User.Claims.First(a => a.Type == "UserId").Value;
                var usuario = await repositorio.Get(int.Parse(idUsuario));

                return Ok(usuario);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
            
        }

        /// <summary>
        /// Método para criar um usuario
        /// </summary>
        /// <returns>Retorna o usuario cadastrado</returns>
        /// <param name="usuario"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UsuarioTbl>> Post([FromForm]UsuarioTbl usuario)
        {
            if(await repositorio.ValidaEmail(usuario)){
                return BadRequest("Esse E-mail já foi cadastrado");
            }            

            if(!usuario.UsuarioEmail.Contains('@') || !usuario.UsuarioEmail.Contains('.')){
                throw new System.ArgumentException("E-mail inválido.");
            }

            if(usuario.UsuarioSenha.Length < 8){
                throw new System.ArgumentException("A senha possui menos de 8 caracteres");
            }

            // try
            // {
            //     await repositorio.Post(usuario);
            //     return Ok("Usuário cadastrado!");
            // }
            // catch (System.Exception)
            // {
            //     return BadRequest(new { mensagem = "Verifique os campos em nulo."});
            //     throw;
            // }

            // var arquivo = Request.Form.Files[0];
            // usuario.UsuarioImagem = upload.Upload(arquivo, "images");

            usuario.UsuarioNome = Request.Form["UsuarioNome"];
            if(usuario.UsuarioNome == null){
                throw new System.ArgumentNullException("Campo Nome é obrigatório.");
            }

            usuario.UsuarioEmail = Request.Form["UsuarioEmail"];
            if(usuario.UsuarioEmail == null){
                throw new System.ArgumentNullException("Campo E-mail é obrigatório.");
            }

            usuario.UsuarioComunidade = Request.Form["UsuarioComunidade"];

            usuario.UsuarioSenha = Request.Form["UsuarioSenha"];
            if(usuario.UsuarioSenha == null){
                throw new System.ArgumentNullException("Campo Senha é obrigatório.");
            }

            usuario.UsuarioTipoId = int.Parse(Request.Form["UsuarioTipoId"]);
            await repositorio.Post(usuario);
            return Ok("Usuário cadastrado");
        }

        /// <summary>
        /// Método para atualizar dados de um usuário cadastrado
        /// </summary>
        /// <returns>Retorna o usuario</returns>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        [EnableCors]
        // [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioTbl>> Put(int id, UsuarioTbl usuario)
        {
            var usuarioAlterado = await repositorio.Get(id);

            if(id != usuario.UsuarioId){
                return BadRequest("Ids divergentes.");
            }

            if(usuarioAlterado == null){
                return NotFound("Usuário não encontrado.");
            }

            try
            {
                return await repositorio.Put(usuario);
            }
            catch (System.ArgumentException)
            {
                return BadRequest(new { mensagem = "Verifique os campos em nulo."});
                throw;
            }

            // if(id != usuario.UsuarioId){
            //     return BadRequest("Id inválida");
            // }

            // var arquivo = Request.Form.Files[0];
            // usuario.UsuarioId = usuarioAlterado.UsuarioId;
            // usuario.UsuarioImagem = upload.Upload(arquivo, "images");

            // usuario.UsuarioNome = Request.Form["UsuarioNome"];


            // if(usuario.UsuarioNome == null){
            //     throw new System.ArgumentNullException("Campo Nome é obrigatório.");
            // }
                
            // // usuario.UsuarioEmail = Request.Form["UsuarioEmail"];
            // if(usuario.UsuarioEmail == null){
            //     throw new System.ArgumentNullException("Campo E-mail é obrigatório.");
            // }

            // usuario.UsuarioComunidade = Request.Form["UsuarioComunidade"];
            // if(usuario.UsuarioComunidade == null){
            //     throw new System.ArgumentNullException("Digite o nome da comunidade.");
            // }

            // usuario.UsuarioTipoId = int.Parse(Request.Form["UsuarioTipoId"]);
            

            // usuario.UsuarioSenha = Request.Form["UsuarioSenha"];
            

            // return await repositorio.Put(usuario);   
        }

        /// <summary>
        /// Método para deletar um usuário cadastrado
        /// </summary>
        /// <returns>Retorna o usuario deletado</returns>
        ///<param name="id"></param>
        [EnableCors]
        // [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioTbl>> Delete(int id)
        {
            UsuarioTbl usuarioDeletado = await repositorio.Delete(id);

            if(usuarioDeletado == null){
                return NotFound("Usuário não encontrado!");
            }
            
            return usuarioDeletado;
        }
    }
}