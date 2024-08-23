namespace ThreadLock;

class Program
{
    static void Main(string[] args)
    {
        var product = new Product { Id = 1, Name = "Product 1" };
        product.AddStock(10);
        product.RemoveStock(5);
        product.Purchase(3);
        // simulate multiple threads trying to purchase the product
        var tasks = new List<Task>();
        
        for (var i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                product.Purchase(1);
            }));
        }
        
        Task.WaitAll(tasks.ToArray());
    }
}

class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    private int StockQuantity { get; set; }
    
    private readonly object _stockLock = new object(); // Lock for synchronizing stock updates

    public void AddStock(int quantity)
    {
        lock (_stockLock)
        {
            StockQuantity += quantity;
        }
    }   
    
    public void RemoveStock(int quantity)
    {
        lock (_stockLock)
        {
            StockQuantity -= quantity;
        }
    }
    
    public bool Purchase(int quantity)
    {
        lock (_stockLock) 
        {
            if (StockQuantity >= quantity)
            {
                StockQuantity -= quantity;
                Console.WriteLine("Purchase successful");
                return true; // Purchase successful
            }
            else
            {
                Console.WriteLine("Not enough stocks");
                return false; // Not enough stocks
            }
        }
    }
}