using NServiceBus;

namespace MyMessages
{
    public class FooCommand : ICommand
    {
        public string Bar { get; set; }
    }
}
