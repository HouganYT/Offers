namespace Offers
{
    partial class MainForm
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
            this.AddNew = new System.Windows.Forms.Button();
            this.Potential = new System.Windows.Forms.Label();
            this.TotalPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddNew
            // 
            this.AddNew.Location = new System.Drawing.Point(64, 727);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(238, 28);
            this.AddNew.TabIndex = 0;
            this.AddNew.Text = "Добавить новый заказ";
            this.AddNew.UseVisualStyleBackColor = true;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // Potential
            // 
            this.Potential.AutoSize = true;
            this.Potential.Location = new System.Drawing.Point(13, 758);
            this.Potential.MinimumSize = new System.Drawing.Size(340, 0);
            this.Potential.Name = "Potential";
            this.Potential.Size = new System.Drawing.Size(340, 13);
            this.Potential.TabIndex = 1;
            this.Potential.Text = "Потенциальная прибыль: 10.000 РУБ";
            this.Potential.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSize = true;
            this.TotalPrice.Location = new System.Drawing.Point(12, 771);
            this.TotalPrice.MaximumSize = new System.Drawing.Size(340, 0);
            this.TotalPrice.MinimumSize = new System.Drawing.Size(340, 0);
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Size = new System.Drawing.Size(340, 13);
            this.TotalPrice.TabIndex = 2;
            this.TotalPrice.Text = "Всего заработано: 999.999 РУБ";
            this.TotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 784);
            this.label1.MinimumSize = new System.Drawing.Size(340, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ещё заказов: 0 шт";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(59, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Заказов больше нет ;c";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 727);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 727);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 806);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalPrice);
            this.Controls.Add(this.Potential);
            this.Controls.Add(this.AddNew);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список заказов ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddNew;
        public System.Windows.Forms.Label Potential;
        public System.Windows.Forms.Label TotalPrice;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

