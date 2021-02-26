using System;
using System.Windows.Forms;
using ParkerViewer.Gui.Presenters;
using ParkerViewer.WebClients.PenItem;

namespace ParkerViewer.PenItemsPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var control = new PenItemsPageControl();
            var p = new PenItemPresenter(new InsertPenItemWebClient(), new UpdatePenItemWebClient(),
                new DeletePenItemWebClient(), new GetPenItemsWebClient());
            p.Register(control);
            control.UpdateElement();
            control.Dock = DockStyle.Fill;
            Controls.Add(control);
        }
    }
}
