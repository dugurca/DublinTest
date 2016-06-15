using System;
using System.Collections.Generic;
using System.Linq;

namespace DublinTest.CustomerLocation
{
    class Customers
    {
        public List<Customer> AllCustomers { get; private set; }

        public Customers(string path)
        {
            UpdateCustomers(path);
        }

        public void UpdateCustomers(string path)
        {
            AllCustomers = CustomerDeserializer.DeserializeFromFile(path);
        }

        public List<Customer> GetCustomersNearOffice()
        {
            var officeLoc = new Tuple<double, double>(53.3381985, -6.2592576);
            const double prox = 100000;
            var res = AllCustomers.Where(customer => customer.DistanceTo(officeLoc) <= prox).ToList();
            res.Sort((a, b) => a.User_id.CompareTo(b.User_id));
            return res;
        }
    }
}
