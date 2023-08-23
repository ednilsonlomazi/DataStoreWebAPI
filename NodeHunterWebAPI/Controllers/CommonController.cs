using NodeHunterWebAPI.Entities;
using NodeHunterWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NodeHunterWebAPI.Controllers
{

    [Route("api/common-web-api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
    
        private readonly DbNodeHunterContext _dbContext;

        public CommonController(DbNodeHunterContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commonEntity = this._dbContext.tabNode.Where(d => !d.IsDeleted);
 
            if(commonEntity == null) { return NotFound(); };

            // a clausula where recebe uma expressao lambda
            return Ok(commonEntity);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            var tab_node = this._dbContext.tabNode.Include(u => u.Users).SingleOrDefault(d => d.Id == id);

            if(tab_node == null) { return NotFound(); }

            return Ok(tab_node);
        }

        [HttpPost]
        public IActionResult Post(TabNode tabNodeInput)
        {
            // adicao logica
            this._dbContext.tabNode.Add(tabNodeInput);

            //adicao fisica
            this._dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetByID), new { id = tabNodeInput.Id }, tabNodeInput);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TabNode tabNodeInput)
        {
            var tab_node = this._dbContext.tabNode.SingleOrDefault(d => d.Id == id);

            if (tab_node == null) { return NotFound(); }

            tab_node.Update(tabNodeInput.Name, tabNodeInput.IpAddress, tabNodeInput.MacAddress, tabNodeInput.IsUp, tab_node.IsDeleted);

            //update logico
            this._dbContext.tabNode.Update(tab_node);

            //update fisicio
            this._dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var commonEntity = this._dbContext.tabNode.SingleOrDefault(d => d.Id == id);

            if (commonEntity == null) { return NotFound(); }

            commonEntity.Delete();

            this._dbContext.SaveChanges();

            return NoContent();
        }

        // recebe id do node para adicionar um usuario
        [HttpPost("{id}/users")]
        public IActionResult PostUser(Guid id, TabUser tabUserInput)
        {
            tabUserInput.NodeId = id;

            // existe algum node com esse id?
            var node = this._dbContext.tabNode.Any(tn => tn.Id == id);

            if (node == null) { return NotFound(); };

            this._dbContext.tabUser.Add(tabUserInput);
            this._dbContext.SaveChanges();

            return NoContent();
        }
    }
}
