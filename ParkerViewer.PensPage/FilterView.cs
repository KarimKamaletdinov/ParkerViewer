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
    public partial class FilterView : UserControl
    {
        public List<(string, TlbItemValue, string[])> Fields =
            new List<(string, TlbItemValue, string[])>();

        public Filter Filter = new Filter();
        public event Action FilterChanged;
        public event Action Delete; 

        public FilterView()
        {
            InitializeComponent();
        }

        public void UpdateFields()
        {
            comboBox1.Items.Clear();

            foreach (var field in Fields)
            {
                comboBox1.Items.Add(field.Item1);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var field in Fields.Where(field => field.Item1 == comboBox1.Text))
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox3.Enabled = true;
                comboBox3.Items.Clear();
                comboBox3.FormatString = "";
                comboBox3.DropDownStyle = ComboBoxStyle.DropDown;

                Control co = null;

                foreach (var c in flowLayoutPanel1.Controls)
                {
                    if (c is DateTimePicker d)
                    {
                        co = d;
                    }
                }

                if (co != null)
                {
                    flowLayoutPanel1.Controls.Remove(co);
                    flowLayoutPanel1.Controls.Add(comboBox3);
                }

                switch (field.Item2)
                {
                    case TlbItemValue.String:
                        comboBox2.Items.Add("=");
                        comboBox2.Items.Add("?");
                        break;
                    case TlbItemValue.Int:
                        comboBox2.Items.Add("=");
                        comboBox2.Items.Add(">");
                        comboBox2.Items.Add("<");
                        comboBox2.Text = "=";
                        comboBox3.Text = "0";
                        break;
                    case TlbItemValue.Bool:
                        comboBox2.Items.Add("=");

                        comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                        comboBox3.Items.Add("True");
                        comboBox3.Items.Add("False");
                        break;
                    case TlbItemValue.Enum:
                        comboBox2.Items.Add("=");

                        comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

                        comboBox3.Items.AddRange(field.Item3);
                        break;
                    case TlbItemValue.DateTime:
                        comboBox2.Items.Add("=");
                        comboBox2.Text = "=";
                        comboBox3.Parent = null;
                        var value = new DateTimePicker();
                        value.ValueChanged += comboBox2_TextChanged;
                        flowLayoutPanel1.Controls.Add(value);
                        flowLayoutPanel1.Controls.Remove(button1);
                        flowLayoutPanel1.Controls.Add(button1);
                        break;
                }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter.FieldName = comboBox1.Text;
                Filter.Sign = comboBox2.Text[0];
                Filter.FieldValue = ((Control)sender).Text;
                FilterChanged();
            }
            catch
            {
                // ignored
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
