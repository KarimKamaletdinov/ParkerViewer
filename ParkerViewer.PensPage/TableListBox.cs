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
    public partial class TableListBox : UserControl
    {
        public List<TlbItem> Items = new List<TlbItem>();

        public event Action<TlbItem> ItemUpdated;

        public event Action CreateNew;

        public event Action<TlbItem> DeleteItem; 

        public TableListBox()
        {
            InitializeComponent();
        }

        private void TableListBox_Load(object sender, EventArgs e)
        {

        }

        public void UpdateItems()
        {
            Controls.Clear();
            foreach (var item in Items)
            {
                Controls.Add(item);
                item.Dock = DockStyle.Top;
                item.ContextMenuStrip = new ContextMenuStrip();
                var value = new ToolStripMenuItem("Удалить");
                value.Click += (s, e) => DeleteItem(item);
                item.ContextMenuStrip.Items.Add(value);
                var value2 = new ToolStripMenuItem("Создать новый");
                value2.Click += (s, e) => CreateNew();
                item.ContextMenuStrip.Items.Add(value2);
                item.DataUpdated += (a, b) => ItemUpdated(a);
            }
        }

        private void создатьНовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNew();
        }
    }
}
