using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class ParkingLotCreationCommandHandler: ICommandHandler
    {
        public void Handle(string input, ParkingLotData parkingLotData)
        {
            var tokens = input.Split(' ');
            if(tokens.Length == 2 && int.TryParse(tokens[1], out var size))
            {
                parkingLotData.SetEmptyLots(size);
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.StartsWith("create_parking_lot");
        }
    }

    public class AllocateParkingCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotData parkingLotData)
        {
            var firstEmptySlot = parkingLotData.GetNextEmptyLot();
            if (firstEmptySlot == 0)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            var tokens = input.Split(' ');
            if (tokens.Length == 3)
            {
                var car = new Car {RegistrationNumber = tokens[1], Color = tokens[2]};
                parkingLotData.ParkCar(car, firstEmptySlot);
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.StartsWith("park");
        }
    }

    public class FreeParkingCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    public class DisplayStatusCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    public class GetRegistrationNumberCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }
    public class GetSlotByRegistrationCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    public class GetSlotsByColorCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    
}
