using System;
using ParkingLot.App.Business;
using ParkingLot.App.Models;

namespace ParkingLot.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new ParkingLotData();
            var commandHandler = new CommandHandler(parkingLot);
        }
    }
}
