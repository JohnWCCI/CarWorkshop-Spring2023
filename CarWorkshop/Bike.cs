
namespace CarWorkshop
{
    /// <summary>
    /// This is the Bike class
    /// </summary>
    public class Bike : Vehicle
    {
       /// <summary>
       /// Bike Brand
       /// </summary>
        public string Brand { get; set; } = null!;

        /// <summary>
        /// default Constructor 
        /// </summary>
        /// <remarks>Initrialize all properties.</remarks>
        public Bike()
        {
            Brand = RandomBrand();
            Color = RandomColor(); 
            Speed = 0;
            TopSpeed = 50;
            Cost = random.Next(100, 500);
            
        }

        /// <summary>
        /// Constructor used to initlize properties
        /// </summary>
        /// <param name="brand">Brand of Bike</param>
        /// <param name="color">Color of Bike</param>
        /// <param name="topSpeed">Spead of Bike</param>
        /// <param name="cost">Cost of Bike</param>
        public Bike( string brand, string color, int topSpeed, int cost)
        {
            Brand = brand;
            Color = color;
            Speed = 0;
            TopSpeed = topSpeed;
            Cost = cost;
        }

        /// <summary>
        /// Create a bike based on user input
        /// </summary>
        /// <returns>returns a value bike</returns>
        public static Bike CreateBike()
        {
            Bike bike = new Bike();
            bike.Brand = PromptInput("What is the name of your bike's brand?");
            bike.Color = PromptInput("What is the color of your bike?");
            bike.TopSpeed = int.Parse(PromptInput("How fast can your bike go?", true));

            return bike;
        }

        /// <summary>
        /// Random Brand
        /// </summary>
        /// <returns></returns>
        public virtual string RandomBrand()
        {
            int i = random.Next(0, (int)VehicleBrandEnum.MaxBrand);
            return ((VehicleBrandEnum)i).ToString();
        }

        /// <summary>
        /// Display Bike
        /// </summary>
        public override string Display()
        {
            return $"Type: Bike - Brand: {Brand} - Color: {Color} - Cost: {Cost}";
        }

        /// <summary>
        /// Bike makes a sound
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine("Ring!");
        }

        /// <summary>
        /// Display a bike
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Brand: {Brand} \nTop Speed: {TopSpeed} \nCost: {Cost}\nColor {Color}";
        }
    }
}
