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
                Broken = item.Broken
            });
        }

        public void Update(PenItem item)
        {
            new SqlConnection(_connectionString).Update(new SqlPenDto()
            {
                Id = pen.Id,
                Collection = pen.Collection,
                DetailColor = pen.DetailColor,
                Engraving = pen.Engraving,
                ForMan = pen.ForMan,
                ForWoman = pen.ForWoman,
                GoldPen = pen.GoldPen,
                Name = pen.Name,
                Price = pen.Price,
                WritingType = pen.WritingType
            });
        }

        public void Delete(int id)
        {
            new SqlConnection(_connectionString).Delete(new SqlPenDto() {Id = id});
        }

        public PenItem[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlPenDto>("SELECT * FROM Pens");

            var result = new List<Pen>();

            foreach (var pen in a)
            {
                result.Add(new Pen(){      
                        Id = pen.Id,
                        Collection = pen.Collection,
                        DetailColor = pen.DetailColor,
                        Engraving = pen.Engraving,
                        ForMan = pen.ForMan,
                        ForWoman = pen.ForWoman,
                        GoldPen = pen.GoldPen,
                        Name = pen.Name,
                        Price = pen.Price,
                        WritingType = pen.WritingType
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
            public bool Broken { get; set; }
        }
    }
}