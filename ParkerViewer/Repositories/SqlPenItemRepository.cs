using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using ParkerViewer.Models;

namespace ParkerViewer.Repositories
{
    public class SqlPenItemRepository : IPenItemRepository
    {
        private readonly string _connectionString;

        public SqlPenItemRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "Parker",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }

        public void Insert(PenItem item)
        {
            new SqlConnection(_connectionString).Insert(new SqlPenItemDto()
            {
                Id = item.Id,
                Engraving = item.Engraving,
                Name = item.Name,
                ModelId = item.ModelId,
                Broken = item.Broken,
                Stock = item.Stock
            });
        }

        public void Update(PenItem item)
        {
            new SqlConnection(_connectionString).Update(new SqlPenItemDto()
            {
                Id = item.Id,
                Engraving = item.Engraving,
                Name = item.Name,
                ModelId = item.ModelId,
                Broken = item.Broken,
                Stock = item.Stock
            });
        }

        public void Delete(int id)
        {
            new SqlConnection(_connectionString).Delete(new SqlPenItemDto() {Id = id});
        }

        public PenItem[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlPenItemDto>("SELECT * FROM PenItems");

            var result = new List<PenItem>();

            foreach (var pen in a)
            {
                result.Add(new PenItem(){
                    Id = pen.Id,
                    Engraving = pen.Engraving,
                    Name = pen.Name,
                    ModelId = pen.ModelId,
                    Broken = pen.Broken,
                    Stock = pen.Stock
                });
            }

            return result.ToArray();
        }

        [Table("PenItems")]
        private class SqlPenItemDto
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public int ModelId { get; set; }
            public string Engraving { get; set; }
            public int Stock { get; set; }
            public bool Broken { get; set; }
        }
    }
}