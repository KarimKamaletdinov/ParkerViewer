using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;

namespace ParkerViewer.WebClients.Lead
{
    public class InsertLeadWebClient : ICommandHandler<InsertLead>
    {
        private readonly string _baseUrl;

        public InsertLeadWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(InsertLead command)
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            client.Encoding = Encoding.UTF8;
            client.UploadString($"{_baseUrl}/Pen", "POST",
                JsonConvert.SerializeObject(command.Lead));
        }
    }
}