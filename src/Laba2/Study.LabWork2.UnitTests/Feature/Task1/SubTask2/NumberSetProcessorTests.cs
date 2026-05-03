using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

/// <summary>
/// Набор тестов для проверки корректности многопоточной обработки наборов чисел.
/// Проверяются базовые инварианты: количество результатов, корректность сумм,
/// устойчивость к многопоточности и детерминизм.
/// </summary>
[TestFixture]
public sealed class NumberSetProcessorTests
{
    /// <summary>
    /// Проверяет, что после выполнения обработки были обработаны все 15 наборов.
    /// Это базовая гарантия того, что ни один поток не "потерялся".
    /// </summary>
    [Test]
    public void Process_Should_ProcessAllSets()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
    }

    /// <summary>
    /// Проверяет, что итоговая сумма положительная.
    /// Так как числа в диапазоне [1;100], сумма не может быть <= 0.
    /// </summary>
    [Test]
    public void Process_Should_CalculatePositiveTotalSum()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.TotalSum, Is.GreaterThan(0));
    }

    /// <summary>
    /// Проверяет, что результат содержит ровно 15 записей —
    /// по одной на каждый набор.
    /// Важно для проверки корректности синхронизации (lock).
    /// </summary>
    [Test]
    public void Process_Should_Return15ResultsEntries()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.Results.Count, Is.EqualTo(15));
    }

    /// <summary>
    /// Проверяет, что выполнение не приводит к исключениям.
    /// В многопоточном коде это важно: ошибки синхронизации
    /// часто проявляются именно как runtime-исключения.
    /// </summary>
    [Test]
    public void Process_Should_NotThrowExceptions_WhenRun()
    {
        var processor = new NumberSetProcessor();

        Assert.DoesNotThrow(() =>
        {
            processor.Process();
        });
    }

    /// <summary>
    /// Проверяет, что каждый набор обработан ровно один раз.
    /// Отсутствие уникальности означало бы гонку данных
    /// или некорректную работу потоков.
    /// </summary>
    [Test]
    public void Process_Should_HaveUniqueSetNumbers()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        var distinct = result.Results.Select(r => r.SetNumber).Distinct();

        Assert.That(distinct.Count(), Is.EqualTo(15));
    }

    /// <summary>
    /// Проверяет детерминированность результата:
    /// при одинаковых входных данных (файл не меняется)
    /// итоговая сумма должна быть одинаковой.
    /// </summary>
    [Test]
    public void Process_Should_ProduceSameResult_ForSameInputFile()
    {
        var processor1 = new NumberSetProcessor();
        var processor2 = new NumberSetProcessor();

        processor1.Process();
        processor2.Process();

        var r1 = processor1.GetResult();
        var r2 = processor2.GetResult();

        Assert.That(r1.TotalSum, Is.EqualTo(r2.TotalSum));
    }

    /// <summary>
    /// Проверяет, что время выполнения корректно измеряется
    /// и больше нуля (обработка действительно происходила).
    /// </summary>
    [Test]
    public void ExecutionTime_Should_BePositive()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThan(0));
    }
}
