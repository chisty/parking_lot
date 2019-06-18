using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class ParkingLotManager
    {
        private CarParkingLot CarParkingLot { get; }
        private CommandHandlersFactory CommandHandlersFactory { get; set; }

        public ParkingLotManager()
        {
            CarParkingLot = new CarParkingLot();
            CommandHandlersFactory= new CommandHandlersFactory();
        }

        public void Run()
        {
            string line;

            do
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line) || line.ToLower().Equals("exit")) break;

                var commandHandler = CommandHandlersFactory.GetHandler(line);
                if (commandHandler != null)
                {
                    commandHandler.Handle(line, CarParkingLot);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            } while (!string.IsNullOrEmpty(line) && !line.ToLower().Equals("exit"));
        }
    }
}
