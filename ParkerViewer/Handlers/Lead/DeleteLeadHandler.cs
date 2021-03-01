using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Lead
{
    public class DeleteLeadHandler : ICommandHandler<DeleteLead>
    {
        private readonly SqlLeadRepository _repository;

        public DeleteLeadHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteLead command)
        {
            _repository.Delete(command.LeadId);
        }
    }
}