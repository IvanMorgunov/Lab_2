using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Follprooff;
namespace Lab_2_Result
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();
            while (PressedKey.Key != ConsoleKey.Escape) 
            {
                Console.Clear();
                Console.WriteLine("1 - Решить СЛАУ (ввод данных с клавиатуры)");
                Console.WriteLine("2 - Решить СЛАУ (ввод данных из файла)");
                Console.WriteLine("Esc - Выход");
                PressedKey = Console.ReadKey(true);
                if (PressedKey.KeyChar == '1') 
                {
                    Console.Clear();
                    int m = 0;
                    int n = 0;
                    Input.Input_Size(ref m, ref n);
                    double[,] matrix = new double[m, n];
                    double[] column = new double[m];
                    Input.Input_Matrix(matrix, column, m, n);
                    Console.Clear();
                    double[] column1 = new double[m];
                    if (Slau.Determinant(matrix, m) == 0)
                    {
                        Console.WriteLine("Решения нет");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        column1 = Slau.Calculation(m, matrix, column);
                        Console.WriteLine("\nСохранить результат решения в файл ?");
                        Console.WriteLine("1 - да");
                        Console.WriteLine("2 - нет");
                        ConsoleKeyInfo PressedKey1 = new ConsoleKeyInfo();
                        while (true)
                        {
                            PressedKey1 = Console.ReadKey(true);
                            if ((PressedKey1.KeyChar == '1') || (PressedKey1.KeyChar == '2'))
                            {
                                break;
                            }
                        }
                        if (PressedKey1.KeyChar == '1')
                        {
                            Console.Clear();
                            Input.Output_File(column1, m);
                        }
                    }
                }
                if (PressedKey.KeyChar == '2') 
                {
                    Console.Clear();
                    int m = 0;
                    int n = 0;
                    string namefile = "";
                    while (true)
                    {
                        if (!(Input.Matrix_Size_File(ref m, ref n, ref namefile)))
                        {
                            Console.WriteLine("Отредактируйте файл и повторите попытку");
                            Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            break;
                        }
                    }
                    double[,] matrix = new double[m, n];
                    double[] column = new double[m];
                    while(true)
                    {
                        if (!(Input.Input_File(matrix, column, namefile, m, n)))
                        {
                            Console.WriteLine("Отредактируйте файл и повторите попытку");
                            Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.Clear();
                    double[] column1 = new double[m];
                    if (Slau.Determinant(matrix, m) == 0)
                    {
                        Console.WriteLine("Решения нет");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        column1 = Slau.Calculation(m, matrix, column);
                        Console.WriteLine("\nСохранить результат решения в файл ?");
                        Console.WriteLine("1 - да");
                        Console.WriteLine("2 - нет");
                        ConsoleKeyInfo PressedKey1 = new ConsoleKeyInfo();
                        while (true)
                        {
                            PressedKey1 = Console.ReadKey(true);
                            if ((PressedKey1.KeyChar == '1') || (PressedKey1.KeyChar == '2'))
                            {
                                break;
                            }
                        }
                        if (PressedKey1.KeyChar == '1')
                        {
                            Console.Clear();
                            Input.Output_File(column1, m);
                        }
                    }
                }
            }
        }
    }
}
