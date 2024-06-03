
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataStoreWebAPI.Controllers
{

    [Route("api/datastore")]
    [ApiController]
    [Authorize] // em conjunto com o framework identity libera acesso ao controlador apenas a usuarios logados
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

        [HttpGet("objetos-por-classe/{desc_classe}")]
        public IActionResult GetObjetosPorClasse(string desc_classe)
        {
            var classe = this._dbContext.tabClasseObjeto.Where(tco => tco.DescricaoClasse == desc_classe).FirstOrDefault();
            if(classe != null)
            {
                var objetos =
                (
                    from obj in this._dbContext.tabObjeto.Where(to => to.idClasseObjeto == classe.IdClasse).ToList()
                    select new {
                        objeto = obj.ObjectName,
                        banco = obj.DatabaseName,
                        servidor = obj.serverName
                    }
                );
                return Ok(objetos);
            }
            return NotFound("Classe Invalida");

        }        

    }
}
