using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class GetRegistrationNumberCommandHandler : ICommandHandler
    {
        public void Handle(string input, CarParkingLot carParkingLot)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                var registrationsByColor = carParkingLot.GetRegistrationNumbersByCarColor(tokens[1]);                
                Console.WriteLine(string.Join(", ", registrationsByColor));
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("registration_numbers_for_cars_with_colour");
        }
    }
}