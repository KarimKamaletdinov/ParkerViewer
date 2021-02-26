using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Commands.PenItem;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkerViewer.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PenItemController : ControllerBase
    {
        private readonly IQueryHandler<GetPenItems, PenItemDto[]> _h1;

        private readonly ICommandHandler<InsertPenItem> _h2;

        private readonly ICommandHandler<UpdatePenItem> _h3;

        private readonly ICommandHandler<DeletePenItem> _h4;

        public PenItemController(IQueryHandler<GetPenItems, PenItemDto[]> h1, ICommandHandler<InsertPenItem> 
                h2, ICommandHandler<UpdatePenItem> h3, ICommandHandler<DeletePenItem> h4)
        {
            _h1 = h1;
            _h2 = h2;
            _h3 = h3;
            _h4 = h4;
        }

        [HttpGet]
        public IEnumerable<PenItemDto> Get()
        {
            return _h1.Execute(new GetPenItems());
        }

        [HttpPost]
        public void Post([FromBody] PenItemDto value)
        {
            _h2.Execute(new InsertPenItem() {PenItem = value});
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PenItemDto value)
        {
            value.Id = id;

            _h3.Execute(new UpdatePenItem() { PenItem = value });
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _h4.Execute(new DeletePenItem(){PenItemId = id});
        }
    }
}
