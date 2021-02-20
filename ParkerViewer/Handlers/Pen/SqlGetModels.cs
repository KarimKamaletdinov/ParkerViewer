﻿using System.Collections.Generic;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class SqlGetModels : IQueryHandler<GetPensQuery, PenDto[]>
    {
        public PenDto[] Execute(GetPensQuery query)
        {
            var models = new List<PenDto>();

            foreach (var model in new SqlModelRepository().GetAll())
            {
               models.Add(new PenDto()
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