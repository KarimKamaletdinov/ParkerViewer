using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.WebClients.Pen
{
    public class HttpGetPens : IQueryHandler<GetPensQuery, PenDto[]>
    {
        public PenDto[] Execute(GetPensQuery query)
        {
            return JsonConvert.DeserializeObject<PenDto[]>(
                new WebClient().DownloadString("https://localhost:44380/Pen"));
        }

    }
}