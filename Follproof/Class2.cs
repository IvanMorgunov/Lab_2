using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Char;
using System.IO;
namespace Follprooff
{
    public static class Input
    {
        public static void Input_Matrix(double[,] matrix, double[] column, int m, int n)
        {
            Console.Clear();
            while (true)
            {
                string s = "";
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = "Введите A[" + (i + 1) + ']' + '[' + (j + 1) + ']';
                        matrix[i, j] = Follproof.Double(s);
                    }
                }
                bool flag = false;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] == 0) 
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nНа диагонали стоит нулевой элемент");
                    Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу");
                    Console.ReadKey(true);
                }
                else
                {
                    break;
                }
            }
            string ss = "";
            for (int i = 0; i < m; i++)
            {
                ss = "Введите b[" + (i + 1) + ']';
                column[i] = Follproof.Double(ss);
            }
        }

        public static void Input_Size(ref int m, ref int n)
        {
            while (true)
            {
                m = Follproof.Int("Введите количество строк и столбцов в матрице");
                if (m <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nЧисло должно быть положительным");
                    Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу");
                    Console.ReadKey(true);
                }
                else
                {
                    break;
                }
            }
            n = m;
        }

        public static void Output_File(double[] res, int n)
        {
            Console.WriteLine("Введите имя файла");
            string s = Console.ReadLine();
            FileStream file = new FileStream(s, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            string ss = "";
            for (int i = 0; i < n; i++)
            {
                ss = "X" + (i + 1) + ' ' + '=' + ' ' + res[i];
                writer.WriteLine(ss);
            }
            writer.Close();
            file.Close();
        }

        public static bool Input_File(double[,] matrix, double[] column, string s, int m, int n)
        {
            FileStream file = new FileStream(s, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            int key = 0;
            StringBuilder StringResult = new StringBuilder();
            string c = reader.ReadLine();
            c = reader.ReadLine();
            int m1 = 0, n1 = 0;
            if (reader.EndOfStream)
            {
                Console.Clear();
                Console.WriteLine("Ошибка\nДанные в файле некорректны");
                file.Dispose();
                reader.Dispose();
                return false;
            }
            bool flagD = false;
            while (!reader.EndOfStream)
            {
                key = reader.Read();
                if (IsDigit((char)key))
                {
                    flagD = true;
                }
                else
                {
                    if ((key == ' ') && (flagD == true))
                    {
                        flagD = false;
                        n1++;
                    }
                    else
                    {
                        if (key == '\n')
                        {
                            if (flagD == true)
                            {
                                flagD = false;
                                n1++;
                            }
                            m1++;
                            if (n1 != n + 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка\nДанные в файле некорректны");
                                file.Dispose();
                                reader.Dispose();
                                return false;
                            }
                            else
                            {
                                n1 = 0;
                            }
                        }
                    }
                }
            }
            if (key != '\n')
            {
                if (flagD == true)
                {
                    n1++;
                }
                if (n1 != n + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                    file.Dispose();
                    reader.Dispose();
                    return false;
                }
                m1++;
                if (m1 != m)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                    file.Dispose();
                    reader.Dispose();
                    return false;
                }
            }
            file.Dispose();
            reader.Dispose();
            file = new FileStream(s, FileMode.Open);
            reader = new StreamReader(file);
            c = reader.ReadLine();
            c = reader.ReadLine();
            bool Comma = false;
            m1 = 0;
            n1 = 0;
            int n2 = 0;
            bool flagg = false;
            while (!reader.EndOfStream)
            {
                flagg = false;
                key = reader.Read();
                if (StringResult.Length == 0)
                {
                    if ((IsDigit((char)key)) || (key == '-'))
                    {
                        flagg = true;
                        StringResult.Append((char)key);
                    }
                }
                else
                {
                    if ((StringResult.Length == 1) && ((StringResult[0] == '-') || (StringResult[0] == '0')))
                    {
                        if (StringResult[0] == '-')
                        {
                            if (IsDigit((char)key))
                            {
                                flagg = true;
                                StringResult.Append((char)key);
                            }
                            else
                            {
                                if ((key == ' ') || (key == '\n'))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                                    file.Dispose();
                                    reader.Dispose();
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (key == ',')
                            {
                                flagg = true;
                                StringResult.Append((char)key);
                                Comma = true;
                            }
                        }
                    }
                    else
                    {
                        if ((StringResult.Length == 2) && ((StringResult[0] == '-') && (StringResult[1] == '0')))
                        {
                            if (key == ',')
                            {
                                flagg = true;
                                StringResult.Append((char)key);
                                Comma = true;
                            }
                            else
                            {
                                if ((key == ' ') || (key == '\n'))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                                    file.Dispose();
                                    reader.Dispose();
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (Comma == false)
                            {
                                if ((IsDigit((char)key) || (key == ',')))
                                {
                                    flagg = true;
                                    StringResult.Append((char)key);
                                    if (key == ',')
                                    {
                                        Comma = true;
                                    }
                                }
                            }
                            else
                            {
                                if (IsDigit((char)key))
                                {
                                    flagg = true;
                                    StringResult.Append((char)key);
                                }
                            }
                        }
                    }
                }
                if (((key == ' ') || (key == '\n')) && (StringResult.Length == 0))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                    file.Dispose();
                    reader.Dispose();
                    return false;
                }
                if (((key == ' ') || (key == '\n')) && (Comma == true) && ((StringResult[StringResult.Length - 1] == '0') || (StringResult[StringResult.Length - 1] == ',')))
                {
                    Console.Clear();
                    Console.ReadKey(true);
                    file.Dispose();
                    reader.Dispose();
                    return false;
                }
                if ((key == ' ') || (key == '\n'))
                {
                    flagg = true;
                    if (n1 == n)
                    {
                        double.TryParse(StringResult.ToString(), out column[n2]);
                        n2++;
                    }
                    else
                    {
                        double.TryParse(StringResult.ToString(), out matrix[m1, n1]);
                    }
                    StringResult = new StringBuilder();
                    if (key == '\n')
                    {
                        m1++;
                        n1 = 0;
                    }
                    else
                    {
                        n1++;
                    }
                }
                if ((flagg == false) && (key != 13))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                    file.Dispose();
                    reader.Dispose();
                    return false;
                }
            }
            if (!(StringResult.Length == 0))
            {
                double.TryParse(StringResult.ToString(), out column[n2]);
            }
            bool flag = false;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] == 0) 
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                Console.Clear();
                Console.WriteLine("Ошибка\nНа диагонали стоит нулевой элемент");
                file.Close();
                reader.Close();
                return false;
            }
            file.Dispose();
            reader.Dispose();
            return true;
        }
        public static bool Matrix_Size_File(ref int m, ref int n, ref string s)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите имя файла");
                s = Console.ReadLine();
                if (!File.Exists(s))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nФайла не существует");
                    Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу");
                    Console.ReadKey(true);
                }
                else
                {
                    break;
                }
            }
            FileStream file = new FileStream(s, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string m1 = reader.ReadLine();
            if (!Int32.TryParse(m1, out m))
            {
                Console.Clear();
                Console.WriteLine("Ошибка\nДанные в файле некорректны");
                file.Dispose();
                reader.Dispose();
                return false;
            }
            else
            {
                string n1 = reader.ReadLine();
                if (!Int32.TryParse(n1, out n))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка\nДанные в файле некорректны");
                    file.Dispose();
                    reader.Dispose();
                    return false;
                }
            }
            if ((m <= 0) || (n <= 0))
            {
                Console.Clear();
                Console.WriteLine("Ошибка\nДанные в файле некорректны");
                file.Dispose();
                reader.Dispose();
                return false;
            }
            if (m != n)
            {
                Console.Clear();
                Console.WriteLine("Ошибка\nМатрица должна быть квадратной");
                file.Dispose();
                reader.Dispose();
                return false;
            }
            file.Dispose();
            reader.Dispose();
            return true;
        }
    }
}
