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
            _tableListBox.CreateNew += CreateNew;
            _tableListBox.DeleteItem += DeleteItem;
            splitContainer1.Panel2.Controls.Add(_tableListBox);
        }

        private void CreateNew()
        {
            InsertPenItem(new PenItemDto()
            {
                Id = 1,
                Name = "",
                Broken = false,
                Engraving = "",
                ModelId = Models.Length > 0 ? Models[0].Item2 : 1,
                Stock = 1
            });
            UpdateElement();
        }

        private void DeleteItem(TlbItem obj)
        {
            DeletePenItem(int.Parse(obj.Name));
            UpdateElement();
        }

        private void ItemUpdated(TlbItem obj)
        {
            var dto = new PenItemDto();
            dto.Id = int.Parse(obj.Name);
            dto.Name = GetItem("Название", obj);
            dto.ModelId = Models.FirstOrDefault(x=>x.Item1 == GetItem("Модель", obj)).Item2;
            dto.Engraving = GetItem("Гравировка", obj);
            dto.Broken = bool.Parse(GetItem("Брак", obj));
            dto.Stock = int.Parse(GetItem("Склад", obj));
            UpdatePenItem.Invoke(dto);
        }

        public void UpdateElement()
        {
            UpdateView(this);
            _tableListBox.Items.Clear();
            foreach (var item in PenItems)
            {
                var model = "";
                
                foreach (var m in Models)
                {
                    if (m.Item2 == item.ModelId)
                    {
                        model = m.Item1;
                    }
                }
                
                var models = Models.Select(m => m.Item1).ToArray();
                var tlbItem = new TlbItem();
                tlbItem.Name = item.Id.ToString();
                tlbItem.Header = item.Name;
                tlbItem.Dock = DockStyle.Top;
                tlbItem.Items = new List<(string, string, TlbItemValue, string[])>();
                tlbItem.Items.Add(("Название", item.Name, TlbItemValue.String, null));
                tlbItem.Items.Add(("Модель", model, TlbItemValue.Enum, models));
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

        private void создатьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var models = Models.Select(m => m.Item1).ToArray();
            var value = new FilterView();
            value.Fields.Add(("Название", TlbItemValue.String, null));
            value.Fields.Add(("Модель", TlbItemValue.Enum, models));
            value.Fields.Add(("Склад", TlbItemValue.Int, null));
            value.Fields.Add(("Гравировка", TlbItemValue.String, null));
            value.Fields.Add(("Брак", TlbItemValue.Bool, null));
            value.UpdateFields();
            value.ContextMenuStrip = contextMenuStrip1;
            flowLayoutPanel1.Controls.Add(value);
            _tableListBox.Filters.Add(value.Filter);
            value.FilterChanged += () => _tableListBox.UpdateItems();
            value.Delete += () =>
            {
                flowLayoutPanel1.Controls.Remove(value);
                _tableListBox.Filters.Remove(value.Filter);
                _tableListBox.UpdateItems();
            };
        }
    }
}
