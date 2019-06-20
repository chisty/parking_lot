using System;
using System.Linq;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class DisplayStatusCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            Console.WriteLine("Slot No.    Registration No    Colour");

            var mapping = parkingLotManager.GetCarsBySlotMapping();
            foreach (var slot in mapping.Keys.OrderBy(o=> o))
            {
                Console.WriteLine("{0}{1}{2}", slot.ToString().PadRight(12), mapping[slot].RegistrationNumber.PadRight(19), mapping[slot].Color);
            }            
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("status");
        }
    }
}