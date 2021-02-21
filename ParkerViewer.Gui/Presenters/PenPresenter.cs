using System.Collections.Generic;
using System.Linq;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Gui.Views;

namespace ParkerViewer.Gui.Presenters
{
    public class PenPresenter
    {
        public ICommandHandler<InsertPenCommand> Insert;

        public ICommandHandler<UpdatePenCommand> Update;

        public ICommandHandler<DeletePenCommand> Delete;

        public IQueryHandler<GetPensQuery, PenDto[]> Get;

        public PenPresenter(
            ICommandHandler<InsertPenCommand> insert,
            ICommandHandler<UpdatePenCommand> update,
            ICommandHandler<DeletePenCommand> delete,
            IQueryHandler<GetPensQuery, PenDto[]> get)
        {
            Insert = insert;
            Update = update;
            Delete = delete;
            Get = get;
        }

        public void Register(IPenView view)
        {
            view.UpdateView += UpdateView;
            view.InsertPen += InsertPen;
            view.UpdatePen += UpdatePen;
            view.DeletePen += DeletePen;
        }

        private void UpdateView(IPenView view)
        {
            view.Pens = new List<PenDto>(Get.Execute(new GetPensQuery()).ToList());
        }

        private void InsertPen(PenDto pen)
        {
            Insert.Execute(new InsertPenCommand(){Pen = pen});
        }

        private void UpdatePen(PenDto pen)
        {
            Update.Execute(new UpdatePenCommand(){Pen = pen});
        }

        private void DeletePen(int penId)
        {
            Delete.Execute(new DeletePenCommand(){PenId = penId});
        }
    }
}