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
using ParkerViewer.WebClients.Lead;

namespace ParkerViewer.LeadsPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var p = new LeadPresenter(new InsertLeadWebClient(), new UpdateLeadWebClient(),
                new DeleteLeadWebClient(), new GetLeadsWebClient());
            p.Register(leadsPageControl1);
            leadsPageControl1.UpdateElement();
        }
    }
}
