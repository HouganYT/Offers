using Offers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Offers.Forms
{
    public partial class AddNew : Form
    {
        public AddNew()
        {
            InitializeComponent();

            InitializeChoose();
        }

        public void InitializeChoose()
        {
            foreach (var check in MainData.GetCustomers())
                comboCustomers.Items.Add(check);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int price;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboCustomers.SelectedText == "Выбрать")
            {
                MessageBox.Show("Вы ввели не всю необходимую информацию!");
                return;
            }
            else if (int.TryParse(textBox3.Text, out price))
            {
                MainData.AddOffer(new Offer(textBox1.Text, textBox2.Text, comboCustomers.Text, textBox4.Text, Convert.ToInt32(textBox3.Text)));
                Close();
            }
            else
            {
                MessageBox.Show("Сумма введена неверно!");
                return;
            }
        }
    }
}
