using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        MySet<int> a = new MySet<int>(new int[] { 1, 2, 3, 3 });
        MySet<int> b = new MySet<int>(new int[] { 3, 4, 5 });

        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);

        Console.WriteLine("A | B = " + (a | b));
        Console.WriteLine("A - B = " + (a - b));
        Console.WriteLine("A & B = " + (a & b));
        Console.WriteLine("A / B = " + (a / b));

        Console.WriteLine("A == B: " + (a == b));
    }
    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
