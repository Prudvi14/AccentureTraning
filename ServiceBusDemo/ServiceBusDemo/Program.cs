using Azure.Messaging.ServiceBus;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Service Bus Topic - Connection
        string connectionString = "";
        string topicName = "firsttopic";

        await using var client = new ServiceBusClient(connectionString);

        // 2. Create a sender for the topic
        ServiceBusSender sender = client.CreateSender(topicName);

        // 3. Send the message
        await sender.SendMessageAsync(new ServiceBusMessage("My First Msg to Topic"));

        Console.WriteLine("Message sent successfully......");
    }
}