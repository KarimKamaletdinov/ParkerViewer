using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;

namespace ParkerViewer.WebClients.Pen
{
    public class InsertPenWebClient : ICommandHandler<PenCommand>
    {
        public void Execute(PenCommand command)
        {
            new WebClient().UploadString("https://localhost:44380/Pen", "Post",
                JsonConvert.SerializeObject(command.PenDto));
        }
    }
}