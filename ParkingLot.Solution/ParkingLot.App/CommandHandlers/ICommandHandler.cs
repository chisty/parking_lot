using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public interface ICommandHandler
    {
        void Handle(string input, ParkingLotManager parkingLotManager);
        bool CanHandleInput(string input);
    }
}
