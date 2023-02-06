namespace CarWorkshop
{
    public class Garage
    {
        private readonly int maxVehicles = 0;
        private readonly string name = string.Empty;
        private readonly List<Vehicle> vehicles = new List<Vehicle>();


        private string Prompt => $"Welcome to {name} Garage\nYou have {vehicles.Count} of {maxVehicles} in the garage";

        
        public Garage()
        {
            Vehicle.ClearScreen();
            while (maxVehicles <= 0)
            {
                name = Vehicle.PromptInput("What is the name of the Garage");
                maxVehicles = int.Parse(Vehicle.PromptInput("Number of Vehicles in Garage", true));
                if (maxVehicles <= 0)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("The number of Vehicles can not be less then or equal to 0");
                }

            }
        }

        /// <summary>
        /// Process Garage options
        /// </summary>
        /// <returns></returns>
        public int Process()
        {
            while (true)
            {
                Vehicle.ClearScreen(Prompt);
                TickAll();
                int menuSelection = DisplayMenu();
                switch (menuSelection)
                {
                    case 1:
                        DisplayVehicle();
                        break;
                    case 2:
                        BuyVehicle();
                        break;
                    case 3:
                        SellVehicle();
                        break;
                    case 4:
                        DriveVehicle();
                        break;
                    default:
                        break;
                }
                
                return menuSelection;

            }
        }

        /// <summary>
        /// Display menu
        /// </summary>
        /// <returns></returns>
        private int DisplayMenu()
        {

            Console.WriteLine();

            Console.WriteLine("Vehicle Menu");
            Console.WriteLine();
            Console.WriteLine("0. To exit");
            Console.WriteLine("1. Display Vehicles");
            Console.WriteLine("2. Buy a Vehicle");
            Console.WriteLine("3. Sell a Vehicle");
            Console.WriteLine("4. Drive a Vehicle");
            Console.WriteLine();
            int menu = int.Parse(Vehicle.PromptInput("Select Option", true));

            return menu;
        }

        /// <summary>
        /// Tick all vehicles in list
        /// </summary>
        private void TickAll()
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.Tick();
                vehicle.Display();
            }
        }

        /// <summary>
        /// Display all Vehicles
        /// </summary>
        private void DisplayVehicle()
        {
            Vehicle.ClearScreen("Display Vehicles"); 
            if (vehicles.Count == 0)
                Console.WriteLine("No vehicals to Display");
            for (int x = 0; x < vehicles.Count; x++)
            {
                Console.WriteLine($"{x + 1}. {vehicles[x].Display()}");
            }

            // var i = Vehicle.PromptInput("Any Key to return");
            Console.ReadLine();
        }

        /// <summary>
        /// Buy a random Vehicle
        /// </summary>
        private void BuyVehicle()
        {
            Vehicle.ClearScreen(Prompt);

            if (vehicles.Count >= maxVehicles)
            {
                Console.WriteLine($"No more roomn in the {name}'s Garage.");
            }
            else
            {
                int vehicletype = Vehicle.random.Next(1, 3);
                if (vehicletype == 1)
                {
                    vehicles.Add(new Car());
                }
                else
                {
                    vehicles.Add(new Bike());
                }
                Console.WriteLine();
                Console.WriteLine(vehicles[vehicles.Count - 1]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Sell a Vehicle
        /// </summary>
        private void SellVehicle()
        {
            Vehicle.ClearScreen("Sell a Vehicle");
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicals to Display");
            }
            else
            {
                for (int x = 0; x < vehicles.Count; x++)
                {
                    Console.WriteLine($"{x + 1}. {vehicles[x].Display()}");
                }

                var i = int.Parse(Vehicle.PromptInput("Select a Vehicle to Sell", true));
                if (i <= 0 || i > vehicles.Count)
                {
                    Console.WriteLine("Invalid vehicle to sell");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(vehicles[i - 1].ToString());
                    Console.WriteLine();
                    Console.WriteLine($"Sold");
                    vehicles.RemoveAt(i - 1);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Drive a Vehicle
        /// </summary>
        private void DriveVehicle()
        {
            Vehicle.ClearScreen("Drive a Vehicle");
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicals to Display");
            }
            else
            {
                for (int x = 0; x < vehicles.Count; x++)
                {
                    Console.WriteLine($"{x + 1}. {vehicles[x].Display()}");
                }

                var i = int.Parse(Vehicle.PromptInput("Select a Vehicle to Drive", true));
                if (i <= 0 || i > vehicles.Count)
                {
                    Console.WriteLine("Invalid vehicle to Drive");
                }
                else
                {
                    i--; // adjust for 0 index
                    Console.WriteLine();
                    Console.WriteLine(vehicles[i].ToString());
                    Console.WriteLine();

                    while (true)
                    {
                        var s = int.Parse(Vehicle.PromptInput("Speed of Vehicle to Drive", true));
                        if (s > vehicles[i].TopSpeed)
                        {
                            Console.WriteLine($" Try again Speed can not be greater {vehicles[i].TopSpeed}");
                        }
                        else
                        {
                            var d = int.Parse(Vehicle.PromptInput("How far to Drive Vehicle", true));
                            if (d > 0)
                            {
                                vehicles[i].Distance = d;
                                vehicles[i].Speed = s;
                                break;
                            }
                            Console.WriteLine($" Try again distance must be greater 0");
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }

}

