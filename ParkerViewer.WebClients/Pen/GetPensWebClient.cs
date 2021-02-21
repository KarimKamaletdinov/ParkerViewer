using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

namespace ParkerViewer.WebClients.Pen
{
    public class GetPensWebClient : IQueryHandler<GetPensQuery, PenDto[]>
    {
        private readonly string _baseUrl;

        public GetPensWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public PenDto[] Execute(GetPensQuery query)
        {
            return JsonConvert.DeserializeObject<PenDto[]>(
                new WebClient().DownloadString($"{_baseUrl}/Pen"));
        }
    }
}