using System;
using RabbitMQ.Client;
using System.Text;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    var message = "";

                    while(message.ToLower() != "q")
                    {
                        Console.WriteLine("Enter your message or enter 'q' to exit: ");
                        message = Console.ReadLine();

                        if(message.ToLower() == "q")
                            return;

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                                            routingKey: "hello",
                                            basicProperties: null,
                                            body: body);

                        message = "";
                    }
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
