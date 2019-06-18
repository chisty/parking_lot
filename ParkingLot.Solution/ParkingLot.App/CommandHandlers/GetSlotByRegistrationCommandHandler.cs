using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class GetSlotByRegistrationCommandHandler : ICommandHandler
    {
        public void Handle(string input, CarParkingLot carParkingLot)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                var slot = carParkingLot.GetSlotByRegistrationNumber(tokens[1]);
                if (slot > 0)
                {
                    Console.WriteLine(slot);
                }
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().Equals("slot_number_for_registration_number");
        }
    }
}