using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;

namespace ParkerViewer.WebClients.Pen
{
    public class UpdatePenWebClient : ICommandHandler<PenCommand>
    {
        public void Execute(PenCommand command)
        {
            new WebClient().UploadString("https://localhost:5000/Pen/" + 
                command.PenDto.Id, "Put",
                JsonConvert.SerializeObject(command.PenDto));
        }

    }
}