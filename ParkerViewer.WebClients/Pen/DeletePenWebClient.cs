using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;

namespace ParkerViewer.WebClients.Pen
{
    public class DeletePenWebClient : ICommandHandler<DeletePenCommand>
    {
        private readonly string _baseUrl;

        public DeletePenWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(DeletePenCommand command)
        {
            var client = new WebClient();
            new WebClient().UploadString($"{_baseUrl}/Pen/{command.PenId}", "DELETE", "");
        }
    }
}