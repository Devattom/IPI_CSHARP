// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Calcul de performance");
var sw1 = Stopwatch.StartNew();
var sw2 = Stopwatch.StartNew();

double sum = 1;

Parallel.For(1, 10, (num, state) =>
{
    Console.WriteLine($"Début du thread {num}");
    for (int i = 0; i < 50_000_000; i++)
    {
        sum += Math.Sin(i) + Math.Cos(i);

        sum += Math.Sqrt(i);

        sum += Math.Exp(i % 10) + Math.Log(i + 1);

        sum += Math.Pow(i % 100, 3);

        sum *= 1.00000001;
    }
    sw2.Stop();
    Console.WriteLine($"Temps de calcul thread : {num} : {sw2.ElapsedMilliseconds} ms");
    sw2.Restart();
});

sw1.Stop();

Console.WriteLine($"Temps de calcul total: {sw1.ElapsedMilliseconds} ms");