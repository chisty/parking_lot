using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.App.Models;

namespace ParkingLot.App.Business
{
    public class CommandHandler
    {
        private ParkingLotData ParkingLot { get; }

        public CommandHandler(ParkingLotData parkingLot)
        {
            ParkingLot = parkingLot;
        }
    }
}
