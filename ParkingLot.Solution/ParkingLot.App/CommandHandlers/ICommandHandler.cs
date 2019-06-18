using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.App.CommandHandlers
{
    public interface ICommandHandler
    {
        bool CanHandleInput(string input);
    }
}
