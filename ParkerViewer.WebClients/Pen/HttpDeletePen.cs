using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;

namespace ParkerViewer.WebClients.Pen
{
    public class HttpDeletePen : ICommandHandler<DeletePenCommand>
    {
        public void Execute(DeletePenCommand command)
        {
            new WebClient().UploadString("https://localhost:44380/Pen/" +
                command.Id, "Delete","");
        }

    }
}