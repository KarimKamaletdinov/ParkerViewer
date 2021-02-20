using ParkerViewer.Abstractions;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class SqlDeletePen : ICommandHandler<DeletePenCommand>
    {
        public void Execute(DeletePenCommand command)
        {
            new SqlModelRepository().Delete(command.Id);
        }
    }
}