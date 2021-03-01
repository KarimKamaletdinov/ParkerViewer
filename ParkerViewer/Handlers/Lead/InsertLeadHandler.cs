using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Lead
{
    public class InsertLeadHandler : ICommandHandler<InsertLead>
    {
        private readonly SqlLeadRepository _repository;

        public InsertLeadHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public void Execute(InsertLead command)
        {
            _repository.Insert(new Models.Lead()
            {
                Id = command.Lead.Id,
                CustomerName = command.Lead.CustomerName,
                Region = command.Lead.Region,
                Sity = command.Lead.Sity,
                Street = command.Lead.Street,
                House = command.Lead.House,
                Flat = command.Lead.Flat,
                Agreed = command.Lead.Agreed,
                Payed = command.Lead.Payed,
                Deleivered = command.Lead.Deleivered,
                Pens = command.Lead.Pens,
                CreatingDate = command.Lead.CreatingDate,
                DeliveryDate = command.Lead.DeliveryDate,
                DeliveryMethod = command.Lead.DeliveryMethod,
                PayMethod = command.Lead.PayMethod,
                Comment = command.Lead.Comment
            });
        }
    }
}