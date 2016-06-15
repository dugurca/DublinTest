using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DublinTest.CustomerLocation.Test
{
    [TestFixture]
    class CustomerDeserializerTest
    {
        [Test]
        public void TestCustomersDeserialization()
        {
            var customer1 = new Customer(52.986375, 12, "Christina McArdle", -6.043701);
            string customer1Json = JsonConvert.SerializeObject(customer1, Formatting.Indented);
            Console.WriteLine(customer1Json);
            var customerDs1 = CustomerDeserializer.Deserialize(customer1Json);

            Assert.AreEqual(customerDs1.Longitude, customer1.Longitude);
            Assert.AreEqual(customerDs1.Latitude, customer1.Latitude);
            Assert.AreEqual(customerDs1.Name, customer1.Name);
            Assert.AreEqual(customerDs1.User_id, customer1.User_id);

            var customer2 = new Customer(39.9334, 678, "Deniz Ugurca", 32.8597);
            string customer2Json = JsonConvert.SerializeObject(customer2, Formatting.Indented);
            Console.WriteLine(customer2Json);
            var customerDs2 = CustomerDeserializer.Deserialize(customer2Json);

            Assert.AreEqual(customerDs2.Longitude, customer2.Longitude);
            Assert.AreEqual(customerDs2.Latitude, customer2.Latitude);
            Assert.AreEqual(customerDs2.Name, customer2.Name);
            Assert.AreEqual(customerDs2.User_id, customer2.User_id);
        }
    }
}
