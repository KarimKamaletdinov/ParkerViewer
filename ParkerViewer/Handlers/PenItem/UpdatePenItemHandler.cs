using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.PenItem
{
    public class UpdatePenItemHandler : ICommandHandler<UpdatePenItem>
    {
        private readonly SqlPenItemRepository _repository;

        public UpdatePenItemHandler(SqlPenItemRepository repository)
        {
            _repository = repository;
        }

        public void Execute(UpdatePenItem command)
        {
            _repository.Update(new Models.PenItem()
            {
                Id = command.PenItem.Id,
                Engraving = command.PenItem.Engraving,
                Name = command.PenItem.Name,
                ModelId = command.PenItem.ModelId,
                Broken = command.PenItem.Broken
            });
        }
    }
}