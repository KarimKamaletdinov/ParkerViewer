using System.Collections.Generic;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Model
{
    public class SqlGetModels : IQueryHandler<GetModelsQuery, ModelDto[]>
    {
        public ModelDto[] Execute(GetModelsQuery query)
        {
            var models = new List<ModelDto>();

            foreach (var model in new SqlModelRepository().GetAll())
            {
               models.Add(new ModelDto()
               {
                   Id = model.Id,
                   CollectionId = model.CollectionId,
                   DetailColor = model.DetailColor,
                   Engraving = model.Engraving,
                   ForMan = model.ForMan,
                   ForWoman = model.ForWoman,
                   GoldPen = model.GoldPen,
                   Name = model.Name,
                   Price = model.Price,
                   WritingType = model.WritingType
               });
            }

            return models.ToArray();
        }
    }
}