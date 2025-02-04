﻿using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class AllocateParkingCommandHandler : ICommandHandler
    {
        public void Handle(string input, ParkingLotManager parkingLotManager)
        {
            var firstEmptySlot = parkingLotManager.GetNextEmptyLot();
            if (firstEmptySlot == 0)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            var tokens = input.Split(' ');
            if (tokens.Length == 3)
            {
                var car = new Car {RegistrationNumber = tokens[1], Color = tokens[2]};
                parkingLotManager.ParkCar(car, firstEmptySlot);
                Console.WriteLine($"Allocated slot number: {firstEmptySlot}");
            }
        }

        public bool CanHandleInput(string input)
        {
            return input.ToLower().StartsWith("park");
        }
    }
}