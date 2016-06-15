using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DublinTest.CustomerLocation
{
    public static class CustomerDeserializer
    {
        public static Customer Deserialize(string jsonStr)
        {
            return JsonConvert.DeserializeObject<Customer>(jsonStr);
        }

        public static List<Customer> DeserializeFromFile(string path)
        {
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                return lines.Select(Deserialize).ToList();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}