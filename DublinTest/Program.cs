using System;
using System.Collections.Generic;
using DublinTest.CustomerLocation;
using DublinTest.NestedList;

namespace DublinTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a valid file path");
            }
            else
            {
                var customers = new Customers(args[0]);
                var nearOfficeCustomers = customers.GetCustomersNearOffice();

                var officeLoc = new Tuple<double, double>(53.3381985, -6.2592576);
                foreach (var customer in nearOfficeCustomers)
                {
                    Console.WriteLine(customer.User_id + " | Name: " + customer.Name + " distance to office: " + 
                        (customer.DistanceTo(officeLoc) / 1000).ToString("0.00" + "km"));
                }
            }
        }

        void NestedListProblem()
        {
            //[[1,2,[3]],4] → [1,2,3,4]
            var nested1234 = new List<object>
            {
                new List<object>
                {
                    1, 2, new List<object> { 3 }
                },
                4
            };
            NestedListFlatter flatter = new NestedListFlatter();
            Console.WriteLine(flatter.NestedListToString(nested1234));
            var flatList = flatter.NestedListToString(nested1234);

            foreach (var item in flatList)
            {
                Console.Write(item + " ");
            }
        }
    }
}
