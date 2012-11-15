using System;
using MyMessages;
using NServiceBus;

namespace MySender
{
    public class FooReplyMessageHandler : IHandleMessages<FooReplyMessage>
    {
        public void Handle(FooReplyMessage message)
        {
            if (message == null)
            {
                throw new Exception("Outrageous!");
            }

            Console.WriteLine("Handling reply message: {0}", message.Baz);
        }
    }
}
