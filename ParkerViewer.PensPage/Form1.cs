using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkerViewer.PensPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableListBox1.Items.Add(("eee", new[] {("www", "tttt"), ("ttt", "hhhh") }));
            tableListBox1.Items.Add(("ttt", new[] { ("www", "tttt"), ("ttt", "hhhh") }));
            tableListBox1.UpdateItems();
        }
    }
}
