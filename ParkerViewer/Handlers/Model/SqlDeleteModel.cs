using ParkerViewer.Abstractions;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Model
{
    public class SqlDeleteModel : ICommandHandler<ModelCommand>
    {
        public void Execute(ModelCommand command)
        {
            new SqlModelRepository().Delete(new Behaviours.Model()
            {
                Id = command.ModelDto.Id,
                CollectionId = command.ModelDto.CollectionId,
                DetailColor = command.ModelDto.DetailColor,
                Engraving = command.ModelDto.Engraving,
                ForMan = command.ModelDto.ForMan,
                ForWoman = command.ModelDto.ForWoman,
                GoldPen = command.ModelDto.GoldPen,
                Name = command.ModelDto.Name,
                Price = command.ModelDto.Price,
                WritingType = command.ModelDto.WritingType
            });
        }

    }
}