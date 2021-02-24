using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class DeletePenHandler : ICommandHandler<DeletePen>
    {
        private readonly SqlPenRepository _repository;

        public DeletePenHandler(SqlPenRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeletePen command)
        {
            _repository.Delete(command.PenId);
        }
    }
}