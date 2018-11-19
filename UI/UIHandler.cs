using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Offers;

namespace Offers.UI
{
    public static class UIHandler
    {
        public static int currentPage = 0;
        public static List<GroupBox> groupBoxes = new List<GroupBox>();

        public static void ReInitializeLabels(int predicted, int total)
        {
            MainForm.m_Instance.Potential.Text = $"Ожидаемая прибыль: {predicted} RUB";
            MainForm.m_Instance.TotalPrice.Text = $"Полученная прибыль: {total} RUB";
            MainForm.m_Instance.label1.Text = $"Ещё заказов: {Math.Max(0, MainForm.m_Instance.m_MainData.CurrentOffers.Count - 6)} шт";

            Console.WriteLine("Текст обновлён");
        }

        public static void ReInitializeButtons(int page = 0)
        {
            if (page == 1 && MainForm.m_Instance.m_MainData.CurrentOffers.Count > (currentPage + 1) * 6)
            {
                currentPage++;
                Console.WriteLine("Переключили страницу вперед");
            }
            else if (page == -1)
            {
                currentPage--;
                Console.WriteLine("Переключили страницу назад");
            }

            foreach (var check in groupBoxes)
                check.Hide();

            groupBoxes.Clear();

            if (MainForm.m_Instance.m_MainData.CurrentOffers.Count == 0)
            {
                MainForm.m_Instance.label2.Show();
            }
            else
            {
                MainForm.m_Instance.label2.Hide();
            }

            foreach (var check in MainForm.m_Instance.m_MainData.CurrentOffers.Select((i,t) => new { A = i, B = t }).Skip(6*currentPage).Take(6))
            {
                Console.WriteLine($"Отрисовываем: {check.A.HeaderName}");
                var groupBox = new GroupBox();
                
                var label3 = new Label();
                var label2 = new Label();
                var label1 = new Label();
                var button3 = new Button();
                var button1 = new Button();
                var button2 = new Button();

                groupBox.Location = new System.Drawing.Point(12, 12 + check.B * 120 - currentPage * 6 * 120);
                groupBox.Name = check.A.HeaderName + check.B;
                groupBox.Size = new System.Drawing.Size(339, 108);
                groupBox.TabIndex = 3 + check.B;
                groupBox.TabStop = false;
                groupBox.Text = check.A.HeaderName;


                groupBox.Controls.Add(button2);
                groupBox.Controls.Add(button1);
                groupBox.Controls.Add(label3);
                groupBox.Controls.Add(button3);
                groupBox.Controls.Add(label2);
                groupBox.Controls.Add(label1);

                label3.AutoSize = true;
                label3.Location = new System.Drawing.Point(180, 69);
                label3.Name = check.B + "label3";
                label3.Size = new System.Drawing.Size(97, 13);
                label3.TabIndex = 2 + check.B * 3;
                label3.Text = "Зазазчик " + check.A.Customer;
                label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
                // 
                // label2
                // 
                label2.AutoSize = true;
                label2.Location = new System.Drawing.Point(6, 68);
                label2.Name = check.B + "label2";
                label2.Size = new System.Drawing.Size(120, 13);
                label2.TabIndex = 1 + check.B * 3;
                label2.Text = $"Цена: " + check.A.Price.ToString();
                // 
                // label1
                // 
                label1.AutoSize = true;
                label1.Location = new System.Drawing.Point(6, 16);
                label1.MaximumSize = new System.Drawing.Size(340, 0);
                label1.Name = check.B + "button1";
                label1.Size = new System.Drawing.Size(324, 26);
                label1.TabIndex = 0 + check.B * 3;
                label1.Text = check.A.Description;
                // 
                // button3
                // 
                button3.Location = new System.Drawing.Point(0, 85);
                button3.Name = check.B + "button3";
                button3.Size = new System.Drawing.Size(162, 23);
                button3.TabIndex = 4 + check.B * 3;
                button3.Text = "ПОСТОПЛАТА";
                button3.BackColor = check.A.PostPay ? Color.LightGreen : button3.BackColor;
                button3.Click += SetPay;
                button3.Tag = check.B;
                //button3.UseVisualStyleBackColor = true;
                // 
                // button1
                // 
                button1.Location = new System.Drawing.Point(180, 85);
                button1.Name = check.B + "button1";
                button1.Size = new System.Drawing.Size(159, 23);
                button1.TabIndex = 5 + check.B * 3;
                button1.Text = "СДЕЛАНО";
                button1.Click += CloseOffer;
                button1.Tag = check.B;
                button1.UseVisualStyleBackColor = true;


                button2.Location = new System.Drawing.Point(162, 85);
                button2.Name = check.B + "button2";
                button2.Size = new System.Drawing.Size(18, 23);
                button2.TabIndex = 5 + check.B * 3;
                button2.BackColor = Color.OrangeRed;
                button2.Text = "Х";
                button2.Click += RemoveOffer;
                button2.Tag = check.B;
                //button2.UseVisualStyleBackColor = true;

                MainForm.m_Instance.Controls.Add(groupBox);
                groupBoxes.Add(groupBox);
            }
        }

        public static void CloseOffer(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                MainForm.m_Instance.m_MainData.CloseOffer(Convert.ToInt32((sender as Button).Tag));
            }
        }

        public static void SetPay(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                MainForm.m_Instance.m_MainData.SetPay(Convert.ToInt32((sender as Button).Tag));
            }
        }

        public static void RemoveOffer(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                MainForm.m_Instance.m_MainData.Remove(Convert.ToInt32((sender as Button).Tag));
            }
        }
    }
}
