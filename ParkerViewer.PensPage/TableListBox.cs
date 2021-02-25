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

        public List<Filter> Filters = new List<Filter>();

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

            foreach (var item in Items.Where(ItemFiltered))
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

        private bool ItemFiltered(TlbItem item)
        {
            var result = true;

            foreach (var field in item.Items)
            {
                foreach (var filter in Filters)
                {
                    if (filter.FieldName == field.Item1 && !filter.Execute(field.Item1, field.Item2))
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        private void создатьНовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNew();
        }
    }
}
