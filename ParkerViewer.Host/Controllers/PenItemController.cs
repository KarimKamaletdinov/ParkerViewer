using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ParkerViewer.Abstractions.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkerViewer.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PenItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PenItemDto> Get()
        {
            
        }

        [HttpPost]
        public void Post([FromBody] PenItemDto value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PenItemDto value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
