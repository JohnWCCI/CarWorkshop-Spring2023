

using CarWorkshop;

/// Create the Garage
Garage garage = new Garage();

int menu = -1;
while (menu != 0)
{
    menu = garage.Process();
}
Console.Clear();
