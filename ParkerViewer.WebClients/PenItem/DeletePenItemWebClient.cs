using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Commands.PenItem;

namespace ParkerViewer.WebClients.PenItem
{
    public class DeletePenItemWebClient : ICommandHandler<DeletePenItem>
    {
        private readonly string _baseUrl;

        public DeletePenItemWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(DeletePenItem command)
        {
            var client = new WebClient();
            new WebClient().UploadString($"{_baseUrl}/PenItem/{command.PenItemId}", "DELETE", "");
        }
    }
}