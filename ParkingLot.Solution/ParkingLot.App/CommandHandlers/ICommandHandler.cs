using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public interface ICommandHandler
    {
        void Handle(string input, CarParkingLot carParkingLot);
        bool CanHandleInput(string input);
    }
}
