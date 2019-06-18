using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class DisplayStatusCommandHandler : ICommandHandler
    {
        public void Handle(string input, CarParkingLot carParkingLot)
        {
            Console.WriteLine("Slot No.\tRegistration No\tColour");

        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("status");
        }
    }
}