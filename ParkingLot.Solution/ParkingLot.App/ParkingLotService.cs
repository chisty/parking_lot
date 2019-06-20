using System;
using System.IO;
using ParkingLot.App.CommandHandlers;
using ParkingLot.App.Models;

namespace ParkingLot.App
{
    public class ParkingLotService
    {
        private ParkingLotManager ParkingLotManager { get; }
        private CommandHandlersFactory CommandHandlersFactory { get; set; }

        public ParkingLotService()
        {
            ParkingLotManager = new ParkingLotManager();
            CommandHandlersFactory= new CommandHandlersFactory();
        }

        public void Run()
        {
            string line;

            do
            {
                line = Console.ReadLine();
                if (line==null || line.ToLower().Equals("exit")) break;

                ExecuteCommand(line);
            } while (!string.IsNullOrEmpty(line) && !line.ToLower().Equals("exit"));
        }        

        public void RunFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("File found. Path= "+filePath);
            }
            else
            {
                Console.WriteLine("File not found");
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                ExecuteCommand(line);
            }
        }


        private void ExecuteCommand(string line)
        {
            var commandHandler = CommandHandlersFactory.GetHandler(line);
            if (commandHandler != null)
            {
                commandHandler.Handle(line, ParkingLotManager);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}
