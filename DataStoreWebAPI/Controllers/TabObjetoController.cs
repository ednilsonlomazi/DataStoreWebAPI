
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

        [HttpGet("objetos-disponiveis/{server_name}/{cod_db}/{cod_obj}")]
        public IActionResult GetObjetoDisponivel(string server_name, int cod_db, int cod_obj)
        {
            var tabObjeto = this._dbContext.tabObjeto.Where(to => to.serverName == server_name && 
                                                            to.codigoBancoDados == cod_db &&
                                                            to.codigoObjeto == cod_obj).SingleOrDefault();

            if (tabObjeto != null)
            {
                return Ok(tabObjeto);
            };

            return NotFound();

        }

    }
}
