using System;
using ParkingLot.App.CommandHandlers;

namespace ParkingLot.App
{
    public class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Program Running");

            var parkingLotService = new ParkingLotService();            
            if (args.Length > 0)
            {                
                parkingLotService.RunFromFile(args[0]);                
            }            
            else
            {
                parkingLotService.Run();
            }

            Console.ReadKey();
        }
    }
}
