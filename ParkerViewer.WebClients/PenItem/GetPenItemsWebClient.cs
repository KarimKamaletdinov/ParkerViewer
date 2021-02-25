using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;

namespace ParkerViewer.WebClients.PenItem
{
    public class GetPenItemsWebClient : IQueryHandler<GetPenItems, PenItemDto[]>
    {
        private readonly string _baseUrl;

        public GetPenItemsWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public PenItemDto[] Execute(GetPenItems query)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var s = client.DownloadString($"{_baseUrl}/PenItem");
            Console.WriteLine(s);
            var result = JsonConvert.DeserializeObject<PenItemDto[]>(s);
            return result;
        }
    }
}