﻿using System;
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
            }
        }

        private void DataUpdated(TlbItem sender, string fieldName)
        {
            ItemUpdated(sender);
        }
    }
}
