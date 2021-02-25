using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.PenItem
{
    public class InsertPenItemHandler : ICommandHandler<InsertPenItem>
    {
        private readonly SqlPenItemRepository _repository;

        public InsertPenItemHandler(SqlPenItemRepository repository)
        {
            _repository = repository;
        }

        public void Execute(InsertPenItem command)
        {
            _repository.Insert(new Models.PenItem()
            {
                Id = command.PenItem.Id,
                Engraving = command.PenItem.Engraving,
                Name = command.PenItem.Name,
                ModelId = command.PenItem.ModelId,
                Broken = command.PenItem.Broken,
                Stock = command.PenItem.Stock
            });
        }
    }
}
