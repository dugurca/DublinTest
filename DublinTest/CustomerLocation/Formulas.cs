using System;

namespace DublinTest.CustomerLocation
{
    public static class Formulas
    {
        public static double AngleToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public static double DistanceBetween2Coords(Tuple<double, double> coord1, Tuple<double, double> coord2)
        {
            double lat1 = coord1.Item1, lat2 = coord2.Item1;
            double lon1 = coord1.Item2, lon2 = coord2.Item2;

            double phi1 = AngleToRadians(lat1);
            double phi2 = AngleToRadians(lat2);

            double delPhi = AngleToRadians(lat2 - lat1);
            double delLam = AngleToRadians(lon2 - lon1);

            double a = Math.Sin(delPhi/2)*Math.Sin(delPhi/2) + 
                Math.Cos(phi1)*Math.Cos(phi2)*Math.Sin(delLam/2)*Math.Sin(delLam/2);
            double c = 2*Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return c * 6371000;
        }
    }
}
