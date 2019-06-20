using System;
using System.Linq;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class GetRegistrationNumberCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                var registrationsByColor = parkingLotManager.GetRegistrationNumbersByCarColor(tokens[1]);
                Console.WriteLine(registrationsByColor.Any() ? string.Join(", ", registrationsByColor) : "Not found");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("registration_numbers_for_cars_with_colour");
        }
    }
}