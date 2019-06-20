using System;
using System.Linq;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class GetSlotsByColorCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                var slots = parkingLotManager.GetSlotNumbersOfCarByColor(tokens[1]);
                Console.WriteLine(slots.Any() ? string.Join(", ", slots) : "Not found");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("slot_numbers_for_cars_with_colour");
        }
    }
}