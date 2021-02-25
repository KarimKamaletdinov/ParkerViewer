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

                        comboBox3.FormatString = "N0";
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
                    default:
                        break;
                }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Filter.FieldName = comboBox1.Text;
            Filter.Sign = comboBox2.Text[0];
            Filter.FieldValue = comboBox3.Text;
            FilterChanged();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
