using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop
{


    /// <summary>
    /// Class that repesents a Car
    /// </summary>
    public class Car : Vehicle
    {

        /// <summary>
        /// Make of Car
        /// </summary>
        public string Make { get; set; } = null!;

        /// <summary>
        /// Model of Car
        /// </summary>
        public string Model { get; set; } = null!;

       
       
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <remarks>Initrialize all properties.</remarks>
        public Car()
        {
            Make = RandomMake();
            Model = RandomModel();
            Speed = 0;
            TopSpeed = Vehicle.random.Next(50, 150);
            Cost = random.Next(5000, 15000); 
            Color = RandomColor();
            
        }
        /// <summary>
        /// Constructor used to initlize properties
        /// </summary>
        /// <param name="make">Car Make</param>
        /// <param name="model">Car Model</param>
        /// <param name="topspeed">Top Speed</param>
        /// <param name="color">Color of car</param>
        /// <param name="cost">Cost of car</param>
        public Car(string make, string model, int topspeed, string color, int cost)
        {
            
            Make = make;
            Model = model;
            Speed = 0;
            TopSpeed = topspeed;
            Color = color;
            Cost = cost;
           
        }

        /// <summary>
        /// Build a car based on uesr input
        /// </summary>
        /// <returns></returns>
        public static Car CreateCar()
        {
            Car retValue = new Car();

            retValue.Make = PromptInput("What is the name of your car's make");
            retValue.Model = PromptInput("What is the name of your car's model");
            retValue.Color = PromptInput("What is the color of your color");
            retValue.TopSpeed = int.Parse(PromptInput("How Fast can your car go",true));
            return retValue;
        }

        /// <summary>
        /// Gets a Random Model
        /// </summary>
        /// <returns></returns>
        public virtual string RandomModel()
        {
            int i = random.Next(0, (int)VehicleModelEnum.MaxModel);
            return ((VehicleModelEnum)i).ToString();
        }

        /// <summary>
        /// Gets a Random Model
        /// </summary>
        /// <returns></returns>
        public virtual string RandomMake()
        {
            int i = random.Next(0, (int)VehicleMakeEnum.MaxMake);
            return ((VehicleMakeEnum)i).ToString();
        }

        /// <summary>
        /// Display a car
        /// </summary>
        public override string Display()
        {
            string message = "";
            if (IsRunning)
            {
                message = $" - Traveling {this.Traveled} at {this.Speed}";
            }
            else
            {
                message = $" - Is Running {IsRunning}";
            }
            return $"Type: Car - Make: {Make} - Model: {Model} - Color: {Color} - Cost: {Cost} {message}";
        }

        /// <summary>
        /// Make a sound
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine("HONK!!!");
          
        }

        /// <summary>
        /// Displays the car
        /// </summary>
        /// <returns>String that can be use to disply this car.</returns>
        public override string ToString()
        {
            string message = "";
            if (IsRunning)
            {
                message = $"\n Traveling {this.Traveled} at {this.Speed}";
            }
            else
            {
                message = $"\n Is Running {IsRunning}";
            }
            return $"Make: {Make} \nModel: {Model} \nTop Speed: {TopSpeed} \nCost: {Cost} \nColor {Color}{message}";
        }
    }
}
