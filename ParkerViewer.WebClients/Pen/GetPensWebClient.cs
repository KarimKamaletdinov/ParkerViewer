using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.WebClients.Pen
{
    public class GetPensWebClient : IQueryHandler<GetPens, PenDto[]>
    {
        public PenDto[] Execute(GetPens query)
        {
            return JsonConvert.DeserializeObject<PenDto[]>(
                new WebClient().DownloadString("https://localhost:44380/Pen"));
        }
    }
}