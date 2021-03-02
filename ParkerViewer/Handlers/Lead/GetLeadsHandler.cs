using System.Linq;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Lead
{
    public class GetLeadsHandler : IQueryHandler<GetLeads, LeadDto[]>
    {
        private readonly SqlLeadRepository _repository;

        public GetLeadsHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public LeadDto[] Execute(GetLeads command)
        {
            return _repository.GetAll().Select(lead => new LeadDto()
            {
                Id = lead.Id,
                CustomerName = lead.CustomerName,
                Region = lead.Region,
                Sity = lead.Sity,
                Street = lead.Street,
                House = lead.House,
                Flat = lead.Flat,
                Agreed = lead.Agreed,
                Payed = lead.Payed,
                Delivered = lead.Deleivered,
                Pens = lead.Pens,
                CreatingDate = lead.CreatingDate,
                DeliveryDate = lead.DeliveryDate,
                DeliveryMethod = lead.DeliveryMethod,
                PayMethod = lead.PayMethod,
                Comment = lead.Comment
            }).ToArray();
        }
    }
}