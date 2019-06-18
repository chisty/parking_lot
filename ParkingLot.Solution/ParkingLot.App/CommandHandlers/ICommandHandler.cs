using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public interface ICommandHandler
    {
        void Handle(string input, ParkingLotData parkingLotData);
        bool CanHandleInput(string input);
    }
}
