using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class SqlInsertPen : ICommandHandler<InsertPenCommand>
    {
        public void Execute(InsertPenCommand command)
        {
            new SqlPenRepository().Insert(new Models.Pen()
            {
                Id = command.Pen.Id,
                CollectionId = command.Pen.CollectionId,
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
