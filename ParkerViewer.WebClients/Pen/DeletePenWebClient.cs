using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;

namespace ParkerViewer.WebClients.Pen
{
    public class DeletePenWebClient : ICommandHandler<DeletePen>
    {
        public void Execute(DeletePen command)
        {
            new WebClient().UploadString("http://localhost:5000/Pen/" +
                command.Id, "Delete","");
        }
    }
}