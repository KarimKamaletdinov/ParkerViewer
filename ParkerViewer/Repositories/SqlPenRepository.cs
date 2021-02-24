using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using ParkerViewer.Models;

namespace ParkerViewer.Repositories
{
    public class SqlPenRepository : IPenRepository
    {
        private readonly string _connectionString;

        public SqlPenRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "Parker",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }

        public void Insert(Pen pen)
        {
            new SqlConnection(_connectionString).Insert(new SqlPenDto()
            {
                Id = pen.Id,
                CollectionId = pen.Collection,
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

        public void Update(Pen pen)
        {
            new SqlConnection(_connectionString).Update(new SqlPenDto()
            {
                Id = pen.Id,
                CollectionId = pen.Collection,
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

        public Pen[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlPenDto>("SELECT * FROM Models");

            var result = new List<Pen>();

            foreach (var pen in a)
            {
                result.Add(new Pen(){      
                        Id = pen.Id,
                        Collection = pen.CollectionId,
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

        [Table("Pens")]
        private class SqlPenDto
        {
            [Key]
            public int Id { get; set; }
            public string CollectionId { get; set; }
            public int Price { get; set; }
            public string Name { get; set; }
            public string DetailColor { get; set; }
            public string WritingType { get; set; }
            public bool GoldPen { get; set; }
            public bool Engraving { get; set; }
            public bool ForMan { get; set; }
            public bool ForWoman { get; set; }
        }
    }
}