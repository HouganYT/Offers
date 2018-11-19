using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Offers.UI;

namespace Offers.Data
{
    public class MainData
    {
        public List<Offer> CurrentOffers = new List<Offer>();
        public List<Offer> PreviousOffers = new List<Offer>();
        public Dictionary<string, int> CustomerList = new Dictionary<string, int>();

        public int PredictedPrice() => CurrentOffers.Where(p => !p.PostPay).Sum(p => p.Price / 2);
        public int TotalPrice() => PreviousOffers.Sum(p => p.Price) + CurrentOffers.Where(p => !p.PostPay).Sum(p => p.Price/2) + CurrentOffers.Where(p => p.PostPay).Sum(p => p.Price);
        
        public void SaveData()
        {
            var serialized = JsonConvert.SerializeObject(this);
            Console.WriteLine(serialized);

            try
            {
                System.IO.File.WriteAllText("Data.json", serialized);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Запустите программу от имени администратора!");
                return;
            }
            Console.WriteLine("Информация сохранена");
        }

        public static void AddOffer(Offer offer)
        {
            MainForm.m_Instance.m_MainData.CurrentOffers.Add(offer);
            UIHandler.ReInitializeLabels(MainForm.m_Instance.m_MainData.PredictedPrice(), MainForm.m_Instance.m_MainData.TotalPrice());
            UIHandler.ReInitializeButtons();

            if (!MainForm.m_Instance.m_MainData.CustomerList.ContainsKey(offer.Customer))
                MainForm.m_Instance.m_MainData.CustomerList.Add(offer.Customer, 0);

            MainForm.m_Instance.m_MainData.CustomerList[offer.Customer]++;
            MainForm.m_Instance.m_MainData.SaveData();
        }

        public void CloseOffer(int offerId)
        {
            Offer closeOffer = CurrentOffers[offerId];
            PreviousOffers.Add(closeOffer);
            CurrentOffers.Remove(closeOffer);
            
            UIHandler.ReInitializeLabels(MainForm.m_Instance.m_MainData.PredictedPrice(), MainForm.m_Instance.m_MainData.TotalPrice());
            UIHandler.ReInitializeButtons();
            SaveData();
        }

        public void SetPay(int offerId)
        {
            if (CurrentOffers[offerId].PostPay == true)
                CurrentOffers[offerId].PostPay = false;
            else
                CurrentOffers[offerId].PostPay = true;

            UIHandler.ReInitializeLabels(MainForm.m_Instance.m_MainData.PredictedPrice(), MainForm.m_Instance.m_MainData.TotalPrice());
            UIHandler.ReInitializeButtons();
            SaveData();
        }

        public void Remove(int offerId)
        {
            CurrentOffers.RemoveAt(offerId);

            UIHandler.ReInitializeLabels(MainForm.m_Instance.m_MainData.PredictedPrice(), MainForm.m_Instance.m_MainData.TotalPrice());
            UIHandler.ReInitializeButtons();
            SaveData();
        }

        public static List<string> GetCustomers()
        {
            return MainForm.m_Instance.m_MainData.CustomerList.Keys.ToList();
           // return new List<string> { "opa", "jopa", "sosi" };
        }
    }
}
