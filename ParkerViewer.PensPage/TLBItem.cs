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
    public partial class TlbItem : UserControl
    {
        public string Header
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public event Action<TlbItem, string> DataUpdated; 

        public List<(string, string, TlbItemValue, string[])> Items =
            new List<(string, string, TlbItemValue, string[])>();

        private bool _collapsed = false;
        
        public TlbItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recollapse();
        }

        public void Recollapse()
        {
            _collapsed = !_collapsed;

            if (_collapsed)
            {
                button1.Text = "-";

                var controls = new List<Control>();

                foreach (var item in Items.ToArray())
                {
                    controls.Add(new TextBox()
                    {
                        AutoSize = false, 
                        Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Left,
                        Text = item.Item1,
                        ReadOnly = true,
                        Name = "item"
                    });

                    if (item.Item3 == TlbItemValue.String || item.Item3 == TlbItemValue.Int)
                    {
                        var box = new TextBox();
                        box.AutoSize = false;
                        box.Dock = DockStyle.Fill;
                        box.TextAlign = HorizontalAlignment.Left;
                        box.Text = item.Item2;
                        box.Name = $"item{item.Item1}";
                        box.ReadOnly = true;
                        box.KeyDown += DataChanged;
                        box.DoubleClick += (s, e) => box.ReadOnly = false;
                        controls.Add(box);
                    }

                    else if (item.Item3 == TlbItemValue.Bool)
                    {
                        var box = new CheckBox();
                        box.AutoSize = false;
                        box.Dock = DockStyle.Fill;
                        box.Checked = bool.Parse(item.Item2);
                        box.Name = $"item{item.Item1}";
                        box.CheckedChanged += ChangeData;
                        controls.Add(box);
                    }

                    else if (item.Item3 == TlbItemValue.Enum)
                    {
                        var box = new ComboBox();
                        box.AutoSize = false;
                        box.Dock = DockStyle.Fill;
                        box.Name = $"item{item.Item1}";
                        box.Items.AddRange(item.Item4);
                        box.DropDownStyle = ComboBoxStyle.DropDownList;
                        box.Text = item.Item2;
                        box.SelectedIndexChanged += ChangeData;
                        controls.Add(box);
                    }

                    else if (item.Item3 == TlbItemValue.DateTime)
                    {
                        var box = new DateTimePicker();
                        box.AutoSize = false;
                        box.Dock = DockStyle.Fill;
                        box.Name = $"item{item.Item1}";
                        box.Value = DateTime.Parse(item.Item2);
                        box.ValueChanged += ChangeData;
                        controls.Add(box);
                    }
                }

                tableLayoutPanel1.Controls.AddRange(controls.ToArray());
            }

            else
            {
                button1.Text = "+";

                //var a = new object[tableLayoutPanel1.Controls.Count];
                //tableLayoutPanel1.Controls.CopyTo(a, 0);

                //foreach (var obj in a)
                //{
                //    var control = (Control) obj;
                //    if (control.Name.StartsWith("item"))
                //    {
                //        tableLayoutPanel1.Controls.Remove(control);
                //    }
                //}

                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(label1);
                tableLayoutPanel1.Controls.Add(button1);
            }
        }

        private void DataChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeData(sender, e);
            }
        }

        private void ChangeData(object sender, EventArgs e)
        {
            if (sender is TextBox t)
            {
                t.ReadOnly = true;
            }

            int i = 0;
            foreach (var item in Items.ToArray())
            {
                if (item.Item1 == ((Control)sender).Name.Remove(0, 4))
                {
                    if (item.Item3 == TlbItemValue.Int && !int.TryParse(((Control)sender).Text, out var r))
                    {
                        MessageBox.Show($"Неприемлимое значение числа: {((Control)sender).Text}");
                        return;
                    }

                    else if (item.Item3 == TlbItemValue.Bool)
                    {
                        Items.Remove(item);
                        Items.Insert(i, (item.Item1, ((CheckBox)sender).Checked.ToString(), item.Item3,
                                item.Item4));
                        DataUpdated(this, ((Control)sender).Name.Remove(0, 4));
                        return;
                    }

                    //else if (item.Item3 == TlbItemValue.PenDetailColor)
                    //{
                    //    Items.Remove(item);
                    //    Items.Insert(i, (item.Item1, ((ComboBox)sender).SelectedItem.ToString(), item.Item3));
                    //    DataUpdated(this, ((Control)sender).Name.Remove(0, 4)); 
                    //    return;
                    //}

                    //else if (item.Item3 == TlbItemValue.PenWritingType)
                    //{
                    //    Items.Remove(item);
                    //    Items.Insert(i, (item.Item1, ((ComboBox)sender).SelectedItem.ToString(), item.Item3));
                    //    DataUpdated(this, ((Control)sender).Name.Remove(0, 4));
                    //    return;
                    //}

                    Items.Remove(item);
                    Items.Insert(i, (item.Item1, ((Control)sender).Text, item.Item3, item.Item4));
                    DataUpdated(this, ((Control)sender).Name.Remove(0, 4));
                    return;
                }

                i++;
            }
        }
    }
}
