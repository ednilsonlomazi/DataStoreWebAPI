
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataStoreWebAPI.Controllers
{

    [Route("api/datastore")]
    [ApiController]
    public class TabDocumentoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabDocumentoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpGet("solicitacoes-cliente/{cod_cliente}")]
        public IActionResult GetSolicitacoesCliente(int cod_cliente)
        {
            var tabDocumento = this._dbContext.tabDocumento.Where(td => td.codigoCliente == cod_cliente).SingleOrDefault();

            if (tabDocumento != null)
            {
                return Ok(tabDocumento);
            };

            return NotFound();

        }

        // cria uma solicitacao de acesso
        [HttpPost("realizar-solicitacao")]
        public IActionResult PostRealizarSolicitacao(TabDocumento tabDocumentoInput)
        {
            this._dbContext.tabDocumento.Add(tabDocumentoInput);

            this._dbContext.SaveChanges();

            return Ok(tabDocumentoInput);
        }

        // adiciona item em uma solictacao existente
        [HttpPost("adicionar-item-solicitacao/{cod}")]
        public IActionResult PostAdicionarItemSolicitacao(int cod, TabItemDocumento tabItemDocumentoInput)
        {
            tabItemDocumentoInput.codigoDocumento = cod;

            var tabDocumento = this._dbContext.tabDocumento.Where(t => t.codigoDocumento == cod);

            if (tabDocumento != null) 
            {
                this._dbContext.tabItemDocumento.Add(tabItemDocumentoInput);
                this._dbContext.SaveChanges();
                return Ok(tabItemDocumentoInput); //teste
            };

            return NoContent();
        }

        [HttpGet("solicitacao-realizada/{cod}")]
        public IActionResult GetSolicitacaoRealizada(int cod)
        {
            var tabDocumento = this._dbContext.tabDocumento.SingleOrDefault(t => t.codigoDocumento == cod);

            if (tabDocumento != null)
            {
                return Ok(tabDocumento);
            };

            return NotFound();

        }


        [HttpPut("atualizar-solicitacao/{cod}")]
        public IActionResult UpdateDocumento(int cod, TabDocumento tabDocumentoInput)
        {
            var tabDocumento = this._dbContext.tabDocumento.SingleOrDefault(t => t.codigoDocumento == cod);

            if (tabDocumento != null) 
            {
                tabDocumento.AtualizarDocumento(tabDocumentoInput.isOpen, tabDocumentoInput.dataEmissao);

                this._dbContext.tabDocumento.Update(tabDocumento);
               
                this._dbContext.SaveChanges();

                return Ok(tabDocumento);
            }

            return NoContent();
        }

        [HttpDelete("cancelar-solicitacao/{cod}")]
        public IActionResult CancelarSolicitacao(int cod)
        {
            var tabDocumento = this._dbContext.tabDocumento.SingleOrDefault(t => t.codigoDocumento == cod);

            if (tabDocumento != null) 
            {
                tabDocumento.CancelarDocumento();
                this._dbContext.SaveChanges();
                return Ok();
            }

            return NoContent();
        }

    }
}
