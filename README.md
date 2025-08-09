# Azure Service Bus Topics and Subscriptions (.NET)

A learning project demonstrating Azure Service Bus topics and subscriptions using .NET 10 and the Azure.Messaging.ServiceBus SDK.

## 📋 Overview

This repository contains two console applications that demonstrate the publish-subscribe messaging pattern using Azure Service Bus topics and subscriptions:

- **TopicSender**: Publishes messages to an Azure Service Bus topic
- **SubscriptionReceiver**: Receives messages from topic subscriptions

## 🏗️ Project Structure

```
ServiceBusTopics/
├── TopicSender/                    # Message publisher application
│   ├── TopicSender.csproj         # Project file with Azure Service Bus dependencies
│   └── Program.cs                 # Main application logic for sending messages
├── SubscriptionReceiver/          # Message subscriber application
│   ├── SubscriptionReceiver.csproj # Project file with Azure Service Bus dependencies
│   └── Program.cs                 # Main application logic for receiving messages
└── README.md                      # This file
```

## 🚀 Technologies Used

- **.NET 10**: Target framework
- **Azure.Messaging.ServiceBus 7.20.1**: Azure Service Bus client library
- **Azure.Identity 1.14.2**: Azure authentication library

## 📚 Azure Service Bus Concepts

### Topics and Subscriptions
- **Topic**: A communication channel that can have multiple subscribers
- **Subscription**: A virtual queue that receives copies of messages sent to a topic
- **Publisher**: Sends messages to a topic (TopicSender)
- **Subscriber**: Receives messages from subscriptions (SubscriptionReceiver)

### Key Benefits
- **Decoupling**: Publishers and subscribers don't need to know about each other
- **Scalability**: Multiple subscribers can process messages independently
- **Filtering**: Subscriptions can filter messages based on properties
- **Durability**: Messages are persisted until successfully processed

## 🛠️ Prerequisites

1. **Azure Subscription**: You need an active Azure subscription
2. **Azure Service Bus Namespace**: Create a Service Bus namespace in Azure portal
3. **Azure Service Bus Topic**: Create a topic within your namespace
4. **Topic Subscriptions**: Create one or more subscriptions for the topic
5. **.NET 10 SDK**: Install the latest .NET 10 SDK

## ⚙️ Setup Instructions

### 1. Azure Service Bus Setup

1. **Create Service Bus Namespace**:
   - Go to Azure Portal
   - Create a new Service Bus namespace
   - Choose your subscription, resource group, and region
   - Select a pricing tier (Basic, Standard, or Premium)

2. **Create a Topic**:
   - Navigate to your Service Bus namespace
   - Go to "Topics" and create a new topic
   - Configure settings like max topic size, message TTL, etc.

3. **Create Subscriptions**:
   - Under your topic, create one or more subscriptions
   - Configure subscription-specific settings and filters if needed

4. **Get Connection Information**:
   - Copy the connection string from "Shared access policies"
   - Note your topic name and subscription names

### 2. Application Configuration

Update both projects with your Azure Service Bus configuration:

```csharp
// Connection string from Azure portal
private const string ConnectionString = "your-connection-string-here";
private const string TopicName = "your-topic-name";
private const string SubscriptionName = "your-subscription-name";
```

### 3. Build and Run

```bash
# Build the solution
dotnet build

# Run the sender (in one terminal)
cd TopicSender
dotnet run

# Run the receiver (in another terminal)
cd SubscriptionReceiver
dotnet run
```

## 🔑 Key Features to Implement

### TopicSender Features
- [ ] Connect to Azure Service Bus topic
- [ ] Send single messages
- [ ] Send batch messages
- [ ] Add custom properties to messages
- [ ] Handle sending errors and retries

### SubscriptionReceiver Features
- [ ] Connect to Azure Service Bus subscription
- [ ] Receive messages using peek-lock mode
- [ ] Complete/abandon/dead-letter messages
- [ ] Handle receiving errors
- [ ] Process messages concurrently

## 💡 Learning Objectives

By working with this project, you'll learn:

1. **Basic Messaging Patterns**: Understanding pub/sub vs point-to-point messaging
2. **Azure Service Bus SDK**: Using the Azure.Messaging.ServiceBus library
3. **Message Lifecycle**: How messages flow through topics and subscriptions
4. **Error Handling**: Implementing retry policies and dead letter queues
5. **Authentication**: Using connection strings and Azure Identity
6. **Performance**: Batching, concurrent processing, and throughput optimization

## 📖 Common Scenarios to Explore

1. **Simple Messaging**: Send and receive basic text messages
2. **Structured Data**: Send JSON or XML payloads
3. **Message Properties**: Use custom properties for message routing
4. **Subscription Filters**: Filter messages based on properties
5. **Dead Letter Handling**: Process failed messages
6. **Session-based Messaging**: Ensure message ordering
7. **Scheduled Messages**: Send messages for future delivery

## 🔧 Troubleshooting

### Common Issues
- **Connection Problems**: Verify connection string and network connectivity
- **Authentication Errors**: Check access policies and permissions
- **Topic/Subscription Not Found**: Ensure resources exist in Azure
- **Message Size Limits**: Be aware of message size restrictions
- **Timeout Issues**: Configure appropriate timeout values

### Useful Azure CLI Commands
```bash
# List Service Bus namespaces
az servicebus namespace list

# List topics in a namespace
az servicebus topic list --namespace-name <namespace> --resource-group <rg>

# List subscriptions in a topic
az servicebus topic subscription list --namespace-name <namespace> --topic-name <topic> --resource-group <rg>
```

## 📚 Additional Resources

- [Azure Service Bus Documentation](https://docs.microsoft.com/en-us/azure/service-bus-messaging/)
- [Azure.Messaging.ServiceBus SDK Reference](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus)
- [Service Bus Best Practices](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-best-practices)
- [Azure Service Bus Samples](https://github.com/Azure/azure-service-bus/tree/master/samples)

## 🤝 Contributing

This is a learning project. Feel free to:
- Add new features or scenarios
- Improve error handling
- Add unit tests
- Enhance documentation
- Share your learning experiences

## 📄 License

This project is for educational purposes. Feel free to use and modify as needed for your learning journey.

---

**Happy Learning!** 🎓 Explore Azure Service Bus topics and subscriptions to build robust, scalable messaging solutions.