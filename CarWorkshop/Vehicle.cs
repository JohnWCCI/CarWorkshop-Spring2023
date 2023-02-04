using System.Drawing;

namespace CarWorkshop
{
    /// <summary>
    /// Abstraction - making a generic class that can be inherited by children classes by lending functionality
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>
        /// Define a randow number Generator
        /// </summary>
        public static Random random = new Random(Environment.TickCount);

        /// <summary>
        /// Current Speed of Vehicle
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Top Speed of Vehicle
        /// </summary>
        public int TopSpeed { get; set; }
        /// <summary>
        /// Cost of Vehicle
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Color of Vehicle
        /// </summary>
        public string Color { get; set; } = null!; // Add Null! to take care of warrning 

        /// <summary>
        /// Display Vehicle information
        /// </summary>
        public abstract string Display();

        /// <summary>
        /// Vehicle to make sound.
        /// </summary>
        public abstract void MakeSound();

        /// <summary>
        /// Get a Random Color
        /// </summary>
        /// <returns></returns>
        public virtual string RandomColor()
        {
            int i = random.Next(0, (int)VehicleColorEnum.MaxColor);
            return ((VehicleColorEnum)i).ToString();
        }

        /// <summary>
        /// Change Cost of Vehicle
        /// </summary>
        /// <param name="cost">int value of the change can be - or + values</param>
        /// <remarks>This method can be override</remarks>
        public virtual void ChangeCost(int cost)
        {
            this.Cost = +cost;
        }

        /// <summary>
        /// Clears the screen and displays a prompt
        /// </summary>
        /// <param name="prompt"></param>
        public static void ClearScreen(string prompt = "")
        {
            Console.Clear();
            Console.WriteLine("Type EXIT to quit");
            Console.WriteLine();
            if(!string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine(prompt);
            }


        }

        /// <summary>
        /// Gets input from user base on a display value
        /// </summary>
        /// <param name="display">Display value.</param>
        /// <returns>Keyborad input.</returns>
        public static string PromptInput(string display, bool isInteger = false)
        {
            //Initialize return value
            string retValue = string.Empty;
            //Display prompt
            Console.Write($"{display}? ");


            //loop until a user inputs a value
            while (string.IsNullOrEmpty(retValue))
            {
                // Get keyboard input
                var line = Console.ReadLine();

                // check if the user wants to exit
                if(line is not null && line.ToUpper() == "EXIT")
                {
                   Environment.Exit(0);  
                }
                // checks input for value
                if (line != null)
                    retValue = line;

                // Check for int value
                if (isInteger)
                {
                    int intValue;
                    // if not an value then set retValue to empty and try again.
                    if (!int.TryParse(line, out intValue))
                    {
                        retValue = string.Empty;
                    }
                }
            }
            // return value.
            return retValue;
        }
    }
}
