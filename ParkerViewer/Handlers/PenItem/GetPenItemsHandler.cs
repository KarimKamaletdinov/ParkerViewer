using System.Collections.Generic;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.PenItem
{
    public class GetPenItemsHandler : IQueryHandler<GetPenItems, PenItemDto[]>
    {
        private readonly SqlPenItemRepository _repository;

        public GetPenItemsHandler(SqlPenItemRepository repository)
        {
            _repository = repository;
        }

        public PenItemDto[] Execute(GetPenItems query)
        {
            var result = new List<PenItemDto>();
            var pens = _repository.GetAll();

            foreach (var pen in pens)
            {
               result.Add(new PenItemDto()
               {
                   Id = pen.Id,
                   Engraving = pen.Engraving,
                   Name = pen.Name,
                   ModelId = pen.ModelId,
                   Broken = pen.Broken
               });
            }

            return result.ToArray();
        }
    }
}