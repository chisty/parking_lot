using System;
using ParkingLot.App.Models;

namespace ParkingLot.App.CommandHandlers
{
    public class ParkingLotManager
    {
        private ParkingLotData ParkingLot { get; }
        private CommandHandlersFactory CommandHandlersFactory { get; set; }

        public ParkingLotManager()
        {
            ParkingLot = new ParkingLotData();
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
                    commandHandler.Handle(line, ParkingLot);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            } while (!string.IsNullOrEmpty(line) && !line.ToLower().Equals("exit"));
        }
    }
}
