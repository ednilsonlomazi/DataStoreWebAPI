
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataStoreWebAPI.Models;

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
            if(_dbContext.tabCliente.Where(tc => tabDocumentoInput.codigoCliente == tabDocumentoInput.codigoCliente) != null)
            {
                this._dbContext.tabDocumento.Add(tabDocumentoInput);
                this._dbContext.SaveChanges();
                return Ok(tabDocumentoInput);
            }
            return NotFound();
            
        }

        [HttpPost("adicionar-item-solicitacao")]
        public IActionResult PostAdicionarItemSolicitacao(ItemDocumentoDto dto)
        {
            
            if (this._dbContext.tabDocumento.Where(t => t.codigoDocumento == dto.codigoDocumento).Single() != null) 
            {
                var o = new TabObjeto();
                o.codigoBancoDados = dto.codigoBancoDados;
                o.codigoObjeto = dto.codigoObjeto;
                o.serverName = dto.serverName;

                var p = new TabPermissao();
                p.codigoPermissao = dto.codigoPermissao;

                var NovoItemDocumento = new TabItemDocumento();
                NovoItemDocumento.objeto = o;
                NovoItemDocumento.permissao = p;
                NovoItemDocumento.codigoDocumento = dto.codigoDocumento; 
                this._dbContext.Attach(NovoItemDocumento);
                this._dbContext.Entry(NovoItemDocumento).State = EntityState.Added;
                this._dbContext.SaveChanges();
                return Ok(); 
            }

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
