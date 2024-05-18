
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
 

namespace DataStoreWebAPI.Controllers
{

    [Route("api/datastore")]
    [ApiController]
    [Authorize] // em conjunto com o framework identity libera acesso ao controlador apenas a usuarios logados
    public class TabDocumentoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;
         
        public TabDocumentoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
             
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpGet("solicitacoes-cliente/{email_cliente}")]
        public IActionResult GetSolicitacoesCliente(string email_cliente)
        {
            var tabDocumento = this._dbContext.tabDocumento.Where(td => td.cliente.Email == email_cliente).SingleOrDefault();

            if (tabDocumento != null)
            {
                return Ok(tabDocumento);
            };

            return NotFound();

        }

        // cria uma solicitacao de acesso
        [HttpPost("realizar-solicitacao")]
        public IActionResult PostRealizarSolicitacao(DocumentoDto dto)
        {
            // o dbset do identityuser eh public virtual IDbSet<TUser> Users { get; set; }
            var cliente = this._dbContext.Users.Where(tu => tu.Email == dto.email_cliente).Single();
            if(cliente != null)
            {
                
                var NovoDocumento = new TabDocumento();
                NovoDocumento.cliente = cliente;

                this._dbContext.tabDocumento.Attach(NovoDocumento);
                this._dbContext.Entry(NovoDocumento).State = EntityState.Added;
                this._dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
            
        }

        [HttpPost("adicionar-item-solicitacao")]
        public IActionResult PostAdicionarItemSolicitacao(ItemDocumentoDto dto)
        {
            var documento = this._dbContext.tabDocumento.Where(t => t.codigoDocumento == dto.codigoDocumento).Single(); 
            
            if (documento != null && documento.isOpen) 
            {
                

                // ----------- endpoints ------------ //
                var obj = new TabObjeto();
                obj.codigoBancoDados = dto.codigoBancoDados;
                obj.codigoObjeto = dto.codigoObjeto;
                obj.serverName = dto.serverName;

                var p = new TabPermissao();
                p.codigoPermissao = dto.codigoPermissao;
                // ---------------------------------- //

                var NovoItemDocumento = new TabItemDocumento();
                NovoItemDocumento.codigoDocumento = dto.codigoDocumento;

                // ---------- tabelas de juncao ---------- //
                var joinTableObj = new TabItemDocumentoObjeto();
                joinTableObj.tabObjeto = obj;
                joinTableObj.tabItemDocumento = NovoItemDocumento;

                var joinTablePermissao = new TabItemDocumentoPermissao();
                joinTablePermissao.tabPermissao = p;
                joinTablePermissao.tabItemDocumento = NovoItemDocumento;                
                // ------------------------------------------------- //

                this._dbContext.Attach(NovoItemDocumento);
                this._dbContext.Entry(NovoItemDocumento).State = EntityState.Added;

                this._dbContext.Attach(joinTableObj);
                this._dbContext.Entry(joinTableObj).State = EntityState.Added;

                this._dbContext.Attach(joinTablePermissao);
                this._dbContext.Entry(joinTablePermissao).State = EntityState.Added;

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
