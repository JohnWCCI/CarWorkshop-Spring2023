

using CarWorkshop;

namespace CarWorkShopTest
{
    /// <summary>
    ///Common Vehicle Test
    /// </summary>
    [TestFixture]
    public abstract class VehicleTest
    {
        protected Vehicle vehicle;


        /// <summary>
        /// Current Speed of Vehicle is equal to or Greater than Zero Test
        /// </summary>
        [Test]
        public void Vehicle_Speed_Equal_Greater_Than_Zero ()
        {
            Assert.Greater(vehicle.Speed,-1);
        }
        /// <summary>
        /// Top Speed of Vehicle is  Greater than zero
        /// </summary>
        [Test]
        public void Vehicle_TopSpeed_Greater_Than_Zero ()
        {
            Assert.Greater(vehicle.TopSpeed,0);
        }
        /// <summary>
        /// Top Speed of Vehicle should be greater then Current Speed
        /// </summary>
        [Test]
        public void Vehicle_TopSpeed_Greater_Than_Current_Speed()
        {
            Assert.Greater(vehicle.TopSpeed, vehicle.Speed);
        }
       
    }
}
