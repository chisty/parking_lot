using ParkingLot.App.CommandHandlers;

namespace ParkingLot.App
{
    public class Program
    {
        static void Main(string[] args)
        {            
            var parkingManager = new ParkingLotManager();
            parkingManager.Run();

        }
    }
}
