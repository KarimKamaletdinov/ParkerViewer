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

namespace ParkerViewer.PensPage
{
    public partial class PensPageControl : UserControl, IPenView
    {
        public event Action<PenDto> InsertPen;
        public event Action<PenDto> UpdatePen;
        public event Action<int> DeletePen;
        public event Action<IPenView> UpdateView;

        public List<PenDto> Pens { get; set; } = new List<PenDto>();

        public PensPageControl()
        {
            InitializeComponent();

            tableListBox1.CreateNew += CreateNew;

            tableListBox1.DeleteItem += DeleteItem;
        }

        private void DeleteItem(TlbItem obj)
        {
            DeletePen(int.Parse(obj.Name));
            UpdateElement();
        }

        private void CreateNew()
        {
            InsertPen(new PenDto()
            {
                Collection = "",
                DetailColor = "золотой",
                Engraving = false,
                ForMan = false,
                ForWoman = false,
                GoldPen = false,
                Id = 1,
                Name = "",
                Price = 0,
                WritingType = "шариковый"
            });
            UpdateElement();
        }

        public void UpdateElement()
        {
            UpdateView(this);

            tableListBox1.Items.Clear();

            foreach (var pen in Pens)
            {
                var item = new TlbItem();
                item.Name = pen.Id.ToString();
                item.Header = pen.Name + "//" + pen.Id;
                item.Items.Add(("Название", pen.Name, TlbItemValue.String, null));
                item.Items.Add(("Цена", pen.Price.ToString(), TlbItemValue.Int, null));
                item.Items.Add(("Цвет деталей", pen.DetailColor, TlbItemValue.Enum, new []{"золотой", 
                    "серебряный"}));
                item.Items.Add(("Тип пишущего узла", pen.WritingType, TlbItemValue.Enum, new[]
                {
                    "шариковый",
                    "роллер",
                    "перьевой"
                }));
                item.Items.Add(("Коллекция", pen.Collection, TlbItemValue.String, null));
                item.Items.Add(("Гравировка", pen.Engraving.ToString(), TlbItemValue.Bool, null));
                item.Items.Add(("Золотое перо", pen.GoldPen.ToString(), TlbItemValue.Bool, null));
                item.Items.Add(("Для мужчин", pen.ForMan.ToString(), TlbItemValue.Bool, null));
                item.Items.Add(("Для женщин", pen.ForWoman.ToString(), TlbItemValue.Bool, null));
                item.Dock = DockStyle.Top;

                tableListBox1.Items.Add(item);
            }
            tableListBox1.UpdateItems();
        }

        private void PensPageControl_Load(object sender, EventArgs e)
        {
            tableListBox1.ItemUpdated += TableListBox1Updated;
        }

        private void TableListBox1Updated(TlbItem obj)
        {
            UpdatePen(new PenDto()
            {
                Id = int.Parse(obj.Name),
                Name = GetItem("Название", obj),
                Collection = GetItem("Коллекция", obj),
                WritingType = GetItem("Тип пишущего узла", obj),
                DetailColor = GetItem("Цвет деталей", obj),
                Engraving = bool.Parse(GetItem("Гравировка", obj)),
                GoldPen = bool.Parse(GetItem("Золотое перо", obj)),
                ForMan = bool.Parse(GetItem("Для мужчин", obj)),
                ForWoman = bool.Parse(GetItem("Для женщин", obj)),
                Price = int.Parse(GetItem("Цена", obj)),
            });
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

        private void button1_Click(object sender, EventArgs e)
        {
            var value = new FilterView();
            value.Fields.Add(("Название",TlbItemValue.String, null));
            value.Fields.Add(("Цена", TlbItemValue.Int, null));
            value.Fields.Add(("Цвет деталей", TlbItemValue.Enum, new[]{"золотой",
                "серебряный"}));
            value.Fields.Add(("Тип пишущего узла",TlbItemValue.Enum, new[]
            {
                "шариковый",
                "роллер",
                "перьевой"
            }));
            value.Fields.Add(("Коллекция", TlbItemValue.String, null));
            value.Fields.Add(("Гравировка", TlbItemValue.Bool, null));
            value.Fields.Add(("Золотое перо", TlbItemValue.Bool, null));
            value.Fields.Add(("Для мужчин", TlbItemValue.Bool, null));
            value.Fields.Add(("Для женщин", TlbItemValue.Bool, null));
            value.UpdateFields();
            value.ContextMenuStrip = contextMenuStrip1;
            flowLayoutPanel1.Controls.Add(value);
            tableListBox1.Filters.Add(value.Filter);
            value.FilterChanged += () => tableListBox1.UpdateItems();
            value.Delete += () =>
            {
                flowLayoutPanel1.Controls.Remove(value);
                tableListBox1.Filters.Remove(value.Filter);
                tableListBox1.UpdateItems();
            };
        }
    }
}
