using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4CiclosRepetitivosEtc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"__________              __              _____  ");
            Console.WriteLine(@"\______   \__ __  _____/  |_  ____     /  |  | ");
            Console.WriteLine(@" |     ___/  |  \/    \   __\/  _ \   /   |  |_");
            Console.WriteLine(@" |    |   |  |  /   |  \  | (  <_> ) /    ^   /");
            Console.WriteLine(@" |____|   |____/|___|  /__|  \____/  \____   | ");
            Console.WriteLine(@"                     \/                   |__| ");
            Console.WriteLine();
            Console.WriteLine("Por López Sales Facundo y López Sales Santiago");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            double precio = 0, cuotas = 0, interes = 0, montocuota = 0;


        ingreso1:
            Console.WriteLine("Valor:");

            try
            {
                precio = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                goto ingreso1;

            }

        ingreso2:
            Console.WriteLine("Cuotas disponibles: 3, 6 y 12");

            try
            {
                cuotas = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                goto ingreso2;
            }

            switch (cuotas)
            {
                case 3:
                    Console.WriteLine("");
                    interes = 0;
                    break;
                case 6:
                    Console.WriteLine("");
                    interes = 10;
                    break;
                case 12:
                    Console.WriteLine("");
                    interes = 15;
                    break;

                default:
                    Console.WriteLine("Ingrese un nro valido");
                    Console.Clear();
                    goto ingreso2;

            }

            montocuota = (((interes * precio) / 100) + precio) / cuotas;

            string pagosString;
            string path = @"d:\pagos.txt";



            StreamWriter escritura = File.CreateText(path);

            for (int i = 1; i <= cuotas; i++)
            {
                Console.WriteLine($"Cuota {i} - paga ${montocuota.ToString(format: "0.00")}- pago acomulado: ${(montocuota * i).ToString(format: "0.00")} - saldo: ${((((interes * precio) / 100) + precio) - montocuota * i).ToString(format: "0.00")}");
                pagosString = $"Cuota {i} - paga ${montocuota.ToString(format: "0.00")}- pago acomulado: ${(montocuota * i).ToString(format: "0.00")} - saldo: ${((((interes * precio) / 100) + precio) - montocuota * i).ToString(format: "0.00")}";
                escritura.WriteLine(pagosString);

            }

            escritura.Close();
            Console.ReadKey();

           
        }
    }
}
