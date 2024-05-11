
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
    public class TabClienteController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabClienteController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpPut("cadastro-cliente")]
        public IActionResult PutCadastroCliente(ClienteDto clienteDto)
        {
            var x = new TabCliente();
            x.tabUsuario.nomeUsuario = clienteDto.nome;
            x.tabUsuario.password = clienteDto.password;
            x.tabUsuario.loginName = clienteDto.userName;
            _dbContext.tabCliente.Add(x);
            _dbContext.SaveChanges();
            return Ok(clienteDto);

        }


    }
}
