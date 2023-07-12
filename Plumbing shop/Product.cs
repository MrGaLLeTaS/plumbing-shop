using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plumbing_shop
{
    internal class Product
    {
        string category;
        string name;
        double price;

        public Product(string x, string y, double z)
        {
            category = x;
            name = y;
            price = z;
        }
        public string Category
        {
            get { return category; }
            set { category = value; }   
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
