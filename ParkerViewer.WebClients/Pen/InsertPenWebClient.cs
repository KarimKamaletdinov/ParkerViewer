using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Commands.Pen;
using RestSharp;

namespace ParkerViewer.WebClients.Pen
{
    public class InsertPenWebClient : ICommandHandler<InsertPen>
    {
        private readonly string _baseUrl;

        public InsertPenWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(InsertPen command)
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            client.Encoding = Encoding.UTF8;
            client.UploadString($"{_baseUrl}/Pen", "POST",
               JsonConvert.SerializeObject(command.Pen));
        }
    }
}