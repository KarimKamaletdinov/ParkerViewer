using System;
using Newtonsoft.Json;
using ParkerViewer.WebClients.Pen;

namespace ParkerViewer.TestApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(JsonConvert.SerializeObject(
                new GetPensWebClient().Execute(new GetPens())));
        }
    }
}
