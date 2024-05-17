
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DataStoreWebAPI.Controllers
{

    [Route("api/datastore")]
    [ApiController]
    [Authorize] // em conjunto com o framework identity libera acesso ao controlador apenas a usuarios logados
    public class TabEmissorController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabEmissorController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpPost("cadastro-emissor")]
        public IActionResult PostCadastroEmissor(AvaliadorDto dto)
        {
            var NovoEmissor = new TabAvaliador();
            NovoEmissor.tabUsuario.nomeUsuario = dto.nome;
            NovoEmissor.tabUsuario.password = dto.password;
            NovoEmissor.tabUsuario.loginName = dto.userName;
            _dbContext.tabAvaliador.Add(NovoEmissor);
            _dbContext.SaveChanges();
            return Ok(dto);

        }


    }
}
