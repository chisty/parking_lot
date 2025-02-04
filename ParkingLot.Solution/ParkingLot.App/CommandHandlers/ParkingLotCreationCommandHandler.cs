﻿using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class ParkingLotCreationCommandHandler: ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            var tokens = input.Split(' ');
            if(tokens.Length == 2 && int.TryParse(tokens[1], out var size))
            {
                parkingLotManager.SetEmptyLots(size);
                Console.WriteLine($"Created a parking lot with {size} slots");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("create_parking_lot");
        }
    }
}
