
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataStoreWebAPI.Controllers
{

    [Route("api/datastore")]
    [ApiController]
    public class TabEmissorController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabEmissorController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpPost("cadastro-emissor")]
        public IActionResult PostCadastroEmissor(EmissorDto dto)
        {
            var NovoEmissor = new TabEmissor();
            NovoEmissor.tabUsuario.nomeUsuario = dto.nome;
            NovoEmissor.tabUsuario.password = dto.password;
            NovoEmissor.tabUsuario.loginName = dto.userName;
            _dbContext.tabEmissors.Add(NovoEmissor);
            _dbContext.SaveChanges();
            return Ok(dto);

        }


    }
}
