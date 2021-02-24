using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ParkerViewer.Abstractions;
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
        private readonly IQueryHandler<GetPens, PenDto[]> _h1;

        private readonly ICommandHandler<InsertPen> _h2;

        private readonly ICommandHandler<UpdatePen> _h3;

        private readonly ICommandHandler<DeletePen> _h4;

        public PenController(IQueryHandler<GetPens, PenDto[]> h1, ICommandHandler<InsertPen> h2,
            ICommandHandler<UpdatePen> h3, ICommandHandler<DeletePen> h4)
        {
            _h1 = h1;
            _h2 = h2;
            _h3 = h3;
            _h4 = h4;
        }

        [HttpGet]
        public IEnumerable<PenDto> Get()
        {
            return _h1.Execute(new GetPens());
        }

        [HttpPost]
        public void Post([FromBody] PenDto pen)
        { 
            _h2.Execute(new InsertPen(){Pen = pen});
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PenDto pen)
        {
            pen.Id = id;
            _h3.Execute(new UpdatePen() { Pen = pen });
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _h4.Execute(new DeletePen(){PenId = id});
        }
    }
}
