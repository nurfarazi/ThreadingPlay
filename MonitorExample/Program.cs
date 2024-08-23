namespace MonitorExample;

class Program
{
    static void Main()
    {
        var orderProcessor = new OrderProcessor();

        // Simulate producers adding orders
        Task.Run(() =>
        {
            for (var i = 1; i <= 5; i++)
            {
                orderProcessor.AddOrder($"Order {i}");
                Thread.Sleep(1000); // Simulate some delay between orders
            }
        });

        // Simulate consumers processing orders
        Task.Run(() =>
        {
            for (var i = 1; i <= 5; i++)
            {
                var order = orderProcessor.ProcessNextOrder();
                Console.WriteLine($"Processing {order}...");
                Thread.Sleep(2000); // Simulate order processing time
            }
        });

        Console.ReadLine(); // Keep the console open to observe output
    }
}

public class OrderProcessor
{
    private readonly Queue<string> _orderQueue = new();
    private readonly object _queueLock = new(); // Lock for synchronizing queue access

    public void AddOrder(string order)
    {
        lock (_queueLock)
        {
            _orderQueue.Enqueue(order);
            Monitor.Pulse(_queueLock); // Signal a waiting consumer
        }
    }

    public string ProcessNextOrder()
    {
        lock (_queueLock)
        {
            while (_orderQueue.Count == 0)
            {
                Monitor.Wait(_queueLock); // Wait for a signal from a producer
            }

            return _orderQueue.Dequeue();
        }
    }
}