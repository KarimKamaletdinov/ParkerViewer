using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;

namespace ParkerViewer.WebClients.Pen
{
    public class UpdatePenWebClient : ICommandHandler<UpdatePenCommand>
    {
        private readonly string _baseUrl;

        public UpdatePenWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(UpdatePenCommand command)
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            client.UploadString($"{_baseUrl}/Pen/{command.Pen.Id}", "Put",
                JsonConvert.SerializeObject(command.Pen));
        }

    }
}