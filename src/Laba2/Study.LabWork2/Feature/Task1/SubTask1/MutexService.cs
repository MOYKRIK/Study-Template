using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 2. Использует Mutex для синхронизации
/// </summary>
public sealed class MutexService : IPrimeCounter
{
    private readonly Mutex _mutex = new();

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        int total = 0;
        var primes = new List<int>();
        var threads = new List<Thread>();
        var sw = Stopwatch.StartNew();

        int range = (end - start + 1) / threadCount;

        for (int t = 0; t < threadCount; t++)
        {
            int localStart = start + t * range;
            int localEnd = (t == threadCount - 1) ? end : localStart + range - 1;
            int threadId = t;

            var thread = new Thread(() =>
            {
                for (int i = localStart; i <= localEnd; i++)
                {
                    Console.WriteLine($"Thread {threadId}: checking {i}");

                    if (IsPrime(i))
                    {
                        Console.WriteLine($"Thread {threadId}: FOUND {i}");

                        _mutex.WaitOne();
                        try
                        {
                            total++;
                            primes.Add(i);
                        }
                        finally
                        {
                            _mutex.ReleaseMutex();
                        }
                    }
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        threads.ForEach(t => t.Join());
        sw.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = total,
            ExecutionTime = sw.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = primes
        };
    }

    public string GetVersionName() => "Mutex";

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
            if (number % i == 0) return false;
        return true;
    }
}
