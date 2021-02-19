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

        public void Insert(Model model)
        {
            new SqlConnection(_connectionString).Insert(model);
        }

        public void Update(Model model)
        {
            new SqlConnection(_connectionString).Update(model);
        }

        public void Delete(Model model)
        {
            new SqlConnection(_connectionString).Delete(model);
        }

        public Model[] GetAll()
        {
            return new SqlConnection(_connectionString).Query<Model>("SELECT * FROM Models")
                .ToArray();
        }
    }
}