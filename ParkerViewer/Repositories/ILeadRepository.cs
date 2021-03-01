using ParkerViewer.Models;

namespace ParkerViewer.Repositories
{
    public interface ILeadRepository
    {
        void Insert(Lead lead);

        void Update(Lead lead);

        void Delete(int id);

        Lead[] GetAll();
    }
}