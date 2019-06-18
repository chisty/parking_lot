using System;
using ParkingLot.App.CommandHandlers;
using ParkingLot.App.Models;

namespace ParkingLot.App
{
    public class Program
    {
        static void Main(string[] args)
        {            
            var parkingManager = new ParkingLotManager();
            parkingManager.Run();

        }
    }
}
