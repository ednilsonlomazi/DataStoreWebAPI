
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


    }
}
