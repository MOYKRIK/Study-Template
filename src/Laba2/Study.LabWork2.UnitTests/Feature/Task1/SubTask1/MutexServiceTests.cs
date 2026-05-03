using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask1;
namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MutexServiceTests
{
    private IPrimeCounter _service;

    [SetUp]
    public void Setup()
    {
        _service = new MutexService();
    }

    [Test]
    public void CountPrimes_CorrectTotal()
    {
        var result = _service.CountPrimes(1, 100, 4);

        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }

    [Test]
    public void CountPrimes_ConsistentResults()
    {
        var r1 = _service.CountPrimes(1, 500, 4);
        var r2 = _service.CountPrimes(1, 500, 4);

        Assert.That(r1.PrimeCount, Is.EqualTo(r2.PrimeCount));
    }

    [Test]
    public void CountPrimes_DoesNotDeadlock()
    {
        Assert.DoesNotThrow(() =>
            _service.CountPrimes(1, 200, 4)
        );
    }
}
