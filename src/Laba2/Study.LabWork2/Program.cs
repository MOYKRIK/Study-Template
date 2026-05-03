using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        int start = 1;
        int end = 10000;
        int threadCount = 4;
        int expected = 1229;

        var services = new List<IPrimeCounter>
        {
            new MonitorService(),
            new MutexService(),
            new SemaphoreService()
        };

        var results = new List<PrimeCountResultDto>();

        Console.WriteLine("=== START ===\n");

        foreach (var service in services)
        {
            Console.WriteLine($"--- {service.GetVersionName()} ---");

            var result = service.CountPrimes(start, end, threadCount);

            Console.WriteLine(result);
            Console.WriteLine($"Корректность: {(result.IsValid(expected) ? "OK" : "FAIL")}");
            Console.WriteLine();

            results.Add(result);
        }

        Console.WriteLine("=== SUMMARY ===\n");

        foreach (var r in results)
        {
            Console.WriteLine(r.ToShortString());
        }

        Console.WriteLine("\n=== BEST ===");

        var best = results.OrderBy(r => r.ExecutionTime).First();

        Console.WriteLine($"Самый быстрый: {best.SynchronizationType}");
    }
}
