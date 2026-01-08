---
date: '2025-03-03T11:55:30+03:30'
draft: false
title: 'Event Sourcing: Turning Your App into a Time Machine'
tags: ["event_sourcing", "csharp", "dotnet", "basics", "beginners","programmer","programming", "learning", "learning_programming", "development", "event_source"]
categories: ["csharp"]
description: "Hey everyone! Kamran here, and today, let's dive deeper into Event Sourcing, especially how we manage snapshots and materialized views."
---
Hey everyone! Kamran here, and today, let’s dive deeper into Event Sourcing, especially how we manage snapshots and materialized views. If you’ve ever felt like your database only tells you the “now” and not the “how,” you’re going to love this.

Imagine your application’s memory as a time machine. Instead of just saving the final result, what if you recorded every single change, every action, as an “event”? That’s event sourcing in a nutshell.

What’s the Big Deal? 
-----------------------------------------------------------

Think of a traditional database. You update a record, and the old data is gone. Poof! With event sourcing, every update is a new event, like “Product Added to Cart,” “Order Shipped,” or “Price Changed.” You keep a full, immutable history.

**Why is this awesome?**

*   **Perfect Audit Trail:** Need to know exactly how a product’s price changed over time? Easy. Event sourcing gives you a complete, detailed audit trail. This is gold for compliance, debugging, and understanding your business processes.
*   **Time Travel Debugging:** Ever wish you could rewind your application to see what happened? With event sourcing, you can. You can replay events to reconstruct any past state.
*   **CQRS BFFs:** Event sourcing and CQRS (Command Query Responsibility Segregation) go together like peanut butter and jelly. CQRS separates your “write” (command) and “read” (query) operations. Event sourcing fits perfectly into the “write” side, generating those immutable events.

The How-To: Hydration vs. Replay 
-----------------------------------------------------------------------------------

Okay, so you have all these events. How do you get the current state? That’s where **hydration** comes in. It’s like rebuilding your current state on demand by replaying the necessary events.

But what about **replay**? That’s when you regenerate the _entire_ system state, usually for debugging or migrating data.

**Example:**

Let’s say we have an e-commerce system:

    // Event: ProductAddedToCart
    public class ProductAddedToCart
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    
    // Event: OrderShipped
    public class OrderShipped
    {
        public Guid OrderId { get; set; }
    }
    
    // Hydrating the cart state
    public class ShoppingCart
    {
        public Dictionary<Guid, int> Items { get; set; } = new Dictionary<Guid, int>();
    
        public void Apply(ProductAddedToCart @event)
        {
            if (Items.ContainsKey(@event.ProductId))
            {
                Items[@event.ProductId] += @event.Quantity;
            }
            else
            {
                Items[@event.ProductId] = @event.Quantity;
            }
        }
    
        // ... other apply methods for each event
    }
    

Speeding Things Up: Snapshots and Materialized Views 
----------------------------------------------------------------------------------------------------------------------------

Replaying tons of events can be slow. That’s why we use snapshots and materialized views.

Snapshots: Your State Checkpoints 
--------------------------------------------------------------------------------------

### What is a snapshot? 

A snapshot is a saved state of an aggregate (like our `ShoppingCart`) at a specific point in time. It’s like taking a picture of the current state, so you don’t have to replay every single event every time.

### Where do we store snapshots? 

Snapshots can be stored in various ways:

*   **Separate Table:** You can create a dedicated table in your database to store snapshots. Each row would contain the aggregate ID, the snapshot data (often serialized), and a version or timestamp.
*   **Files:** For simpler applications, you could serialize snapshots to files (e.g., JSON or binary) and store them in a file system or cloud storage.
*   **NoSQL Database:** NoSQL databases like Redis or MongoDB are also excellent for storing snapshots due to their flexibility and performance.

### Example (Conceptual): 

    // Snapshot class
    public class ShoppingCartSnapshot
    {
        public Guid CartId { get; set; }
        public Dictionary<Guid, int> Items { get; set; }
        public int Version { get; set; } // Or a timestamp
    }
    
    // Saving a snapshot
    void SaveSnapshot(ShoppingCart cart, int version)
    {
        var snapshot = new ShoppingCartSnapshot
        {
            CartId = cart.CartId,
            Items = cart.Items,
            Version = version
        };
        // Store snapshot in database/file/etc.
    }
    
    // Loading a snapshot
    ShoppingCart LoadSnapshot(Guid cartId)
    {
        // Retrieve snapshot from database/file/etc.
        // ...
        var snapshot = RetrieveSnapshot(cartId); // Assuming a function to get the snapshot
        var cart = new ShoppingCart();
        cart.Items = snapshot.Items;
        return cart;
    }
    
    public ShoppingCartSnapshot RetrieveSnapshot(Guid cartId)
    {
     //Implementation needed for the specific persistence strategy
       return new ShoppingCartSnapshot(); // Dummy code
    }
    

Materialized Views: Real-Time Read Models 
------------------------------------------------------------------------------------------------------

### What are materialized views? 

Materialized views are pre-calculated read models that are updated in real-time as events come in. They’re perfect for fast queries and reporting.

### How do we implement materialized views? 

*   **Event Listeners:** Create event listeners that subscribe to relevant events.
*   **Read Model Updates:** When an event occurs, the listener updates the corresponding read model in the materialized view.
*   **Storage:** Store the materialized views in a database optimized for read operations.

### Example (Conceptual): 

Let’s create a materialized view to show the total number of items in all shopping carts.

    // Materialized view
    public class ShoppingCartItemCountView
    {
        public int TotalItems { get; set; }
    }
    
    // Event listener
    public class ShoppingCartEventListener
    {
        private readonly ShoppingCartItemCountView _view;
    
        public ShoppingCartEventListener(ShoppingCartItemCountView view)
        {
            _view = view;
        }
    
        public void Handle(ProductAddedToCart @event)
        {
            // Update the materialized view
            _view.TotalItems += @event.Quantity;
            // Save the updated view (Implementation depends on the storage mechanism)
        }
    }
    

Implementation details 
-----------------------------------------------------------------

You can use message queues like RabbitMQ or Kafka to propagate events to your event listeners.

Databases like postgres can create actual materialized views that automatically update.

For simple implementations you can just update a table in your database.

CQRS and Event Sourcing: A Perfect Match 
----------------------------------------------------------------------------------------------------

With CQRS, commands generate events, and queries use read models. Event sourcing provides the event store, and materialized views become your read models.

Real-world Example: 
----------------------------------------------------------

In an e-commerce system, a “Place Order” command generates an “OrderPlaced” event. A separate read model (materialized view) then updates the order status displayed to the user.

Event Propagation: Keeping Things Real-Time 
----------------------------------------------------------------------------------------------------------

In an event-sourced system, it’s crucial that changes propagate throughout the system promptly. This ensures that all components, especially read models and other services, stay up-to-date. This is where event propagation comes in.

### What is Event Propagation? 

Event propagation involves distributing events to various components of the system as soon as they occur. This allows different parts of the application to react in real-time.

### How Does It Work? 

1.  **Event Generation:** When a command is executed, it generates an event.
2.  **Event Store:** The event is persisted in the event store.
3.  **Event Bus/Message Broker:** The event is published to an event bus or message broker (e.g., RabbitMQ, Kafka, Azure Service Bus).
4.  **Event Listeners:** Various components subscribe to the event bus and listen for relevant events.
5.  **Event Handling:** When an event is received, the listener processes it and updates its local state or triggers other actions.

### Example: Real-Time Order Status Updates 

Let’s illustrate this with an example from our e-commerce system. Suppose a customer places an order, and we want to update the order status in real-time for the customer’s view.

1.  **Command Execution:** The “Place Order” command is executed.
2.  **Event Generation:** The “OrderPlaced” event is generated.
3.  **Event Store:** The “OrderPlaced” event is stored in the event store.
4.  **Event Bus:** The event is published to a message broker (e.g., Kafka).
5.  **Order Status Listener:** A component responsible for updating the order status listens for “OrderPlaced” events.
6.  **Read Model Update:** Upon receiving the event, the listener updates the “Order Status” read model (materialized view) in the database.
7.  **User Interface Update:** The user interface, which is subscribed to changes in the “Order Status” read model, automatically updates the displayed order status in real-time.

### Code Example (Conceptual): 

    // Event: OrderPlaced
    public class OrderPlaced
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        // ... other order details
    }
    
    // Event Listener
    public class OrderStatusListener
    {
        //...implementation needed
    }
    

### You can follow me on the LinkedIn, YouTube, Telegram Group to discuss, and directly send me email. 

*   [Telegram Group](https://t.me/sadinco_csharp)
*   [LinkedIn](https://linkedin.com/in/MrSadin)
*   [Blog](https://blog.sadin.dev)
*   [YouTube](https://youtube.com/c/EnKamran)