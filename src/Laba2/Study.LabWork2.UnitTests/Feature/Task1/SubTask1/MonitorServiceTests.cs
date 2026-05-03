using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask1;
namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MonitorServiceTests
{
    private IPrimeCounter _service;
    /// <summary>
    /// Создаём конкретную реализацию Monitor (lock)
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _service = new MonitorService();
    }
    /// <summary>
    /// Проверяем базовую корректность на маленьком диапазоне чтобы быстро поймать логические ошибки
    /// </summary>
    [Test]
    public void CountPrimes_SmallRange_ReturnsCorrectCount()
    {
        var result = _service.CountPrimes(1, 100, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }
    /// <summary>
    /// Проверка на эталонном диапазоне задачи (контрольный результат = 1229)
    /// </summary>
    [Test]
    public void CountPrimes_FullRange_1To10000_IsCorrect()
    {
        var result = _service.CountPrimes(1, 10000, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }
    /// <summary>
    /// Проверяем детерминированность: многопоточность не должна влиять на итог
    /// </summary>
    [Test]
    public void CountPrimes_MultipleRuns_ReturnSameResult()
    {
        var r1 = _service.CountPrimes(1, 1000, 4);
        var r2 = _service.CountPrimes(1, 1000, 4);

        Assert.That(r1.PrimeCount, Is.EqualTo(r2.PrimeCount));
    }
    /// <summary>
    /// Санитарный тест: проверка отсутствия падений на минимальном диапазоне
    /// </summary>
    [Test]
    public void CountPrimes_NoCrashes_OnSmallRange()
    {
        Assert.DoesNotThrow(() =>
            _service.CountPrimes(1, 10, 2)
        );
    }
}
