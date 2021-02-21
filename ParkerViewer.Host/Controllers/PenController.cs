using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Handlers.Pen;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkerViewer.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PenController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PenDto> Get()
        {
            return new SqlGetPens().Execute(new GetPensQuery());
        }

        [HttpPost]
        public void Post([FromBody] PenDto pen)
        {
            new SqlInsertPen().Execute(new InsertPenCommand(){Pen = pen});
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PenDto pen)
        {
            pen.Id = id;
            new SqlUpdatePen().Execute(new UpdatePenCommand() { Pen = pen });
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new DeletePenHandler().Execute(new DeletePenCommand(){PenId = id});
        }
    }
}
