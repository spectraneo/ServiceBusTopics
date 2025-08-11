using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Identity;

// client to create senders and receivers 
ServiceBusClient client;

// sender to publish messsages to a topic 
ServiceBusSender sender;

// number of messages to be sent to the topic 
const int numOfMessages = 3;

// create a client to connect to our Service Bus namespace
client = new ServiceBusClient(
    "<your-namespace>.servicebus.windows.net",
    new DefaultAzureCredential());

sender = client.CreateSender("<your-topic-name>");

// create a batch
using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
for (int i = 1; i <= numOfMessages; i++)
{
    // try adding a message to the batch 
    if(!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        // if the message is too large to fit in the batch, throw an exception
        throw new Exception($"Message {i} is too large to fit in the batch.");
    }
}

try
{
    // send the batch of messages to the topic 
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of {numOfMessages} messages have been published to the topic. ");
}
finally 
{
    //close the sender 
    await sender.DisposeAsync();

    // close the client 
    await client.DisposeAsync();
}


Console.WriteLine("Press any key to end the application");
Console.ReadKey();