
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataStoreWebAPI.Controllers
{
    /*------------------------- Servicos: --------------------------------*/
    // retorna todos os documentos possiveis de avaliacao (pendente de avaliacao)
    // inicia uma avaliacao de um documento ja existente
    // avalia um item que ja possui processo de avaliacao iniciado por um avaliador
    /*-----------------------------------------------------------------------------*/

    [Route("api/datastore")]
    [ApiController]
    public class TabAvaliacaoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabAvaliacaoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        // retorna todos documentos passiveis de avaliacao
        [HttpGet("documentos-para-avaliar")]
        public IActionResult GetDocumentosParaAvaliar()
        {
            var documentos = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                   && td.isOpen 
                                                                   && td.avaliador == null
                                                                ).ToList();
            if(documentos != null)
            {
                return Ok(documentos);
            }
            return NotFound();
        }

        // iniciar uma avaliacao
        [HttpPut("iniciar-avaliacao/{cod_documento}/{cod_avaliador}")]
        public IActionResult PutIniciaAvaliacao(int cod_documento, int cod_avaliador)
        {
            var documento = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                   && td.isOpen 
                                                                   && td.avaliador == null
                                                                   && td.codigoDocumento == cod_documento
                                                                ).Single();
            if(documento != null)
            {
                var avaliador = this._dbContext.tabAvaliador.Where(te => te.codigoAvaliador == cod_avaliador).Single();
                if(avaliador != null)
                {
                    documento.avaliador = avaliador;
                    this._dbContext.tabDocumento.Update(documento);
                    this._dbContext.SaveChanges();
                    return Ok();

                }
                return NotFound();
                
                
            }
            return NotFound();
        }        

        // avalia um item que ja possui processo de avaliacao do documento iniciado por um avaliador
        [HttpPut("avaliar-item")]
        public IActionResult PutAvaliarItem(AvaliacaoDto dto)
        {
            
            var documento = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                   && td.isOpen 
                                                                   && td.avaliador != null
                                                                   && td.codigoDocumento == dto.codigoDocumento
                                                                ).Single();
                                                                
            if(documento != null)
            {
                if(documento.avaliador.codigoAvaliador == dto.codigoAvaliador)
                {
                    var item = this._dbContext.tabItemDocumento.Where(tid => tid.codigoItemDocumento == dto.codigoItemDocumento 
                                                                      && tid.codigoDocumento == dto.codigoDocumento
                                                                      && tid.avaliacao == null).Single();
                    if(item != null)
                    {
                        // payload da avaliacao
                        var NovaAvaliacao = new TabAvaliacao();
                        NovaAvaliacao.resultado = dto.resultado;
                        NovaAvaliacao.justificativa = dto.justificativa;
                        this._dbContext.tabAvaliacao.Add(NovaAvaliacao);

                        item.avaliacao = NovaAvaliacao;


                        this._dbContext.tabItemDocumento.Update(item);
                        this._dbContext.SaveChanges();
                        return Ok();

                    }
                    return NotFound();
                }
                return NotFound();
            }
            return NotFound();
        }                


    }
}