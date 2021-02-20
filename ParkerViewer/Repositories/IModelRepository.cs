using ParkerViewer.Behaviours;

namespace ParkerViewer.Repositories
{
    public interface IModelRepository
    {
        void Insert(Pen pen);

        void Update(Pen pen);

        void Delete(int id);

        Pen[] GetAll();
    }
}