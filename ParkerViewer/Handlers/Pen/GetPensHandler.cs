using System.Collections.Generic;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class GetPensHandler : IQueryHandler<GetPens, PenDto[]>
    {
        private readonly SqlPenRepository _repository;

        public GetPensHandler(SqlPenRepository repository)
        {
            _repository = repository;
        }

        public PenDto[] Execute(GetPens query)
        {
            var result = new List<PenDto>();
            var pens = _repository.GetAll();

            foreach (var pen in pens)
            {
               result.Add(new PenDto()
               {
                   Id = pen.Id,
                   Collection = pen.Collection,
                   DetailColor = pen.DetailColor,
                   Engraving = pen.Engraving,
                   ForMan = pen.ForMan,
                   ForWoman = pen.ForWoman,
                   GoldPen = pen.GoldPen,
                   Name = pen.Name,
                   Price = pen.Price,
                   WritingType = pen.WritingType
               });
            }

            return result.ToArray();
        }
    }
}