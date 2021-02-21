using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class DeletePenHandler : ICommandHandler<DeletePenCommand>
    {
        public void Execute(DeletePenCommand command)
        {
            new SqlPenRepository().Delete(command.Id);
        }
    }
}