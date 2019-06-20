using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class GetSlotByRegistrationCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                var slot = parkingLotManager.GetSlotByRegistrationNumber(tokens[1]);
                Console.WriteLine(slot > 0 ? slot.ToString() : "Not found");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("slot_number_for_registration_number");
        }
    }
}