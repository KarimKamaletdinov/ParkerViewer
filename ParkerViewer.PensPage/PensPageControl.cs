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
        }

        public void UpdateElement()
        {
            UpdateView(this);

            tableListBox1.Items.Clear();

            foreach (var pen in Pens)
            {
                var item = new TlbItem();
                item.Name = pen.Id.ToString();
                item.Header = pen.Name;
                item.Items.Add(("Название", pen.Name, TlbItemValue.Int));
                item.Items.Add(("Цена", pen.Price.ToString(), TlbItemValue.Int));
                item.Items.Add(("Цвет деталей", pen.DetailColor, TlbItemValue.PenDetailColor));
                item.Items.Add(("Тип пишущего узла", pen.WritingType, TlbItemValue.PenDetailColor));
                item.Items.Add(("Коллекция", pen.CollectionId.ToString(), TlbItemValue.Int));
                item.Items.Add(("Гравировка", pen.Engraving.ToString(), TlbItemValue.Bool));
                item.Items.Add(("Золотое перо", pen.GoldPen.ToString(), TlbItemValue.Bool));
                item.Items.Add(("Для мужчин", pen.ForMan.ToString(), TlbItemValue.Bool));
                item.Items.Add(("Для женщин", pen.ForWoman.ToString(), TlbItemValue.Bool));
                item.Dock = DockStyle.Top;

                tableListBox1.Items.Add(item);
            }
            tableListBox1.UpdateItems();
        }

        private void TableListBox1Updated(TlbItem obj)
        {
            
        }

        private void PensPageControl_Load(object sender, EventArgs e)
        {
            tableListBox1.ItemUpdated += TableListBox1Updated;
        }
    }
}
