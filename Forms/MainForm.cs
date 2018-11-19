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
using Newtonsoft.Json;
using Offers.UI;
using Offers.Forms;

namespace Offers
{
    public partial class MainForm : Form
    {
        public AddNew m_AddNew = null;
        public MainData m_MainData = null;
        public static MainForm m_Instance;

        public MainForm()
        {
            InitializeComponent();
            m_Instance = this;

            LoadData();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            if (m_AddNew != null && !m_AddNew.IsDisposed)
            {
                m_AddNew.Focus();
            }
            else
            {
                m_AddNew = new AddNew();
                m_AddNew.Show();
            }
        }

        #region Functions

        private void LoadData()
        {
            if (System.IO.File.Exists("Data.json"))
            {
                m_MainData = JsonConvert.DeserializeObject<MainData>(System.IO.File.ReadAllText("Data.json"));
            }
            else
            {
                m_MainData = new MainData();
                m_MainData.SaveData();
            }

            Console.WriteLine("Дата успешно прочитана!");
            UIHandler.ReInitializeLabels(m_MainData.PredictedPrice(), m_MainData.TotalPrice());
            UIHandler.ReInitializeButtons();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            UIHandler.ReInitializeButtons(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UIHandler.ReInitializeButtons(-1);
        }
    }
}
