using System.Collections.Generic;
using System.Linq;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Gui.Views;

namespace ParkerViewer.Gui.Presenters
{
    public class PenItemPresenter
    {
        public ICommandHandler<InsertPenItem> Insert;

        public ICommandHandler<UpdatePenItem> Update;

        public ICommandHandler<DeletePenItem> Delete;

        public IQueryHandler<GetPenItems, PenItemDto[]> Get;

        public PenItemPresenter(
            ICommandHandler<InsertPenItem> insert,
            ICommandHandler<UpdatePenItem> update,
            ICommandHandler<DeletePenItem> delete,
            IQueryHandler<GetPenItems, PenItemDto[]> get)
        {
            Insert = insert;
            Update = update;
            Delete = delete;
            Get = get;
        }

        public void Register(IPenItemView view)
        {
            view.UpdateView += UpdateView;
            view.InsertPenItem += InsertPen;
            view.UpdatePenItem += UpdatePen;
            view.DeletePenItem += DeletePen;
        }

        private void UpdateView(IPenItemView view)
        {
            view.PenItems = new List<PenItemDto>(Get.Execute(new GetPenItems()).ToList());
        }

        private void InsertPen(PenItemDto pen)
        {
            Insert.Execute(new InsertPenItem(){ PenItem = pen});
        }

        private void UpdatePen(PenItemDto pen)
        {
            Update.Execute(new UpdatePenItem(){ PenItem = pen});
        }

        private void DeletePen(int penId)
        {
            Delete.Execute(new DeletePenItem(){ PenItemId = penId});
        }
    }
}