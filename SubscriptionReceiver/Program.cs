using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Identity;

// client to create senders and receivers
ServiceBusClient client;

// processor to process messages from a subscription
ServiceBusProcessor processor;

// create a client to connect and process messages 
client = new ServiceBusClient(
    "<your-namespace>.servicebus.windows.net",
     new DefaultAzureCredential ());

// create a processor to process messages from a subscription
processor = client.CreateProcessor(
    "<your-topic-name>",
    "<your-subscription-name>",
    new ServiceBusProcessorOptions());

try
{
    // add handler to process messages 
    processor.ProcessMessageAsync += Messagehandler;

    // add handler to process any errors 
    processor.ProcessErrorAsync += ErrorHandler;

    // start processing
    await processor.StartProcessingAsync();

    Console.WriteLine("wait for a minute and then press any key to end the processing");
    Console.ReadKey();

    // stop processing
    Console.WriteLine("\nStopping the receiver...");
    await processor.StopProcessingAsync();
    Console.WriteLine("Stopped receiving messages from the subscription.");
}

finally
{
    // clean up resources 
    await processor.DisposeAsync();
    await client.DisposeAsync();
}
// handle received messages 
async Task Messagehandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body} from subscription."); ;

    await args.CompleteMessageAsync(args.Message);
}


// handle errors while receiving messages 
Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}