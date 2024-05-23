
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
 

namespace DataStoreWebAPI.Controllers
{
    /*------------------------- Servicos: --------------------------------*/
    // retorna todos os documentos possiveis de avaliacao (pendente de avaliacao)
    // inicia uma avaliacao de um documento ja existente
    // avalia um item que ja possui processo de avaliacao iniciado por um avaliador
    /*-----------------------------------------------------------------------------*/

    [Route("api/datastore")]
    [ApiController]
    [Authorize(Roles = "Admin, Gerente")] // em conjunto com o framework identity libera acesso ao controlador apenas a usuarios logados
    public class TabAvaliacaoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;
        

        public TabAvaliacaoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
             
        }


        // retorna todos documentos passiveis de avaliacao
        [HttpGet("visualiza-documentos-para-avaliar")]
        public IActionResult GetDocumentosParaAvaliar()
        {
            var documentos = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                   && td.isOpen 
                                                                   && td.avaliador == null
                                                                ).ToList();
         
            var view_docs_disponiveis = 
            (
                from doc in documentos
                    join cliente in this._dbContext.Users
                        on doc.idCliente equals cliente.Id

                select new 
                {
                    cod_doc  = doc.codigoDocumento,
                    cliente = cliente.UserName,
                    dta_abertura = doc.dataSolicitacao
                }
            );
            
            if(documentos != null)
            {
                return Ok(view_docs_disponiveis);
            }
            return NotFound();
        }


        // retorna todos documentos passiveis de avaliacao
        [HttpGet("visualiza-itens-documento/{codigo_documento}")]
        public IActionResult GetItensDocumento(int codigo_documento)
        {
            var itensDoc = this._dbContext.tabItemDocumento.Where(td => td.codigoDocumento == codigo_documento 
                                                                ).ToList();
    
            var view_item_doc = 
            (
                from idoc in itensDoc
                    
                    join obj in this._dbContext.tabObjeto
                        on idoc.codigoObjeto equals obj.IdObjeto

                    join permissao in this._dbContext.tabPermissao
                        on idoc.codigoPermissao equals permissao.codigoPermissao

                    //join ava in this._dbContext.tabAvaliacao.DefaultIfEmpty()
                    //    on new {idoc.codigoDocumento, idoc.codigoItemDocumento} equals new {ava.codigoDocumento, ava.codigoItemDocumento} 

                    join doc in this._dbContext.tabDocumento 
                        on idoc.codigoDocumento equals doc.codigoDocumento
    
                    join cliente in this._dbContext.Users
                        on doc.idCliente equals cliente.Id

                    //join avaliador in this._dbContext.Users.DefaultIfEmpty()
                    //    on doc.idAvaliador equals avaliador.Id

                select new 
                {
                    cod_item_doc = idoc.codigoItemDocumento,
                    TipoObjeto = obj.descricaoTipoObjeto,
                    NomeObjeto = obj.ObjectName,
                    Database = obj.DatabaseName,
                    Servidor = obj.serverName,
                    Permissao = permissao.descricaoPermissao
                    //resultado = ava.resultado,
                    //justificativa = ava.justificativa
                }
            ); 
            
            if(itensDoc != null)
            {
                return Ok(view_item_doc);
            }
            return NotFound();
        }        

        // iniciar uma avaliacao
        [HttpPut("iniciar-avaliacao/{cod_documento}/{email_avaliador}")]
        public IActionResult PutIniciaAvaliacao(int cod_documento, string email_avaliador)
        {
            var documento = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                   && td.isOpen 
                                                                   && td.avaliador == null
                                                                   && td.codigoDocumento == cod_documento
                                                                ).SingleOrDefault();
            if(documento != null)
            {
                var avaliador = this._dbContext.Users.Where(tu => tu.Email == email_avaliador).SingleOrDefault();
                if(avaliador != null)
                {
                    documento.avaliador = avaliador;
                    this._dbContext.tabDocumento.Update(documento);
                    this._dbContext.SaveChanges();
                    return Ok();

                }
                return BadRequest("Avaliador Inválido");         
            }
            return BadRequest("Documento Inválido");
        }        

        // avalia um item que ja possui processo de avaliacao do documento iniciado por um avaliador
        [HttpPut("avaliar-item")]
        public IActionResult PutAvaliarItem(AvaliacaoDto dto)
        {
            var avaliador = this._dbContext.Users.Where(tu => tu.Email == dto.email_avaliador).SingleOrDefault();
            if(avaliador != null)
            {
                var documento = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                    && td.isOpen 
                                                                    && td.avaliador == avaliador // importante, o avaliador x nao pode avaliar doc do avaliador y
                                                                    && td.codigoDocumento == dto.codigoDocumento
                                                                    ).SingleOrDefault();
                if(documento != null)
                {
                    var item = this._dbContext.tabItemDocumento.Where(tid => tid.codigoItemDocumento == dto.codigoItemDocumento 
                                                                      && tid.codigoDocumento == dto.codigoDocumento
                                                                      ).SingleOrDefault();
                    if(item != null)
                    {
                        
                        var NovaAvaliacao = new TabAvaliacao();
                        NovaAvaliacao.resultado = dto.resultado;
                        NovaAvaliacao.justificativa = dto.justificativa;
                        NovaAvaliacao.codigoItemDocumento = dto.codigoItemDocumento;
                        NovaAvaliacao.codigoDocumento = dto.codigoDocumento;

                        this._dbContext.Attach(NovaAvaliacao);
                        this._dbContext.Entry(NovaAvaliacao).State = EntityState.Added;



                        this._dbContext.SaveChanges();
                        return Ok();

                    }
                    return NotFound("Item de documento Inválido");
                }
                return BadRequest("Documento Inválido");
            }
            return BadRequest("Avaliador Inválido");
                                                            
        }                


        [HttpGet("visualizar-itens-avaliados")]
        public IActionResult GetItensAvaliadosByAvaliador(string email_avaliador)
        {
            var avaliador = this._dbContext.Users.Where(tu => tu.Email == email_avaliador).SingleOrDefault();
            if(avaliador != null)
            {
                
                var documento = this._dbContext.tabDocumento.Where(td => td.isCanceled == false && 
                                                                         td.avaliador == avaliador 
                                                                  ).ToList();

                if(documento.Count > 0)
                {
                    // syntax-based query
                    var view_item_doc = 
                    (
                        from ep in documento

                            join e in this._dbContext.tabItemDocumento 
                                on ep.codigoDocumento equals e.codigoDocumento

                            join t in this._dbContext.tabAvaliacao 
                                on new {e.codigoDocumento, e.codigoItemDocumento} equals new {t.codigoDocumento, t.codigoItemDocumento} 
                    
                        select new 
                        {
                            cod_doc  = e.codigoDocumento,
                            cod_item_doc = e.codigoItemDocumento,
                            resultado = t.resultado,
                            justificativa = t.justificativa
                        }
                    );
                    if(view_item_doc != null)
                    {
                        return Ok(view_item_doc);
                    }
                    return Ok("O avaliador nao avaliou nada ainda");
                }
                return Ok("Avaliador não iniciou avaliações");                  
            }
            return BadRequest("Avaliador Inválido");
                                                            
        }   

    }
}
