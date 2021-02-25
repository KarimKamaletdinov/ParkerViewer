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
using ParkerViewer.PenItemsPage;
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
            var p2 = new PenItemPresenter(new InsertPenItemWebClient(), new UpdatePenItemWebClient(),
                new DeletePenItemWebClient(), new GetPenItemsWebClient());
            p2.Register(control2);
            control2.Parent = splitContainer1.Panel2;
            control2.Dock = DockStyle.Fill;
            control2.UpdateElement();
        }
    }
}
