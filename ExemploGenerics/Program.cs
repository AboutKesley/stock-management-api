using ExemploGenerics;
using System;
using System.Collections.Generic;

namespace GenericsSimples
{
    // =========================================
    // 1) CLASSE GENÉRICA (Caixa)
    // =========================================
    // Essa classe funciona para QUALQUER tipo
    // O tipo será definido quando criarmos o objeto
    public class Caixa<T>
    {
        // Aqui o tipo é genérico (T)
        public T Conteudo { get; set; }

        public void MostrarConteudo()
        {
            Console.WriteLine($"Conteúdo: {Conteudo}");
            Console.WriteLine($"Tipo: {typeof(T).Name}");
        }
    }

    // =========================================
    // 2) CLASSE NORMAL (sem generics)
    // =========================================
    public class CaixaDeString
    {
        public string Conteudo { get; set; }
    }

    // =========================================
    // 3) PROGRAMA PRINCIPAL
    // =========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SEM GENERICS ===");

            // Aqui precisamos de uma classe específica
            var caixaString = new CaixaDeString();
            caixaString.Conteudo = "Texto";

            Console.WriteLine($"Conteúdo: {caixaString.Conteudo}");

            Console.WriteLine();
            Console.WriteLine("=== COM GENERICS ===");

            // Aqui usamos a MESMA classe para tipos diferentes

            var caixaInt = new Caixa<int>();
            caixaInt.Conteudo = 10;
            caixaInt.MostrarConteudo();

            Console.WriteLine();

            var caixaTexto = new Caixa<string>();
            caixaTexto.Conteudo = "Olá";
            caixaTexto.MostrarConteudo();

            Console.WriteLine();

            var caixaData = new Caixa<DateTime>();
            caixaData.Conteudo = DateTime.Now;
            caixaData.MostrarConteudo();

            Console.WriteLine();
            Console.WriteLine("=== EXEMPLO REAL: LIST<T> ===");

            // List<T> é o exemplo MAIS usado no dia a dia

            var listaNumeros = new List<int>();
            listaNumeros.Add(1);
            listaNumeros.Add(2);
            listaNumeros.Add(3);

            Console.WriteLine("Lista de números:");
            foreach (var numero in listaNumeros)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine();

            var listaNomes = new List<string>();
            listaNomes.Add("Eduardo");
            listaNomes.Add("Maria");

            Console.WriteLine("Lista de nomes:");
            foreach (var nome in listaNomes)
            {
                Console.WriteLine(nome);
            }

            Console.WriteLine();
            var enumHelper = new EnumHelper<Cores>();
            enumHelper.PrintAll();

            Console.WriteLine();
            EnumHelper.StaticPrintAll<Marcas>();


            Console.WriteLine();
            Console.WriteLine("=== RESUMO ===");
            Console.WriteLine("Generics = uma classe que funciona para vários tipos.");
            Console.WriteLine("Você define o tipo só na hora de usar.");
        }
    }
}