using System;
using NServiceBus;

namespace MyReceiver
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, IWantToRunWhenBusStartsAndStops
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .DisableTimeoutManager()
                .UnicastBus();
        }

        public void Start()
        {
            Console.WriteLine("This is the receiver.");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped.");
        }
    }
}
