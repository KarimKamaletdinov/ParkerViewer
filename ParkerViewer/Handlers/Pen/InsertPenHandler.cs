﻿using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Commands.Pen;
using ParkerViewer.Repositories;

namespace ParkerViewer.Handlers.Pen
{
    public class InsertPenHandler : ICommandHandler<InsertPen>
    {
        private readonly SqlPenRepository _repository;

        public InsertPenHandler(SqlPenRepository repository)
        {
            _repository = repository;
        }

        public void Execute(InsertPen command)
        {
            _repository.Insert(new Models.Pen()
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
