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

namespace ParkerViewer.LeadsPage
{
    public partial class LeadsPageControl : UserControl, ILeadsView
    {

        public event Action<LeadDto> InsertLead;
        public event Action<LeadDto> UpdateLead;
        public event Action<int> DeleteLead;
        public event Action<ILeadsView> UpdateView;
        public List<LeadDto> Leads { get; set; }

        private TableListBox tableListBox1 = new TableListBox();


        public LeadsPageControl()
        {
            InitializeComponent();

            tableListBox1.CreateNew += CreateNew;

            tableListBox1.DeleteItem += DeleteItem;

            tableListBox1.Parent = splitContainer1.Panel2;

            tableListBox1.Dock = DockStyle.Fill;
        }

        private void DeleteItem(TlbItem obj)
        {
            DeleteLead(int.Parse(obj.Name));
            UpdateElement();
        }

        private void CreateNew()
        {
            InsertLead(new LeadDto
            {
                Id = 1,
                Agreed = false,
                Payed = false,
                Comment = "",
                CreatingDate = DateTime.Now,
                CustomerName = "",
                Region = "",
                Sity = "",
                Street = "",
                House = "",
                Delivered = false,
                Pens = new []{0},
                DeliveryDate = DateTime.Now + new TimeSpan(1, 0, 0, 0),
                DeliveryMethod = "Наличными при получении",
                PayMethod = "Из магазина",
                Flat = "1",
                FullPrice = null,
            });
            UpdateElement();
        }

        public void UpdateElement()
        {
            UpdateView(this);

            tableListBox1.Items.Clear();

            foreach (var lead in Leads)
            {
                var item = new TlbItem();
                item.Name = lead.Id.ToString();
                item.Header = "";
                item.Items.AddRange(new (string, string, TlbItemValue, string[])[]
                {
                    ("Имя покупателя", lead.CustomerName, TlbItemValue.String, null),
                    ("Регион", lead.Region, TlbItemValue.String, null),
                    ("Город", lead.Sity, TlbItemValue.String, null),
                    ("Улица", lead.Street, TlbItemValue.String, null),
                    ("Дом", lead.House, TlbItemValue.String, null),
                    ("Квартира", lead.Flat, TlbItemValue.String, null),
                    ("Способ оплаты", lead.PayMethod, TlbItemValue.Enum, new[]
                    {
                        "На сайте",
                        "Переводом",
                        "Картой при получении",
                        "Наличными при получении"
                    }),
                    ("Способ доставки", lead.DeliveryMethod, TlbItemValue.Enum, new []
                    {
                        "Из магазина",
                        "Нашим курьером",
                        "Из пункта выдачи СДЭК",
                        "Курьером СДЭК"
                    }),
                    ("Дата заказа", lead.CreatingDate.ToString(), TlbItemValue.DateTime, null),
                    ("Дата доставки", lead.DeliveryDate.ToString(), TlbItemValue.DateTime, null),
                    ("Согласовано", lead.Agreed.ToString(), TlbItemValue.Bool, null),
                    ("Оплачено", lead.Payed.ToString(), TlbItemValue.Bool, null),
                    ("Доставлено", lead.Delivered.ToString(), TlbItemValue.Bool, null),
                    ("Комментарий", lead.Comment, TlbItemValue.String, null),
                    ("Id ручек", string.Join(" ", lead.Pens), TlbItemValue.String, null),
                    ("ИТОГО", lead.FullPrice.ToString(), TlbItemValue.Enum, new []
                    {
                        lead.FullPrice.ToString()
                    }),
                });
                item.Dock = DockStyle.Top;

                tableListBox1.Items.Add(item);
            }
            tableListBox1.UpdateItems();
        }

        private void LeadsPageControl_Load(object sender, EventArgs e)
        {
            tableListBox1.ItemUpdated += TableListBox1Updated;
        }

        private void TableListBox1Updated(TlbItem obj)
        {
            UpdateLead(new LeadDto
            {
                Id = int.Parse(obj.Name),
                CustomerName = GetItem("Имя покупателя", obj),
                Region = GetItem("Регион", obj),
                Sity = GetItem("Город", obj),
                Street = GetItem("Улица", obj),
                House = GetItem("Дом", obj),
                Flat = GetItem("Квартира", obj),
                Agreed = bool.Parse(GetItem("Согласовано", obj)),
                Payed = bool.Parse(GetItem("Оплачено", obj)),
                Delivered = bool.Parse(GetItem("Доставлено", obj)),
                Pens = GetItem("Id ручек", obj).Split(' ').Select(int.Parse).ToArray(),
                CreatingDate = DateTime.Parse(GetItem("Дата заказа", obj)),
                DeliveryDate = DateTime.Parse(GetItem("Дата доставки", obj)),
                DeliveryMethod = GetItem("Способ оплаты", obj),
                PayMethod = GetItem("Способ доставки", obj),
                Comment = GetItem("Комментарий", obj),
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

        private void создатьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var value = new FilterView();
            value.Fields.AddRange(new (string, TlbItemValue, string[])[]
            {
                ("Имя покупателя", TlbItemValue.String, null),
                ("Регион", TlbItemValue.String, null),
                ("Город", TlbItemValue.String, null),
                ("Улица", TlbItemValue.String, null),
                ("Дом", TlbItemValue.String, null),
                ("Квартира", TlbItemValue.String, null),
                ("Способ оплаты", TlbItemValue.Enum, new[]
                {
                    "На сайте",
                    "Переводом",
                    "Картой при получении",
                    "Наличными при получении"
                }),
                ("Способ доставки", TlbItemValue.Enum, new []
                {
                    "Из магазина",
                    "Нашим курьером",
                    "Из пункта выдачи СДЭК",
                    "Курьером СДЭК"
                }),
                ("Дата заказа", TlbItemValue.DateTime, null),
                ("Дата доставки", TlbItemValue.DateTime, null),
                ("Согласовано", TlbItemValue.Bool, null),
                ("Оплачено", TlbItemValue.Bool, null),
                ("Доставлено", TlbItemValue.Bool, null),
                ("Комментарий", TlbItemValue.String, null),
                ("Id ручек", TlbItemValue.String, null),
                ("ИТОГО", TlbItemValue.Int, null)
            });
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
