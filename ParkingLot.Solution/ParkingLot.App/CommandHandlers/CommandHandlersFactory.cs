using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.App.CommandHandlers
{
    public class CommandHandlersFactory
    {
        private List<ICommandHandler> Handlers { get; set; }
        public CommandHandlersFactory()
        {
            Handlers = new List<ICommandHandler> {new ParkingLotCreationCommandHandler(), new AllocateParkingCommandHandler()
                , new FreeParkingCommandHandler(), new DisplayStatusCommandHandler(), new GetRegistrationNumberCommandHandler()
                , new GetSlotByRegistrationCommandHandler(), new GetSlotsByColorCommandHandler()};
        }


        public ICommandHandler GetHandler(string input)
        {
            return Handlers.FirstOrDefault(h => h.CanHandleInput(input));
        }
    }
}
