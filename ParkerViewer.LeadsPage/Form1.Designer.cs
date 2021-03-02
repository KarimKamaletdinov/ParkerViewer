
namespace ParkerViewer.LeadsPage
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.leadsPageControl1 = new ParkerViewer.LeadsPage.LeadsPageControl();
            this.SuspendLayout();
            // 
            // leadsPageControl1
            // 
            this.leadsPageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leadsPageControl1.Leads = null;
            this.leadsPageControl1.Location = new System.Drawing.Point(0, 0);
            this.leadsPageControl1.Name = "leadsPageControl1";
            this.leadsPageControl1.Size = new System.Drawing.Size(800, 450);
            this.leadsPageControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leadsPageControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LeadsPageControl leadsPageControl1;
    }
}

