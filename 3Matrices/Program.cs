using System;


namespace _3Matrices
{
    class Program
    {       
        
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"__________              __           ________  ");
            Console.WriteLine(@"\______   \__ __  _____/  |_  ____   \_____  \ ");
            Console.WriteLine(@" |     ___/  |  \/    \   __\/  _ \    _(__  < ");
            Console.WriteLine(@" |    |   |  |  /   |  \  | (  <_> )  /       \");
            Console.WriteLine(@" |____|   |____/|___|  /__|  \____/  /______  /");
            Console.WriteLine(@"                     \/                     \/ ");
            Console.WriteLine();
            Console.WriteLine("Por López Sales Facundo y López Sales Santiago");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            bool flag = false;
            const int filas = 20;
            const int columnas = 16;
            Random rnd = new Random();
            int[,] Asistencia = new int[filas,columnas];
            int[] Alumnos = new int[filas];
            string opcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("1) Mostras asistencia");
                Console.WriteLine("2) Alumnos con asistencia perfecta.");
                Console.WriteLine("3) Asistencia por alumno.");
                
                Console.WriteLine("0) Salir");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostraryLlenarMatriz(Asistencia, filas, columnas, rnd, Alumnos);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        AsistenciaPerfecta(Asistencia, filas, columnas);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        AsistenciaporAlumno(Asistencia, filas, columnas, Alumnos);
                        break;
                                      
                    case "0":
                        flag = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Comando no valido");
                        Console.ReadKey();
                        break;
                }

            } while (flag == false);

           
            


        }

       

        private static void MostraryLlenarMatriz(int[,] Asistencia,  int filas,  int columnas, Random rnd, int[] alumnos)
        {
            int CantAlumnos = 1;

            //Llenar vector
            for (int i = 0; i < filas; i++)
            {
                alumnos[i] = CantAlumnos;
                CantAlumnos++;
            }

            //LLenar matiz
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {

                    if (rnd.Next(0, 101) <= 85)
                    {
                        Asistencia[i, j] = 1;
                    }

                    if (rnd.Next(0, 101) > 85)
                    {
                        Asistencia[i, j] = 0;
                    }
                }
            }
            // Mostrar matriz
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {                    

                    if (Asistencia[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|A| ");

                    }

                    if (Asistencia[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|P| ");

                    }
                    
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Alumno{alumnos[i]}");
            }
        }

        private static void AsistenciaPerfecta(int[,] asistencia, int filas, int columnas)
        {
            int AlumnosAsistPerfecta = 0;
            int Presente;

            for (int i = 0; i < filas; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Presente = 0;
                for (int j = 0; j < columnas; j++)
                {
                    if (asistencia[i, j] == 1)
                    {
                        Presente++;
                    }                   
                }
                if (columnas == Presente)
                {
                    AlumnosAsistPerfecta++;
                }

            }
                

            Console.WriteLine($"Los alumnos con asistencia perfecta son {AlumnosAsistPerfecta}");
        }

        private static void AsistenciaporAlumno(int[,] asistencia, int filas, int columnas, int[] alumnos)
        {
            Console.Clear();
            double Ausente;
            double Presente;
            double PorcentajeAsistencia;
            double PorcentajeInasistencia;



            for (int i = 0; i < filas; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Ausente = 0;
                Presente = 0;
                PorcentajeAsistencia = 0;
                PorcentajeInasistencia = 0;
                for (int j = 0; j < columnas; j++)
                {
                    if (asistencia[i,j] == 0)
                    {
                        Ausente++;
                    }
                    if (asistencia[i, j] == 1)
                    {
                        Presente++;
                    }

                    PorcentajeAsistencia = (Presente * 100) / columnas;
                    PorcentajeInasistencia = (Ausente * 100) / columnas;


                }
                Console.WriteLine($"El Alumno{alumnos[i]} tiene presentes {Presente} ({PorcentajeAsistencia}) y ausentes {Ausente}(%{PorcentajeInasistencia})");
                if (PorcentajeAsistencia >= 75)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"El alumno{alumnos[i]} esta Regular.");
                }
                if (PorcentajeAsistencia < 75)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"El alumno{alumnos[i]} quedo Libre.");
                }
            }

           
            Console.ReadKey();
        }
    }
}
