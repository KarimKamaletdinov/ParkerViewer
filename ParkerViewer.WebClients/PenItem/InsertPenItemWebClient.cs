using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Commands.PenItem;
using RestSharp;

namespace ParkerViewer.WebClients.PenItem
{
    public class InsertPenItemWebClient : ICommandHandler<InsertPenItem>
    {
        private readonly string _baseUrl;

        public InsertPenItemWebClient(string baseUrl = "http://localhost:5000")
        {
            _baseUrl = baseUrl;
        }

        public void Execute(InsertPenItem command)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("content-type", "application/json");
            client.UploadString($"{_baseUrl}/PenItem", "POST",
               JsonConvert.SerializeObject(command.PenItem));
        }
    }
}