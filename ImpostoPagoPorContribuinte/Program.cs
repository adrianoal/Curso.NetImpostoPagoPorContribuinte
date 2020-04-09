using System;
using System.Collections.Generic;
using System.Globalization;
using ImpostoPagoPorContribuinte.Entities;

namespace ImpostoPagoPorContribuinte
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contribuinte> list = new List<Contribuinte>();

            Console.Write("Insira o numero de contribuintes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados do contribuinte nº{i}:");
                Console.Write("É individual ou Companhia(i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Rendimento Anual: ");
                double rendimento = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'i')
                {
                    Console.Write("Gastos com Saúde: ");
                    double gastos = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(nome, rendimento, gastos));                 
                }
                else
                {
                    Console.Write("Número de Empregados: ");
                    int numero = int.Parse(Console.ReadLine());
                    list.Add(new Companhia(nome, rendimento, numero));
                }
            }
            Console.WriteLine();

            double sum = 0.0;
            Console.WriteLine("Impostos pagos");
            foreach (Contribuinte con in list)
            {
                double taxa = con.Taxa();
                Console.WriteLine(con.Nome + ": $ " + taxa.ToString("F2", CultureInfo.InvariantCulture));
                sum += taxa;

            }
            Console.WriteLine();
            Console.WriteLine("Total de impostos: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
