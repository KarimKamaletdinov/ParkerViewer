using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class SqlUpdatePen : ICommandHandler<UpdatePenCommand>
    {
        public void Execute(UpdatePenCommand command)
        {
            new SqlPenRepository().Update(new Models.Pen()
            {
                Id = command.Pen.Id,
                Collection = command.Pen.Collection,
                DetailColor = command.Pen.DetailColor,
                Engraving = command.Pen.Engraving,
                ForMan = command.Pen.ForMan,
                ForWoman = command.Pen.ForWoman,
                GoldPen = command.Pen.GoldPen,
                Name = command.Pen.Name,
                Price = command.Pen.Price,
                WritingType = command.Pen.WritingType
            });
        }

    }
}