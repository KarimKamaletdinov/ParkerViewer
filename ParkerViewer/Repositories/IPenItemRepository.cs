using ParkerViewer.Models;

namespace ParkerViewer.Repositories
{
    public interface IPenItemRepository
    {
        void Insert(PenItem item);

        void Update(PenItem item);

        void Delete(int id);

        PenItem[] GetAll();
    }
}