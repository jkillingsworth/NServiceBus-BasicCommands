using System;
using MyMessages;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace MySender
{
    class Program
    {
        static void StartupAction()
        {
            Configure.Instance.ForInstallationOn<Windows>().Install();
        }

        static void Main()
        {
            Console.WriteLine("This is the sender.");

            var bus = Configure.With()
                .DefaultBuilder()
                .DisableTimeoutManager()
                .UnicastBus()
                .CreateBus()
                .Start(StartupAction);

            while (true)
            {
                var input = Console.ReadLine();

                Console.WriteLine("Sending: {0}", input);

                var command = new FooCommand { Bar = input };
                var callback = bus.Send(command);

                callback.Register<FooStatus>(x => Console.WriteLine("Return code: {0}", x));
            }
        }
    }
}
