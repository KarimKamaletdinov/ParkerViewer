using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.PenItem
{
    public class DeletePenItemHandler : ICommandHandler<DeletePen>
    {
        private readonly SqlPenRepository _repository;

        public DeletePenItemHandler(SqlPenRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeletePen command)
        {
            _repository.Delete(command.PenId);
        }
    }
}