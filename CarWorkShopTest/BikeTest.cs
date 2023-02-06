using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShopTest
{

    /// <summary>
    /// Run Bike Test
    /// </summary>
    [TestFixture]
    public class BikeTest : VehicleTest
    {
        [SetUp]
        public void Setup()
        {
            vehicle = new Bike();
        }

        private Bike GetBike { get => (Bike)vehicle; }

        /// <summary>
        /// Max Value for Cost of Vehicle
        /// </summary>
        [Test]
        public void Max_Bike_Cost()
        {
            Assert.Less(GetBike.Cost, 500);
        }

    }
}
