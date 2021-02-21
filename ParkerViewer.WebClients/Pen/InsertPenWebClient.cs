using System;
using System.Net;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using RestSharp;

namespace ParkerViewer.WebClients.Pen
{
    public class InsertPenWebClient : ICommandHandler<InsertPenCommand>
    {
        private readonly string _baseUrl;

        public InsertPenWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(InsertPenCommand command)
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            
            client.UploadString($"{_baseUrl}/Pen", "POST",
               JsonConvert.SerializeObject(command.Pen));
        }
    }
}