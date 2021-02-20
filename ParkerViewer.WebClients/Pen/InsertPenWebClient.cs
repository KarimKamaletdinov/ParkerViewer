using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;

namespace ParkerViewer.WebClients.Pen
{
    public class InsertPenWebClient : ICommandHandler<PenCommand>
    {
        public void Execute(PenCommand command)
        {
            new WebClient().UploadString("http://localhost:5000/Pen", "POST",
                JsonConvert.SerializeObject(command.PenDto));
        }
    }
}