using Dapper;
using ParkerViewer.Behaviours;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace ParkerViewer.Repositories
{
    public class SqlModelRepository : IModelRepository
    {
        private readonly string _connectionString;

        public SqlModelRepository()
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
            new SqlConnection(_connectionString).Insert(pen);
        }

        public void Update(Pen pen)
        {
            new SqlConnection(_connectionString).Update(pen);
        }

        public void Delete(int id)
        {
            new SqlConnection(_connectionString).Delete(new Pen() {Id = id});
        }

        public Pen[] GetAll()
        {
            return new SqlConnection(_connectionString).Query<Pen>("SELECT * FROM Models")
                .ToArray();
        }
    }
}