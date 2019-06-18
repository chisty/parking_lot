using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class GetSlotsByColorCommandHandler : ICommandHandler
    {
        public void Handle(string input, CarParkingLot carParkingLot)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                var slots = carParkingLot.GetSlotNumbersOfCarByColor(tokens[1]);
                Console.WriteLine(string.Join(", ", slots));
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().Equals("slot_numbers_for_cars_with_colour");
        }
    }
}