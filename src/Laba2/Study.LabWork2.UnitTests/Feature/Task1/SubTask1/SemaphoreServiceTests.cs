using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    private IPrimeCounter _service;
    /// <summary>
    /// Semaphore ограничивает параллелизм потоков (3 одновременно)
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _service = new SemaphoreService();
    }
    /// <summary>
    /// Проверка корректности логики при ограниченной конкуренции потоков
    /// </summary>
    [Test]
    public void CountPrimes_CorrectResult()
    {
        var result = _service.CountPrimes(1, 100, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }
    /// <summary>
    /// Проверка на эталонном диапазоне задачи
    /// </summary>
    [Test]
    public void CountPrimes_ThreadLimitDoesNotBreakLogic()
    {
        var result = _service.CountPrimes(1, 10000, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }
    /// <summary>
    /// Проверка стабильности результата при повторных запусках
    /// </summary>
    [Test]
    public void CountPrimes_RepeatedRunsStable()
    {
        var r1 = _service.CountPrimes(1, 1000, 4);
        var r2 = _service.CountPrimes(1, 1000, 4);

        Assert.That(r1.PrimeCount, Is.EqualTo(r2.PrimeCount));
    }
}
