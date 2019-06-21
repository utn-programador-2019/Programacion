using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Avion
{
    class Program
    {
        public struct Asiento
        {
            public int precio;
            public int numero;
            public bool estado; //True = Ocupado , False = Libre
            public int DNI;
            public bool sexo; //True = Masculino , False = Femenino
            public int edad;
            public int x, y;
            public int clase;
            public bool regresar;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"__________              __           ________  ");
            Console.WriteLine(@"\______   \__ __  _____/  |_  ____   \_____  \ ");
            Console.WriteLine(@" |     ___/  |  \/    \   __\/  _ \   /  ____/ ");
            Console.WriteLine(@" |    |   |  |  /   |  \  | (  <_> ) /       \ ");
            Console.WriteLine(@" |____|   |____/|___|  /__|  \____/  \_______ \");
            Console.WriteLine(@"                     \/                      \/");
            Console.WriteLine();
            Console.WriteLine("Por López Sales Facundo y López Sales Santiago");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            int turista = 1000, business = 2500, primera = 5000;
            int filas = 6, columnas = 10;
            bool salir = false;
            char seleccion;

            Asiento[,] ListaAsientos = new Asiento[filas, columnas];
            InicializarMatriz(turista, business, primera, filas, columnas, ListaAsientos);

            do
            {
            Menu:
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("1- Altas");
                Console.WriteLine("2- Bajas");
                Console.WriteLine("3- Modificacion");
                Console.WriteLine("4- Asientos Libres");
                Console.WriteLine("5- Porcentaje ocupacion");
                Console.WriteLine("6- Recaudacion total");
                Console.WriteLine("7- Cantidad H/M");
                Console.WriteLine("8- Cantidad mayores y niños");
                Console.WriteLine("9- Estado de ventas");
                Console.WriteLine("0- Salir");

                try
                {
                    seleccion = char.Parse(Console.ReadLine().ToUpper());
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese una opción válida");
                    Console.ReadKey();
                    goto Menu;
                }



                switch (seleccion)
                {
                    case '1':
                        Console.Clear();
                        VenderAsiento(ref SeleccionarAsiento(ref ListaAsientos, filas, columnas, 1));
                        break;
                    case '2':
                        CancelarAsiento(ref SeleccionarAsiento(ref ListaAsientos, filas, columnas, 2));
                        break;
                    case '3':
                        ModificarAsiento(ref SeleccionarAsiento(ref ListaAsientos, filas, columnas, 2));
                        break;
                    case '4':
                        ContarAsiento(ListaAsientos, filas, columnas);
                        break;
                    case '5':
                        PorcentajeAsiento(ListaAsientos, filas, columnas);
                        break;
                    case '6':
                        GananciaAsiento(ListaAsientos, filas, columnas);
                        break;
                    case '7':
                        ContarSexo(ListaAsientos, filas, columnas);
                        break;
                    case '8':
                        EdadAsientos(ListaAsientos, filas, columnas);
                        break;
                    case '9':
                        VenderAsiento(ref SeleccionarAsiento(ref ListaAsientos, filas, columnas, 0));
                        break;
                    case '0':
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Seleccion no válida");
                        Console.ReadKey();
                        break;
                }

            } while (salir != true);


        }



        private static void InicializarMatriz(int turista, int business, int primera, int filas, int columnas, Asiento[,] ListaAsientos)
        {
            int contador = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    ListaAsientos[i, j].regresar = false;
                    if (j < 2)
                    {
                        ListaAsientos[i, j].precio = primera;
                        ListaAsientos[i, j].clase = 1;
                    }
                    else if (j >= 2 && j < 6)
                    {
                        ListaAsientos[i, j].precio = business;
                        ListaAsientos[i, j].clase = 2;
                    }
                    else
                    {
                        ListaAsientos[i, j].precio = turista;
                        ListaAsientos[i, j].clase = 3;
                    }
                    ListaAsientos[i, j].numero = contador;
                    contador++;
                    ListaAsientos[i, j].estado = false;
                    ListaAsientos[i, j].DNI = 0;
                    ListaAsientos[i, j].sexo = true;
                    ListaAsientos[i, j].edad = 0;
                    ListaAsientos[i, j].x = i;
                    ListaAsientos[i, j].y = j;
                }
            }
        }

        private static ref Asiento SeleccionarAsiento(ref Asiento[,] ListaAsientos, int filas, int columnas, int menu)
        {
            bool salir = false;


            int x = 0, y = 0;


            do
            {
                Console.Clear();
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        if (ListaAsientos[i, j].estado == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        if (i == 3 && j == 0) //Pasillo
                        {
                            Console.WriteLine();
                        }

                        if (j == 1)
                        {
                            if (ListaAsientos[i, j].x == x && ListaAsientos[i, j].y == y)
                            {
                                Console.Write($"({ListaAsientos[i, j].numero.ToString().PadLeft(2, '0')})||");
                            }
                            else
                            {
                                Console.Write($" {ListaAsientos[i, j].numero.ToString().PadLeft(2, '0')} ||");
                            }

                        }
                        else if (j == 5)
                        {
                            if (ListaAsientos[i, j].x == x && ListaAsientos[i, j].y == y)
                            {
                                Console.Write($"({ListaAsientos[i, j].numero.ToString().PadLeft(2, '0')})|");
                            }
                            else
                            {
                                Console.Write($" {ListaAsientos[i, j].numero.ToString().PadLeft(2, '0')} |");
                            }

                        }
                        else
                        {
                            if (ListaAsientos[i, j].x == x && ListaAsientos[i, j].y == y)
                            {
                                Console.Write($"({ListaAsientos[i, j].numero.ToString().PadLeft(2, '0')})");
                            }
                            else
                            {
                                Console.Write($" {ListaAsientos[i, j].numero.ToString().PadLeft(2, '0')} ");
                            }


                        }

                    }
                    Console.WriteLine();

                } //Escribir Matriz

                Console.WriteLine("Presione ESC para regresar");
                Console.WriteLine();


                EscribirAsientoSeleccionado(ListaAsientos, x, y);




                var mov = Console.ReadKey();
                switch (mov.Key)
                {
                    case ConsoleKey.DownArrow: //Abajo

                        x = x + 1;
                        if (x > filas - 1)
                        {
                            x = 0;
                        }
                        if (x < 0)
                        {
                            x = filas - 1;
                        }

                        break;

                    case ConsoleKey.LeftArrow: // Izq

                        y = y - 1;
                        if (y > columnas - 1)
                        {
                            y = 0;
                        }
                        if (y < 0)
                        {
                            y = columnas - 1;
                        }

                        break;

                    case ConsoleKey.UpArrow: //Arriba


                        x = x - 1;
                        if (x > filas - 1)
                        {
                            x = 0;
                        }
                        if (x < 0)
                        {
                            x = filas - 1;
                        }

                        break;

                    case ConsoleKey.RightArrow: // Der

                        y = y + 1;
                        if (y > columnas - 1)
                        {
                            y = 0;
                        }
                        if (y < 0)
                        {
                            y = columnas - 1;
                        }
                        break;

                    case ConsoleKey.Escape: // ESC
                        ListaAsientos[x, y].regresar = true;
                        return ref ListaAsientos[x, y];

                    case ConsoleKey.Enter: // Enter
                        switch (menu)
                        {
                            case 1:
                                if (ListaAsientos[x, y].estado != true && menu != 0)
                                {
                                    salir = true;
                                }
                                break;
                            case 2:
                                if (ListaAsientos[x, y].estado != false && menu != 0)
                                {
                                    salir = true;
                                }
                                break;
                            default:
                                break;
                        }
                        break;

                    case ConsoleKey.C: // Truco
                        mov = Console.ReadKey();
                        if (mov.Key == ConsoleKey.A)
                        {
                            mov = Console.ReadKey();
                            if (mov.Key == ConsoleKey.N)
                            {
                                mov = Console.ReadKey();
                                if (mov.Key == ConsoleKey.T)
                                {
                                    mov = Console.ReadKey();
                                    if (mov.Key == ConsoleKey.O)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Es el mejor profe");
                                        Console.ReadLine();
                                        Environment.Exit(0);
                                    }
                                }
                            }
                        }

                        break;
                    default:
                        break;


                }


            } while (salir != true);


            return ref ListaAsientos[x, y];

        }

        private static void EscribirAsientoSeleccionado(Asiento[,] ListaAsientos, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"Numero: {ListaAsientos[x, y].numero}");
            switch (ListaAsientos[x, y].clase)
            {
                case 1:
                    Console.WriteLine($"Clase: Primera");
                    break;
                case 2:
                    Console.WriteLine($"Clase: Business");
                    break;
                case 3:
                    Console.WriteLine($"Clase: Turista");
                    break;
                default:
                    break;
            }
            if (ListaAsientos[x, y].estado == true)
            {
                Console.WriteLine($"Estado: Vendido");
                Console.WriteLine($"DNI: {ListaAsientos[x, y].DNI}");
                switch (ListaAsientos[x, y].sexo)
                {
                    case true:
                        Console.WriteLine($"Sexo: Masculino");
                        break;
                    case false:
                        Console.WriteLine($"Sexo: Femenino");
                        break;

                }

                Console.WriteLine($"edad: {ListaAsientos[x, y].edad}");
            }
            else
            {
                Console.WriteLine($"Estado: Libre");
            }

        }

        private static void VenderAsiento(ref Asiento Seleccionado)
        {
            if (Seleccionado.regresar)
            {
                Seleccionado.regresar = false;
                return;
            }
            int dni = 0;
            int sexo = 0;
            int edad = 0;
            Console.Clear();
            try
            {
                Console.WriteLine($"Venta de asiento nro {Seleccionado.numero}");
                Console.WriteLine($"-Precio: {Seleccionado.precio}");
                Console.WriteLine();

                Console.WriteLine("Ingrese los datos del pasajero:");



                Console.Write($"DNI: ");
                dni = int.Parse(Console.ReadLine());
                Console.Write($"Sexo: 1-Masc  2-Fem: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        sexo = 1;
                        break;
                    case 2:
                        sexo = 2;
                        break;
                    default:
                        Console.WriteLine($"No valido");
                        Console.ReadKey();
                        return;

                }



                Console.WriteLine("Edad: ");
                edad = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"No valido");
                Console.ReadKey();
                return;
            }
            Seleccionado.DNI = dni;
            if (sexo == 1)
            {
                Seleccionado.sexo = true;
            }
            else
            {
                Seleccionado.sexo = false;
            }

            Seleccionado.edad = edad;
            Seleccionado.estado = true;
        }

        private static void CancelarAsiento(ref Asiento Seleccionado)
        {
            if (Seleccionado.regresar)
            {
                Seleccionado.regresar = false;
                return;
            }
            Console.WriteLine($"Se limpiará el asiento {Seleccionado.numero}");
            Console.ReadKey();
            Seleccionado.estado = false;
            Seleccionado.DNI = 0;
            Seleccionado.edad = 0;
            Seleccionado.sexo = true;
        }

        private static void ModificarAsiento(ref Asiento Seleccionado)
        {
            if (Seleccionado.regresar)
            {
                Seleccionado.regresar = false;
                return;
            }

            Console.Clear();
            Console.WriteLine($"Modificando asiento {Seleccionado.numero}");
            Console.WriteLine($"DNI actual: {Seleccionado.DNI}");
            Console.Write($"DNI nuevo:");
            try
            {
                Seleccionado.DNI = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (Seleccionado.sexo)
                {
                    case true:
                        Console.WriteLine($"Sexo actual: Masculino");
                        break;
                    case false:
                        Console.WriteLine($"Sexo actual: Femenino");
                        break;

                }
                Console.Write($"Sexo nuevo 1-Masc 2-Fem:");
                Console.WriteLine();
                int sexoInput = int.Parse(Console.ReadLine());

                if (sexoInput != 1 && sexoInput != 2)
                {
                    Console.WriteLine($"No valido");
                    Console.ReadKey();
                    return;
                }

                switch (sexoInput)
                {
                    case 1:
                        Seleccionado.sexo = true;
                        break;
                    case 2:
                        Seleccionado.sexo = false;
                        break;

                }

                Console.WriteLine($"Edad actual: {Seleccionado.edad}");
                Console.Write($"Edad nueva:");
                Seleccionado.edad = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {

                Console.WriteLine($"No valido");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();
            Console.WriteLine($"Modificado exitosamente");
            Console.ReadKey();

        }

        private static void ContarAsiento(Asiento[,] listaAsientos, int filas, int columnas)
        {
            Console.Clear();
            int LibrePrimera = 0, LibreBusiness = 0, LibreTurista = 0;
            int OcupadoPrimera = 0, OcupadoBusiness = 0, OcupadoTurista = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (listaAsientos[i, j].estado)
                    {
                        switch (listaAsientos[i, j].clase)
                        {
                            case 1:
                                OcupadoPrimera++;
                                break;
                            case 2:
                                OcupadoBusiness++;
                                break;
                            case 3:
                                OcupadoTurista++;
                                break;
                        }
                    }
                    else
                    {
                        switch (listaAsientos[i, j].clase)
                        {
                            case 1:
                                LibrePrimera++;
                                break;
                            case 2:
                                LibreBusiness++;
                                break;
                            case 3:
                                LibreTurista++;
                                break;
                        }
                    }


                }
            }

            Console.WriteLine($"Primera Clase -  Libres:{LibrePrimera} - Ocupados:{OcupadoPrimera}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Business Clase - Libres:{LibreBusiness} - Ocupados:{OcupadoBusiness}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Turista Clase - Libres:{LibreTurista} - Ocupados:{OcupadoTurista}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

        }

        private static void PorcentajeAsiento(Asiento[,] listaAsientos, int filas, int columnas) //Revisar
        {
            decimal cont = 0, resultado = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (listaAsientos[i, j].estado)
                    {
                        cont++;
                    }
                }
            }

            resultado = (100 * cont) / (filas * columnas);
            Console.WriteLine($"El avión está {resultado}% ocupado");
            Console.ReadKey();
        }

        private static void GananciaAsiento(Asiento[,] listaAsientos, int filas, int columnas)
        {
            int ganancia = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (listaAsientos[i, j].estado)
                    {
                        ganancia += listaAsientos[i, j].precio;
                    }

                }
            }

            Console.WriteLine($"La recaudación es de {ganancia.ToString(format: "C")}");
            Console.ReadKey();
        }

        private static void ContarSexo(Asiento[,] listaAsientos, int filas, int columnas)
        {
            int hombres = 0, mujeres = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (listaAsientos[i, j].estado)
                    {
                        if (listaAsientos[i, j].sexo)
                        {
                            hombres++;
                        }
                        else
                        {
                            mujeres++;
                        }
                    }

                }
            }
            Console.WriteLine($"Actualmente hay {hombres} hombres y {mujeres} mujeres en el vuelo");
            Console.ReadKey();
        }

        private static void EdadAsientos(Asiento[,] listaAsientos, int filas, int columnas)
        {
            int mayores = 0, menores = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (listaAsientos[i, j].estado)
                    {
                        if (listaAsientos[i, j].edad >= 18)
                        {
                            mayores++;
                        }
                        else
                        {
                            menores++;
                        }
                    }

                }
            }
            Console.WriteLine($"Actualmente hay {mayores} mayores y {menores} menores en el vuelo");
            Console.ReadKey();
        }


    }
}
