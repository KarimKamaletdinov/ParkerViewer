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
using ParkerViewer.WebClients.Pen;

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
            control.Parent = this;
            control.UpdateElement();
        }
    }
}
