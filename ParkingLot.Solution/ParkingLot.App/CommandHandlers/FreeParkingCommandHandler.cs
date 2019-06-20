using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class FreeParkingCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2 && int.TryParse(tokens[1], out var slot))
            {
                parkingLotManager.LeaveParking(slot);
                Console.WriteLine($"Slot number {slot} is free");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("leave");
        }
    }
}