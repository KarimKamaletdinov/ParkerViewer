using ParkerViewer.Models;

namespace ParkerViewer.Repositories
{
    public interface IPenRepository
    {
        void Insert(Pen pen);

        void Update(Pen pen);

        void Delete(int id);

        Pen[] GetAll();
    }
}