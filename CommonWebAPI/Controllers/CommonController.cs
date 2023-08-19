using CommonWebAPI.Entities;
using CommonWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommonWebAPI.Controllers
{

    [Route("api/common-web-api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
    
        private readonly CommonDBContext _dbContext;

        public CommonController(CommonDBContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commonEntity = this._dbContext.commonEntities.Where(d => d.IsUp);
 
            if(commonEntity == null) { return NotFound(); };

            // a clausula where recebe uma expressao lambda
            return Ok(commonEntity);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            var commonEntity = this._dbContext.commonEntities.Where(d => d.Id == id);

            if(commonEntity == null) { return NotFound(); }

            return Ok(commonEntity);
        }

        [HttpPost]
        public IActionResult Post(CommonEntity commonEntity)
        {
            this._dbContext.commonEntities.Add(commonEntity);

            return CreatedAtAction(nameof(GetByID), new { id = commonEntity.Id }, commonEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CommonEntity commonEntityInput)
        {
            var commonEntity = this._dbContext.commonEntities.SingleOrDefault(d => d.Id == id);

            if (commonEntity == null) { return NotFound(); }

            commonEntity.Update(commonEntityInput.Name, commonEntityInput.IpAddress, commonEntityInput.MacAddress, commonEntityInput.IsUp);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var commonEntity = this._dbContext.commonEntities.SingleOrDefault(d => d.Id == id);

            if (commonEntity == null) { return NotFound(); }

            commonEntity.Delete();

            return NoContent();
        }
    }
}
