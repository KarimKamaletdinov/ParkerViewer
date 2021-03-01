using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using ParkerViewer.Models;

namespace ParkerViewer.Repositories
{
    public class SqlLeadRepository : ILeadRepository
    {
        private readonly string _connectionString;
        public SqlLeadRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "Parker",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }
        public void Insert(Lead lead)
        {
            new SqlConnection().Insert(new SqlLeadDto
            {
                Id = lead.Id,
                CustomerName = lead.CustomerName,
                Region = lead.Region,
                Sity = lead.Sity,
                Street = lead.Street,
                House = lead.House,
                Flat = lead.Flat,
                Agreed = lead.Agreed,
                Payed = lead.Payed,
                Deleivered = lead.Deleivered,
                Pens = string.Join(",", lead.Pens),
                CreatingDate = lead.CreatingDate,
                DeliveryDate = lead.DeliveryDate,
                DeliveryMethod = lead.DeliveryMethod,
                PayMethod = lead.PayMethod,
                Comment = lead.Comment
            });
        }

        public void Update(Lead lead)
        {
            new SqlConnection().Update(new SqlLeadDto
            {
                Id = lead.Id,
                CustomerName = lead.CustomerName,
                Region = lead.Region,
                Sity = lead.Sity,
                Street = lead.Street,
                House = lead.House,
                Flat = lead.Flat,
                Agreed = lead.Agreed,
                Payed = lead.Payed,
                Deleivered = lead.Deleivered,
                Pens = string.Join(",", lead.Pens),
                CreatingDate = lead.CreatingDate,
                DeliveryDate = lead.DeliveryDate,
                DeliveryMethod = lead.DeliveryMethod,
                PayMethod = lead.PayMethod,
                Comment = lead.Comment
            });
        }

        public void Delete(int id)
        {
            new SqlConnection().Delete(new SqlLeadDto() {Id = id});
        }

        public Lead[] GetAll()
        {
            var leads = new SqlConnection().Query<SqlLeadDto>("SELECT * FROM Leads");

            var result = leads.Select(lead => new Lead()
                {
                    Id = lead.Id,
                    CustomerName = lead.CustomerName,
                    Region = lead.Region,
                    Sity = lead.Sity,
                    Street = lead.Street,
                    House = lead.House,
                    Flat = lead.Flat,
                    Agreed = lead.Agreed,
                    Payed = lead.Payed,
                    Deleivered = lead.Deleivered,
                    Pens = lead.Pens.Split(',').Select(int.Parse).ToArray(),
                    CreatingDate = lead.CreatingDate,
                    DeliveryDate = lead.DeliveryDate,
                    DeliveryMethod = lead.DeliveryMethod,
                    PayMethod = lead.PayMethod,
                    Comment = lead.Comment
                }).ToList();

            return result.ToArray();
        }

        [Table("Leads")]
        private class SqlLeadDto
        {
            public int Id { get; set; }

            public string CustomerName { get; set; }

            public string Region { get; set; }

            public string Sity { get; set; }

            public string Street { get; set; }

            public string House { get; set; }

            public string Flat { get; set; }

            public bool Agreed { get; set; }

            public bool Payed { get; set; }

            public bool Deleivered { get; set; }

            public string Pens { get; set; }

            public DateTime CreatingDate { get; set; }

            public DateTime DeliveryDate { get; set; }

            public string DeliveryMethod { get; set; }

            public string PayMethod { get; set; }

            public string Comment { get; set; }
        }
    }
}