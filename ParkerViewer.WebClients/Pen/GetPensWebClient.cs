using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

namespace ParkerViewer.WebClients.Pen
{
    public class GetPensWebClient : IQueryHandler<GetPens, PenDto[]>
    {
        private readonly string _baseUrl;

        public GetPensWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public PenDto[] Execute(GetPens query)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var s = client.DownloadString($"{_baseUrl}/Pen");
            Console.WriteLine(s);
            var result = JsonConvert.DeserializeObject<PenDto[]>(s);
            return result;
        }
    }
}