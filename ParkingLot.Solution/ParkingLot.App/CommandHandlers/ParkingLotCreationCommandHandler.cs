using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class ParkingLotCreationCommandHandler: ICommandHandler
    {
        public void Handle(string input, CarParkingLot carParkingLot)
        {
            var tokens = input.Split(' ');
            if(tokens.Length == 2 && int.TryParse(tokens[1], out var size))
            {
                carParkingLot.SetEmptyLots(size);
                Console.WriteLine($"Created a parking lot with {size} slots");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("create_parking_lot");
        }
    }

    public class DisplayStatusCommandHandler : ICommandHandler
    {
        public void Handle(string input, CarParkingLot carParkingLot)
        {
            throw new NotImplementedException();
        }

        public bool CanHandleInput(string input)
        {
            return false;
        }
    }
}
