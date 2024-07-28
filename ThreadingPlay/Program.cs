class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main thread started");
        await DownloadTask1();
        await Task.WhenAll(DownloadTask2(), DownloadTask3(), DownloadTask1());
        await Task.WhenAny(DownloadTask2(), DownloadTask3(), DownloadTask1());
        Console.WriteLine("Main thread completed");
    }

    private static Task DownloadTask1()
    {
        Thread.Sleep(5000);
        Console.WriteLine("DownloadTask1 completed");
        return Task.CompletedTask;
    }
    
    private static Task DownloadTask2()
    {
        Thread.Sleep(5000);
        Console.WriteLine("DownloadTask2 completed");
        return Task.CompletedTask;
    }
    
    private static Task DownloadTask3()
    {
        Thread.Sleep(5000);
        Console.WriteLine("DownloadTask3 completed");
        return Task.CompletedTask;
    }
}

