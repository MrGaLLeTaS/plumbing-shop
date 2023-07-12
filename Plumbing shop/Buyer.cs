using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Plumbing_shop
{
    internal class Buyer
    {
        string login;
        string pass;

        public Buyer(string a, string b)
        {
            login = a;
            pass = b;
        }
        
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
    }
}
