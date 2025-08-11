# Azure Service Bus Topics Demo

A simple demonstration of Azure Service Bus topics and subscriptions using .NET 10.

## Overview

- **TopicSender**: Publishes a batch of 3 test messages to "mytesttopic"
- **SubscriptionReceiver**: Listens for and processes messages from subscription "S1", displaying content to console

## Technologies Used

- .NET 10
- Azure.Messaging.ServiceBus
- Azure.Identity

## Configuration

Applications connect to:
- **Service Bus Namespace**: myazuretopic.servicebus.windows.net
- **Topic**: mytesttopic
- **Subscription**: S1 (for receiver)
- **Authentication**: DefaultAzureCredential

## How to Run

```bash
# Run sender
cd TopicSender
dotnet run

# Run receiver (in separate terminal)
cd SubscriptionReceiver
dotnet run
```

## What It Does

**TopicSender**:
- Connects to Azure Service Bus using DefaultAzureCredential
- Creates and sends a batch of 3 messages to "mytesttopic"
- Handles cleanup and error scenarios

**SubscriptionReceiver**:
- Listens to subscription "S1" on "mytesttopic" 
- Processes incoming messages and displays content
- Marks messages as complete after processing
- Includes error handling for message processing