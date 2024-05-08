
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataStoreWebAPI.Controllers
{

    [Route("api/datastore")]
    [ApiController]
    public class TabObjetoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;

        public TabObjetoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        [HttpGet("objetos-disponiveis")]
        public IActionResult GetObjetosDisponiveis()
        {
            var tabObjeto = this._dbContext.Set<TabObjeto>();
 
            if(tabObjeto != null) 
            {
                return Ok(tabObjeto);
            };

            return NotFound();

        }

        [HttpGet("objetos-disponiveis/{cod}")]
        public IActionResult GetObjetoDisponivel(int cod)
        {
            var tabObjeto = this._dbContext.tabObjeto.SingleOrDefault(t => t.codigoObjeto == cod);

            if (tabObjeto != null)
            {
                return Ok(tabObjeto);
            };

            return NotFound();

        }

    }
}
