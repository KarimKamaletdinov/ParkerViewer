using ParkerViewer.Abstractions;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class SqlDeletePen : ICommandHandler<DeletePen>
    {
        public void Execute(DeletePen command)
        {
            new SqlPenRepository().Delete(command.Id);
        }
    }
}