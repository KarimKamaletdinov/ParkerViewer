using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Commands.PenItem;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.PenItem
{
    public class DeletePenItemHandler : ICommandHandler<DeletePenItem>
    {
        private readonly SqlPenItemRepository _repository;

        public DeletePenItemHandler(SqlPenItemRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeletePenItem command)
        {
            _repository.Delete(command.PenItemId);
        }
    }
}