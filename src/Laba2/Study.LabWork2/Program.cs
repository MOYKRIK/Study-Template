using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

/// <summary>
/// Точка входа в приложение для запуска заданий лабораторной работы.
/// </summary>
public static class Program
{
    /// <summary>
    /// Запускает обработку наборов чисел
    /// </summary>
    public static void Main()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Console.WriteLine("=== РЕЗУЛЬТАТЫ ===");

        foreach (var r in result.Results)
            Console.WriteLine(r);

        Console.WriteLine("\n=== ИТОГ ===");
        Console.WriteLine($"Общая сумма: {result.TotalSum}");
        Console.WriteLine($"Обработано наборов: {result.ProcessedSetsCount}");
        Console.WriteLine($"Время: {result.ExecutionTime.TotalMilliseconds} ms");
    }
}
