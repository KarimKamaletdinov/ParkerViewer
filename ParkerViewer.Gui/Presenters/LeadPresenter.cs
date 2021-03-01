using System.Collections.Generic;
using System.Linq;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands.Lead;
using ParkerViewer.Abstractions.Commands.Pen;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Gui.Views;

namespace ParkerViewer.Gui.Presenters
{
    public class LeadPresenter
    {
        public ICommandHandler<InsertLead> Insert;

        public ICommandHandler<UpdateLead> Update;

        public ICommandHandler<DeleteLead> Delete;

        public IQueryHandler<GetLeads, LeadDto[]> Get;

        public LeadPresenter(
            ICommandHandler<InsertLead> insert,
            ICommandHandler<UpdateLead> update,
            ICommandHandler<DeleteLead> delete,
            IQueryHandler<GetLeads, LeadDto[]> get)
        {
            Insert = insert;
            Update = update;
            Delete = delete;
            Get = get;
        }

        public void Register(ILeadView view)
        {
            view.UpdateView += UpdateView;
            view.InsertLead += InsertPen;
            view.UpdateLead += UpdatePen;
            view.DeleteLead += DeletePen;
        }

        private void UpdateView(ILeadView view)
        {
            view.Leads = new List<LeadDto>(Get.Execute(new GetLeads()).ToList());
        }

        private void InsertPen(LeadDto lead)
        {
            Insert.Execute(new InsertLead() { Lead = lead });
        }

        private void UpdatePen(LeadDto lead)
        {
            Update.Execute(new UpdateLead() { Lead = lead });
        }

        private void DeletePen(int leadId)
        {
            Delete.Execute(new DeleteLead() { LeadId = leadId });
        }
    }
}