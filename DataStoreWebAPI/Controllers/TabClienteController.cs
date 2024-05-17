
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
    public class TabClienteController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabClienteController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpPost("cadastro-cliente")]
        public IActionResult PostCadastroCliente(ClienteDto clienteDto)
        {
            var NovoCliente = new TabCliente();
            NovoCliente.tabUsuario.nomeUsuario = clienteDto.nome;
            NovoCliente.tabUsuario.password = clienteDto.password;
            NovoCliente.tabUsuario.loginName = clienteDto.userName;
            _dbContext.tabCliente.Add(NovoCliente);
            _dbContext.SaveChanges();
            this._dbContext.Entry(NovoCliente).State = EntityState.Detached;
            return Ok(clienteDto);

        }


    }
}
