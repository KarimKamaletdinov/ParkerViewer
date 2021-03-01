using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

namespace ParkerViewer.WebClients.Lead
{
    public class GetLeadsWebClient : IQueryHandler<GetLeads, LeadDto[]>
    {
        private readonly string _baseUrl;

        public GetLeadsWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public LeadDto[] Execute(GetLeads query)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var s = client.DownloadString($"{_baseUrl}/Lead");
            var result = JsonConvert.DeserializeObject<LeadDto[]>(s);
            return result;
        }
    }
}