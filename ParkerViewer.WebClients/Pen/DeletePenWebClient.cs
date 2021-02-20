using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;

namespace ParkerViewer.WebClients.Pen
{
    public class DeletePenWebClient : ICommandHandler<DeletePen>
    {
        public void Execute(DeletePen command)
        {
            new WebClient().UploadString("https://localhost:44380/Pen/" +
                command.Id, "Delete","");
        }
    }
}