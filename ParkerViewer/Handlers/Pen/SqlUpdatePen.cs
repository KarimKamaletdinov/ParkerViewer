using ParkerViewer.Abstractions;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class SqlUpdatePen : ICommandHandler<PenCommand>
    {
        public void Execute(PenCommand command)
        {
            new SqlPenRepository().Update(new Behaviours.Pen()
            {
                Id = command.PenDto.Id,
                CollectionId = command.PenDto.CollectionId,
                DetailColor = command.PenDto.DetailColor,
                Engraving = command.PenDto.Engraving,
                ForMan = command.PenDto.ForMan,
                ForWoman = command.PenDto.ForWoman,
                GoldPen = command.PenDto.GoldPen,
                Name = command.PenDto.Name,
                Price = command.PenDto.Price,
                WritingType = command.PenDto.WritingType
            });
        }

    }
}