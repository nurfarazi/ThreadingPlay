class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main thread started");
        var task1 = DownloadTask1(20);
        var task2 = DownloadTask2(10);
        var task3 = DownloadTask3(5);

        await Task.WhenAll(task1, task2, task3);
        await Task.WhenAny(task1, task2, task3);

        Console.WriteLine("Main thread completed");
    }

    private static async Task<int> DownloadTask1(int seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
        Console.WriteLine("DownloadTask1 completed");
        return seconds;
    }

    private static async Task<int> DownloadTask2(int seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
        Console.WriteLine("DownloadTask2 completed");
        return seconds;
    }

    private static async Task<int> DownloadTask3(int seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
        Console.WriteLine("DownloadTask3 completed");
        return seconds;
    }
}