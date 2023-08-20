using CommonWebAPI.Entities;
using CommonWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommonWebAPI.Controllers
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
            var commonEntity = this._dbContext.commonEntities.Where(d => !d.IsDeleted);
 
            if(commonEntity == null) { return NotFound(); };

            // a clausula where recebe uma expressao lambda
            return Ok(commonEntity);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            var commonEntity = this._dbContext.commonEntities.Include(u => u.Users).SingleOrDefault(d => d.Id == id);

            if(commonEntity == null) { return NotFound(); }

            return Ok(commonEntity);
        }

        [HttpPost]
        public IActionResult Post(TabNode commonEntity)
        {
            // adicao logica
            this._dbContext.commonEntities.Add(commonEntity);

            //adicao fisica
            this._dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetByID), new { id = commonEntity.Id }, commonEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TabNode commonEntityInput)
        {
            var commonEntity = this._dbContext.commonEntities.SingleOrDefault(d => d.Id == id);

            if (commonEntity == null) { return NotFound(); }

            commonEntity.Update(commonEntityInput.Name, commonEntityInput.IpAddress, commonEntityInput.MacAddress, commonEntityInput.IsUp, commonEntity.IsDeleted);

            //update logico
            this._dbContext.Update(commonEntityInput);

            //update fisicio
            this._dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var commonEntity = this._dbContext.commonEntities.SingleOrDefault(d => d.Id == id);

            if (commonEntity == null) { return NotFound(); }

            commonEntity.Delete();

            this._dbContext.SaveChanges();

            return NoContent();
        }
    }
}
