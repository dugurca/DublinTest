using System;
using NUnit.Framework;

namespace DublinTest.CustomerLocation.Test
{
    [TestFixture]
    class FormulasTest
    {
        [Test]
        public void LocationTest()
        {
            // North pole
            // 90.0000, 0.0000

            // South pole
            //-90.0000, 0.0000

            // Circumference of earth is 40075 km
            // So the result should be about ~20000km

            var northPole = new Tuple<double, double>(90.0000, 0.0000);
            var southPole = new Tuple<double, double>(-90.0000, 0.0000);

            var dist1 = Formulas.DistanceBetween2Coords(northPole, southPole);
            Assert.Greater(dist1, 20000000);
            Assert.Less(dist1, 20050000);

            // equator to north pole distance should be about ~10000km

            var equator = new Tuple<double, double>(0, 0);
            var dist2 = Formulas.DistanceBetween2Coords(northPole, equator);
            Assert.Greater(dist2, 10000000);
            Assert.Less(dist2, 10025000);

            Console.WriteLine(dist2);
        }
    }
}
