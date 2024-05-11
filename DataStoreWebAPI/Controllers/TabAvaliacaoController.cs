
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
                                                                   && td.emissor == null
                                                                ).ToList();
            if(documentos != null)
            {
                return Ok(documentos);
            }
            return NotFound();
        }

        // iniciar uma avaliacao
        [HttpGet("iniciar-avaliacao/{cod_documento}/{cod_avaliador}")]
        public IActionResult GetDocumentosParaAvaliar(int cod_documento, int cod_avaliador)
        {
            var documento = this._dbContext.tabDocumento.Where(td => td.isCanceled == false 
                                                                   && td.isOpen 
                                                                   && td.emissor == null
                                                                   && td.codigoDocumento == cod_documento
                                                                ).Single();
            if(documento != null)
            {
                var avaliador = this._dbContext.tabEmissors.Where(te => te.codigoEmissor == cod_avaliador).Single();
                if(avaliador != null)
                {
                    documento.emissor = avaliador;
                    this._dbContext.tabDocumento.Update(documento);
                    this._dbContext.SaveChanges();
                    return Ok();

                }
                return NotFound();
                
                
            }
            return NotFound();
        }        


    }
}
