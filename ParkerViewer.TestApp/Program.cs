using System;
using Newtonsoft.Json;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.WebClients.Pen;

namespace ParkerViewer.TestApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            new InsertPenWebClient().Execute(new InsertPen()
            {
                Pen = JsonConvert.
                    DeserializeObject<PenDto>(Console.ReadLine())
            });
            new UpdatePenWebClient().Execute(new UpdatePen()
            {
                Pen = JsonConvert.
                    DeserializeObject<PenDto>(Console.ReadLine())
            });
            new DeletePenWebClient().Execute(new DeletePen()
            {
                PenId = int.Parse(Console.ReadLine())
            });
            Console.WriteLine(JsonConvert.SerializeObject(
                new GetPensWebClient().Execute(new GetPens())));
        }
    }
}
