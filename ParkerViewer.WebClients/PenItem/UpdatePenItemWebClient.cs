using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;

namespace ParkerViewer.WebClients.PenItem
{
    public class UpdatePenItemWebClient : ICommandHandler<UpdatePenItem>
    {
        private readonly string _baseUrl;

        public UpdatePenItemWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(UpdatePenItem command)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("content-type", "application/json");
            client.UploadString($"{_baseUrl}/PenItem/{command.PenItem.Id}", "PUT",
                JsonConvert.SerializeObject(command.PenItem));
        }

    }
}