using System;

namespace DublinTest.CustomerLocation
{
    public class Customer
    {
        public double Latitude { get; private set; }
        public long User_id { get; private set; }
        public string Name { get; private set; }
        public double Longitude { get; private set; }

        public Customer(double latitude, int user_Id, string name, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            User_id = user_Id;
            Name = name;
        }

        public double DistanceTo(Tuple<double, double> coordinate)
        {
            return Formulas.DistanceBetween2Coords(coordinate, CustomerCoordinate());
        }

        public Tuple<double, double> CustomerCoordinate()
        {
            return new Tuple<double, double>(Latitude, Longitude);
        }
    }
}