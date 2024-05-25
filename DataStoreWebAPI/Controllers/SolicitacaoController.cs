
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



        // retorna todos os documentos de um cliente
        [HttpGet("visualiza-documentos-cliente/{email_cliente}")]
        public IActionResult GetDocumentosCliente(string email_cliente)
        {
            var cliente = this._dbContext.Users.Where(u => u.Email == email_cliente).SingleOrDefault();
            if(cliente != null)
            {
                var documentos = this._dbContext.tabDocumento.Where(td => td.idCliente == cliente.Id).ToList();
                var view_item_doc = 
                (
                    from doc in documentos

                        join idoc in this._dbContext.tabItemDocumento
                            on doc.codigoDocumento equals idoc.codigoDocumento
                        
                        join obj in this._dbContext.tabObjeto
                            on idoc.codigoObjeto equals obj.IdObjeto

                        join permissao in this._dbContext.tabPermissao
                            on idoc.codigoPermissao equals permissao.codigoPermissao

                        join avaliador in this._dbContext.Users // left join em avaliador
                            on doc.idAvaliador equals avaliador.Id into tmp_ava from tmp in tmp_ava.DefaultIfEmpty()

                        join ta in this._dbContext.tabAvaliacao // left join avaliacao
                            on new {idoc.codigoDocumento, idoc.codigoItemDocumento} equals 
                            new {ta.codigoDocumento, ta.codigoItemDocumento} into tmp_ta from left_ta in tmp_ta.DefaultIfEmpty()
                        
                    select new 
                    {
                        cod_doc = doc.codigoDocumento,
                        cod_item_doc = idoc.codigoItemDocumento,
                        TipoObjeto = obj.descricaoTipoObjeto,
                        NomeObjeto = obj.ObjectName,
                        Database = obj.DatabaseName,
                        Servidor = obj.serverName,
                        Permissao = permissao.descricaoPermissao,
                        DtaAbertura = doc.dataSolicitacao,
                        Avaliador = tmp?.UserName,
                        ResultadoAvaliacao = left_ta?.resultado
                        
                    }
                ); 
                if(view_item_doc != null)
                {
                    return Ok(view_item_doc);
                }
                return NotFound("Não foram encontrado documentos");
            }
            return BadRequest("Cliente invalido");
        }       

        // cria uma solicitacao de acesso
        // diferentemente do add item...
        [HttpPost("criar-solicitacao")]
        public IActionResult PostCriarSolicitacao(SolicitacaoDto dto)
        {
            // o dbset do identityuser eh public virtual IDbSet<TUser> Users { get; set; }
            var cliente = this._dbContext.Users.Where(tu => tu.Email == dto.email_cliente).SingleOrDefault();
            if(cliente != null)
            {
                var obj = this._dbContext.tabObjeto.Where(to => to.serverName == dto.server_name &&
                                                          to.DatabaseName == dto.database_name &&
                                                          to.ObjectName == dto.object_name).SingleOrDefault();

                var permissao = this._dbContext.tabPermissao.Where(tp => tp.descricaoPermissao == dto.permissao).SingleOrDefault();

                var NovoDocumento = new TabDocumento();
                NovoDocumento.cliente = cliente;
                
                var NovoItemDocumento = new TabItemDocumento();
                NovoItemDocumento.codigoObjeto = obj.IdObjeto;
                NovoItemDocumento.codigoPermissao = permissao.codigoPermissao;

                NovoDocumento.tabItemDocumento.Add(NovoItemDocumento);

                this._dbContext.tabDocumento.Add(NovoDocumento);
        
                // ---------- tabelas de juncao ---------- //
                var joinTableObj = new TabItemDocumentoObjeto();
                joinTableObj.tabObjeto = obj;
                joinTableObj.tabItemDocumento = NovoItemDocumento;

                var joinTablePermissao = new TabItemDocumentoPermissao();
                joinTablePermissao.tabPermissao = permissao;
                joinTablePermissao.tabItemDocumento = NovoItemDocumento;

                this._dbContext.Attach(joinTableObj);
                this._dbContext.Entry(joinTableObj).State = EntityState.Added;                

                this._dbContext.Attach(joinTablePermissao);
                this._dbContext.Entry(joinTablePermissao).State = EntityState.Added;  
                
                this._dbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
            
        }

        [HttpPost("adicionar-item-solicitacao")]
        public IActionResult PostAdicionarItemSolicitacao(ItemDocumentoDto dto)
        {
            var documento = this._dbContext.tabDocumento.Where(t => t.codigoDocumento == dto.codigoDocumento).SingleOrDefault(); 
            
            if (documento != null && documento.isOpen) 
            {
                

                // ----------- endpoints ------------ //
                var objeto = this._dbContext.tabObjeto.Where(to => to.serverName == dto.serverName && 
                                                             to.codigoBancoDados == dto.codigoBancoDados &&
                                                             to.codigoObjeto == dto.codigoObjeto
                                                            ).SingleOrDefault();
                
                var permissao = this._dbContext.tabPermissao.Where(tp => tp.codigoPermissao == dto.codigoPermissao).SingleOrDefault();

                if(objeto != null && permissao != null)
                {
                    var itemDocumento = this._dbContext.tabItemDocumento.Where(tid => tid.codigoDocumento == dto.codigoDocumento &&
                                                                               tid.codigoObjeto == objeto.IdObjeto && // muito importante essa parte
                                                                               tid.codigoPermissao == dto.codigoPermissao).SingleOrDefault();
                    if(itemDocumento == null)
                    {
                        // ----------------Config Item Doc ------------------ //

                        var NovoItemDocumento = new TabItemDocumento();
                        NovoItemDocumento.codigoDocumento = dto.codigoDocumento;
                        NovoItemDocumento.codigoObjeto = objeto.IdObjeto; // Id universal do objeto entre servidores
                        NovoItemDocumento.codigoPermissao = dto.codigoPermissao;

                        // ---------- tabelas de juncao ---------- //
                        var joinTableObj = new TabItemDocumentoObjeto();
                        joinTableObj.tabObjeto = objeto;
                        joinTableObj.tabItemDocumento = NovoItemDocumento;

                        var joinTablePermissao = new TabItemDocumentoPermissao();
                        joinTablePermissao.tabPermissao = permissao;
                        joinTablePermissao.tabItemDocumento = NovoItemDocumento;

                        // ---------------------Attachments ---------------------------- //

                        this._dbContext.Attach(NovoItemDocumento);
                        this._dbContext.Entry(NovoItemDocumento).State = EntityState.Added;

                        this._dbContext.Attach(joinTableObj);
                        this._dbContext.Entry(joinTableObj).State = EntityState.Added;

                        this._dbContext.Attach(joinTablePermissao);
                        this._dbContext.Entry(joinTablePermissao).State = EntityState.Added;

                        this._dbContext.SaveChanges();
                        return Ok();                   
                    }
                    return BadRequest("Você já fez essa solicitacao");

 
                }
                return BadRequest("Item de documento Invalido");
            }
            return BadRequest("Documento Inválido");
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
