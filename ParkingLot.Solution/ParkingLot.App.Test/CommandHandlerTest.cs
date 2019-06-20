using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.App.CommandHandlers;
using ParkingLot.App.Models;
using Xunit;

namespace ParkingLot.App.Test
{
    public class CommandHandlerTest
    {
        public CommandHandlersFactory Factory { get; set; }

        public CommandHandlerTest()
        {
            Factory= new CommandHandlersFactory();
        }
       
        [Fact]
        public void ParkingLotCreationCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("create_parking_lot 6");
            Assert.NotNull(commandHandler);
            Assert.IsType<ParkingLotCreationCommandHandler>(commandHandler);
        }
        
        [Fact]
        public void AllocateParkingCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("park KA-01-HH-1234 White");
            Assert.NotNull(commandHandler);
            Assert.IsType<AllocateParkingCommandHandler>(commandHandler);
        }

        [Fact]
        public void FreeParkingCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("leave 4");
            Assert.NotNull(commandHandler);
            Assert.IsType<FreeParkingCommandHandler>(commandHandler);
        }

        [Fact]
        public void DisplayStatusCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("status");
            Assert.NotNull(commandHandler);
            Assert.IsType<DisplayStatusCommandHandler>(commandHandler);
        }

        [Fact]
        public void GetRegistrationNumberCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("registration_numbers_for_cars_with_colour White");
            Assert.NotNull(commandHandler);
            Assert.IsType<GetRegistrationNumberCommandHandler>(commandHandler);
        }

        [Fact]
        public void GetSlotByRegistrationCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("slot_number_for_registration_number KA-01-HH-3141");
            Assert.NotNull(commandHandler);
            Assert.IsType<GetSlotByRegistrationCommandHandler>(commandHandler);
        }

        [Fact]
        public void GetSlotsByColorCommandHandler_Test()
        {            
            var commandHandler = Factory.GetHandler("slot_numbers_for_cars_with_colour White");
            Assert.NotNull(commandHandler);
            Assert.IsType<GetSlotsByColorCommandHandler>(commandHandler);
        }
    }
}
