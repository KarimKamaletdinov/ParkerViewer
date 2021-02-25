using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Gui.Views;
using ParkerViewer.PensPage;

namespace ParkerViewer.PenItemsPage
{
    public partial class PenItemsPageControl : UserControl, IPenItemView
    {
        public List<PenItemDto> PenItems { get; set; }

        public event Action<PenItemDto> InsertPenItem;
        public event Action<PenItemDto> UpdatePenItem;
        public event Action<int> DeletePenItem;
        public event Action<IPenItemView> UpdateView;
        public (string, int)[] Models;

        private TableListBox _tableListBox;

        public PenItemsPageControl()
        {
            InitializeComponent();

            _tableListBox = new TableListBox();
            _tableListBox.ItemUpdated += ItemUpdated;
            _tableListBox.Show();
            _tableListBox.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(_tableListBox);
        }

        private void ItemUpdated(TlbItem obj)
        {
            UpdatePenItem(new PenItemDto()
            {
                Id = int.Parse(obj.Name),
                Name = GetItem("Название", obj),
                ModelId = int.Parse(GetItem("Модель", obj)),
                Engraving = GetItem("Гравировка", obj),
                Broken = bool.Parse(GetItem("Брак", obj)),
                Stock = int.Parse(GetItem("Склад", obj))
            });
        }

        public void UpdateElement()
        {
            UpdateView(this);
            _tableListBox.Items.Clear();
            foreach (var item in PenItems)
            {
                var tlbItem = new TlbItem();
                tlbItem.Name = item.Id.ToString();
                tlbItem.Header = item.Name;
                tlbItem.Dock = DockStyle.Top;
                tlbItem.Items = new List<(string, string, TlbItemValue, string[])>();
                tlbItem.Items.Add(("Название", item.Name, TlbItemValue.String, null));
                tlbItem.Items.Add(("Модель", item.ModelId.ToString(), TlbItemValue.Int, null));
                tlbItem.Items.Add(("Гравировка", item.Engraving, TlbItemValue.String, null));
                tlbItem.Items.Add(("Склад", item.Stock.ToString(), TlbItemValue.Int, null));
                tlbItem.Items.Add(("Брак", item.Broken.ToString(), TlbItemValue.Bool, null));
                _tableListBox.Items.Add(tlbItem);
            }
            
            _tableListBox.UpdateItems();
        }

        private string GetItem(string name, TlbItem item)
        {
            foreach (var field in item.Items)
            {
                if (field.Item1.ToLower() == name.ToLower())
                {
                    return field.Item2;
                }
            }

            throw new Exception($"Поле \"{name}\" не найдено!");
        }

        private void tableListBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
