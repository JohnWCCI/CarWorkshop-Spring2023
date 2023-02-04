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

        public void Process()
        {
            while (true)
            {
                Vehicle.ClearScreen(Prompt);
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
                    default:
                        break;
                }
            }
        }

        public int DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Vehicle Menu");
            Console.WriteLine("1. Display Vehicles");
            Console.WriteLine("2. Buy a Vehicle");
            Console.WriteLine("3. Sell a Vehicle");
            Console.WriteLine();
            int menu = int.Parse(Vehicle.PromptInput("Select Option", true));
           
            return menu;
        }

        private void DisplayVehicle()
        {
            Console.Clear();
            if (vehicles.Count == 0)
                Console.WriteLine("No vehicals to Display");
            for(int x=0; x<vehicles.Count;x++) 
            {
                Console.WriteLine($"{x+1}. {vehicles[x].Display()}");
            }

           // var i = Vehicle.PromptInput("Any Key to return");
           Console.ReadLine();
        }
        private void BuyVehicle()
        {
            Vehicle.ClearScreen(Prompt);

            if (vehicles.Count >= maxVehicles)
            {
                Console.WriteLine($"No more roomn in the {name}'s Garage.");
            }
            else
            {
                int vehicletype = Vehicle.random.Next(1,3);
                if(vehicletype==1)
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

        private void SellVehicle()
        {
            Console.Clear();
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

    }
}
