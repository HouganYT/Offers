using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offers.Data
{
    public class Offer
    {
        public string HeaderName;
        public string Description;
        public string Customer;
        public string Time;

        public bool PostPay;
        public bool Finished;

        public int Price;

        public Offer(string name, string description, string customer, string time, int price)
        {
            HeaderName = name;
            Description = description;
            Customer = customer;

            Price = price;
        }
    }
}
