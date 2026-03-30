using System.Collections.Concurrent;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o dia da semana:");
        var input = Console.ReadLine();
        var inputParsed = Enum.TryParse<DiasDaSemana>(input, true, out var diaDaSemana);
        var isWeekend = diaDaSemana == DiasDaSemana.Domingo || diaDaSemana == DiasDaSemana.Sabado;
        Console.WriteLine($"Resultado: {isWeekend}");
    }
}

enum DiasDaSemana
{
    Domingo = 1,
    Segunda = 2,
    Terca = 3,
    Quarta = 4,
    Quinta = 5,
    Sexta = 6,
    Sabado = 7,
}