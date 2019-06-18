using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace ParkingLot.App.CommandHandlers
{
    [Export(typeof(ICommandHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ParkingLotCreationCommandHandler: ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    [Export(typeof(ICommandHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AllocateParkingCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    [Export(typeof(ICommandHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FreeParkingCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    [Export(typeof(ICommandHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DisplayStatusCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    [Export(typeof(ICommandHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetRegistrationNumberCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }
    public class GetSlotByRegistrationCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    [Export(typeof(ICommandHandler))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GetSlotsByColorCommandHandler : ICommandHandler
    {
        public bool CanHandleInput(string input)
        {
            return false;
        }
    }

    
}
