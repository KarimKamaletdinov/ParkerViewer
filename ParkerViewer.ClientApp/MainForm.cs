using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkerViewer.Gui.Presenters;
using ParkerViewer.Handlers.Pen;
using ParkerViewer.LeadsPage;
using ParkerViewer.PenItemsPage;
using ParkerViewer.WebClients.Lead;
using ParkerViewer.WebClients.Pen;
using ParkerViewer.WebClients.PenItem;

namespace ParkerViewer.ClientApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var p = new PenPresenter(new InsertPenWebClient(), new UpdatePenWebClient(),
                new DeletePenWebClient(), new GetPensWebClient());
            var control = new PensPage.PensPageControl();
            p.Register(control);
            control.Parent = splitContainer1.Panel1;
            control.Dock = DockStyle.Fill;
            control.UpdateElement();

            var control2 = new PenItemsPageControl();
            control2.Models = control.Pens.Select(x => (x.Name, x.Id)).ToArray();
            var p2 = new PenItemPresenter(new InsertPenItemWebClient(), new UpdatePenItemWebClient(),
                new DeletePenItemWebClient(), new GetPenItemsWebClient());
            p2.Register(control2);
            control2.Parent = splitContainer2.Panel1;
            control2.Dock = DockStyle.Fill;
            control2.UpdateElement();

            var control3 = new LeadsPageControl();
            var p3 = new LeadPresenter(new InsertLeadWebClient(), new UpdateLeadWebClient(),
                new DeleteLeadWebClient(), new GetLeadsWebClient());
            p3.Register(control3);
            control3.Parent = splitContainer2.Panel2;
            control3.Dock = DockStyle.Fill;
            control3.UpdateElement();
        }
    }
}
