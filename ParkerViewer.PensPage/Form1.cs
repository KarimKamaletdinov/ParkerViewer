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

namespace ParkerViewer.PensPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var PensControl = new PensPageControl();
            PensControl.Pens.Add(new PenDto()
            {
                CollectionId = 1,
                DetailColor = "золотой",
                Engraving = false,
                ForMan = true,
                ForWoman = false,
                GoldPen = false,
                Id = 0,
                Name = "ddd",
                Price = 1000,
                WritingType = "роллер"
            });
            PensControl.UpdateView += view => { };
            PensControl.UpdateElement();
            PensControl.Dock = DockStyle.Fill;
            PensControl.Parent = this;
        }
    }
}
