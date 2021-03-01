using System.Net;
using System.Text;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;

namespace ParkerViewer.WebClients.Lead
{
    public class DeleteLeadWebClient : ICommandHandler<DeleteLead>
    {
        private readonly string _baseUrl;

        public DeleteLeadWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(DeleteLead command)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.UploadString($"{_baseUrl}/Lead/{command.LeadId}", "DELETE");
        }
    }
}