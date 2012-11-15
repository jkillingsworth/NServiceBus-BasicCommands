using System;
using System.Linq;
using MyMessages;
using NServiceBus;

namespace MyReceiver
{
    public class FooCommandHandler : IHandleMessages<FooCommand>
    {
        private readonly IBus bus;

        public FooCommandHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(FooCommand message)
        {
            if (message == null)
            {
                throw new Exception("Outrageous!");
            }

            Console.WriteLine("Handling command message: {0}", message.Bar);

            var baz = new string(message.Bar.Reverse().ToArray());

            bus.Return(FooStatus.Success);
            bus.Reply<FooReplyMessage>(x => { x.Baz = baz; });
            bus.Reply<FooReplyMessage>(x => { x.Baz = baz + " again"; });
        }
    }
}
