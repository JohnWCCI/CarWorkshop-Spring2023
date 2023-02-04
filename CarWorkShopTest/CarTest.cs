namespace CarWorkShopTest
{
    /// <summary>
    /// Run Car Test
    /// </summary>
    [TestFixture]
    public class CarTests : VehicleTest
    {
        
        [SetUp]
        public void Setup()
        {
            vehicle = new Car();
        }

        private Car GetCar { get => (Car)vehicle; }

        /// <summary>
        /// Max Value for Cost of Vehicle
        /// </summary>
        [Test]
        public void Max_Car_Cost()
        {
            Assert.Less(GetCar.Cost, 15000);
        }

        

        [Test]
        public void Model()
        {

            Assert.Pass();
        }
    }
}