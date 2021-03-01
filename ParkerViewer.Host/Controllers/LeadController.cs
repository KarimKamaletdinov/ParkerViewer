using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

namespace ParkerViewer.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly IQueryHandler<GetLeads, LeadDto[]> _h1;

        private readonly ICommandHandler<InsertLead> _h2;

        private readonly ICommandHandler<UpdateLead> _h3;

        private readonly ICommandHandler<DeleteLead> _h4;

        public LeadController(IQueryHandler<GetLeads, LeadDto[]> h1, ICommandHandler<InsertLead> h2,
            ICommandHandler<UpdateLead> h3, ICommandHandler<DeleteLead> h4)
        {
            _h1 = h1;
            _h2 = h2;
            _h3 = h3;
            _h4 = h4;
        }

        [HttpGet]
        public IEnumerable<LeadDto> Get()
        {
            return _h1.Execute(new GetLeads());
        }

        [HttpPost]
        public void Post([FromBody] LeadDto lead)
        {
            _h2.Execute(new InsertLead() { Lead = lead });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LeadDto lead)
        {
            lead.Id = id;
            _h3.Execute(new UpdateLead() { Lead = lead });
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _h4.Execute(new DeleteLead() { LeadId = id });
        }
    }
}