using ParkerViewer.Behaviours;

namespace ParkerViewer.Repositories
{
    public interface IModelRepository
    {
        void Insert(Model model);

        void Update(Model model);

        void Delete(Model model);

        Model[] GetAll();
    }
}