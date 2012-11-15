using NServiceBus;

namespace MyMessages
{
    public class FooReplyMessage : IMessage
    {
        public string Baz { get; set; }
    }
}
