using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

namespace ParkerViewer.Handlers.Lead
{
    public class GetLeadsHandler : IQueryHandler<GetLeads, LeadDto[]>
    {
        public LeadDto[] Execute(GetLeads command)
        {
            throw new System.NotImplementedException();
        }
    }
}