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
        public ICommandHandler<InsertPen> Insert;

        public ICommandHandler<UpdatePen> Update;

        public ICommandHandler<DeletePen> Delete;

        public IQueryHandler<GetPens, PenDto[]> Get;

        public PenPresenter(
            ICommandHandler<InsertPen> insert,
            ICommandHandler<UpdatePen> update,
            ICommandHandler<DeletePen> delete,
            IQueryHandler<GetPens, PenDto[]> get)
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
            view.Pens = new List<PenDto>(Get.Execute(new GetPens()).ToList());
        }

        private void InsertPen(PenDto pen)
        {
            Insert.Execute(new InsertPen(){Pen = pen});
        }

        private void UpdatePen(PenDto pen)
        {
            Update.Execute(new UpdatePen(){Pen = pen});
        }

        private void DeletePen(int penId)
        {
            Delete.Execute(new DeletePen(){PenId = penId});
        }
    }
}