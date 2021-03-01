using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;

namespace ParkerViewer.WebClients.Lead
{
    public class UpdateLeadWebClient : ICommandHandler<UpdateLead>
    {
        private readonly string _baseUrl;

        public UpdateLeadWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(UpdateLead command)
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            client.Encoding = Encoding.UTF8;
            client.UploadString($"{_baseUrl}/Pen/{command.Lead.Id}", "PUT",
                JsonConvert.SerializeObject(command.Lead));
        }
    }
}