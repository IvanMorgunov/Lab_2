using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Char;
namespace Follprooff
{
    public static class Follproof
    {
        public static int Int(string Output)
        {
            bool FlagOverflow = true;
            int IntResult = 0;
            while (FlagOverflow != false)
            {
                FlagOverflow = false;
                Console.Clear();
                Console.WriteLine(Output);
                ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();
                StringBuilder StringResult = new StringBuilder();
                while (PressedKey.Key != ConsoleKey.Enter)
                {
                    PressedKey = Console.ReadKey(true);
                    if (StringResult.Length == 0)
                    {
                        if ((IsDigit(PressedKey.KeyChar)) || (PressedKey.KeyChar == '-'))
                        {
                            Console.Write(PressedKey.KeyChar);
                            StringResult.Append(PressedKey.KeyChar);
                        }
                    }
                    else
                    {
                        if ((StringResult.Length == 1) && ((StringResult[0] == '-') || (StringResult[0] == '0')))
                        {
                            if (StringResult[0] == '-')
                            {
                                if ((IsDigit(PressedKey.KeyChar)) && (PressedKey.KeyChar != '0'))
                                {
                                    Console.Write(PressedKey.KeyChar);
                                    StringResult.Append(PressedKey.KeyChar);
                                }
                                else
                                {
                                    if (PressedKey.Key == ConsoleKey.Enter)
                                    {
                                        PressedKey = new ConsoleKeyInfo();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (IsDigit(PressedKey.KeyChar))
                            {
                                Console.Write(PressedKey.KeyChar);
                                StringResult.Append(PressedKey.KeyChar);
                            }
                        }
                    }
                    if (PressedKey.Key == ConsoleKey.Backspace)
                    {
                        if (StringResult.Length != 0)
                        {
                            StringResult.Remove(StringResult.Length - 1, 1);
                        }
                        Console.Clear();
                        Console.WriteLine(Output);
                        Console.Write(StringResult);
                    }
                    if ((PressedKey.Key == ConsoleKey.Enter) && (StringResult.Length == 0))
                    {
                        PressedKey = new ConsoleKeyInfo();
                    }
                }
                if (!int.TryParse(StringResult.ToString(), out IntResult))
                {
                    Console.Clear();
                    Console.WriteLine("Введенное вами значение не помещается в допустимый диапазон.");
                    Console.WriteLine("Допустимый диапазон от {0} до {1}", int.MinValue, int.MaxValue);
                    Console.WriteLine("Повторите попытку");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey(true);
                    FlagOverflow = true;
                }
            }
            return IntResult;
        }
        public static double Double(string Output)
        {
            bool FlagOverflow = true;
            double DoubleResult = 0;
            while (FlagOverflow != false)
            {
                FlagOverflow = false;
                Console.Clear();
                Console.WriteLine(Output);
                ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();
                StringBuilder StringResult = new StringBuilder();
                bool Comma = false;
                while (PressedKey.Key != ConsoleKey.Enter)
                {
                    PressedKey = Console.ReadKey(true);
                    if (StringResult.Length == 0)
                    {
                        if ((IsDigit(PressedKey.KeyChar)) || (PressedKey.KeyChar == '-'))
                        {
                            Console.Write(PressedKey.KeyChar);
                            StringResult.Append(PressedKey.KeyChar);
                        }
                    }
                    else
                    {
                        if ((StringResult.Length == 1) && ((StringResult[0] == '-') || (StringResult[0] == '0')))
                        {
                            if (StringResult[0] == '-')
                            {
                                if (IsDigit(PressedKey.KeyChar))
                                {
                                    Console.Write(PressedKey.KeyChar);
                                    StringResult.Append(PressedKey.KeyChar);
                                }
                                else
                                {
                                    if (PressedKey.Key == ConsoleKey.Enter)
                                    {
                                        PressedKey = new ConsoleKeyInfo();
                                    }
                                }
                            }
                            else
                            {
                                if (PressedKey.KeyChar == ',')
                                {
                                    Console.Write(PressedKey.KeyChar);
                                    StringResult.Append(PressedKey.KeyChar);
                                    Comma = true;
                                }
                            }
                        }
                        else
                        {
                            if ((StringResult.Length == 2) && ((StringResult[0] == '-') && (StringResult[1] == '0')))
                            {
                                if (PressedKey.KeyChar == ',')
                                {
                                    Console.Write(PressedKey.KeyChar);
                                    StringResult.Append(PressedKey.KeyChar);
                                    Comma = true;
                                }
                                else
                                {
                                    if (PressedKey.Key == ConsoleKey.Enter)
                                    {
                                        PressedKey = new ConsoleKeyInfo();
                                    }
                                }
                            }
                            else
                            {
                                if (Comma == false)
                                {
                                    if ((IsDigit(PressedKey.KeyChar)) || (PressedKey.KeyChar == ','))
                                    {
                                        Console.Write(PressedKey.KeyChar);
                                        StringResult.Append(PressedKey.KeyChar);
                                        if (PressedKey.KeyChar == ',')
                                        {
                                            Comma = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (IsDigit(PressedKey.KeyChar))
                                    {
                                        Console.Write(PressedKey.KeyChar);
                                        StringResult.Append(PressedKey.KeyChar);
                                    }
                                }
                            }
                        }
                    }
                    if (PressedKey.Key == ConsoleKey.Backspace)
                    {
                        if (StringResult.Length != 0)
                        {
                            if (StringResult[StringResult.Length - 1] == ',')
                            {
                                Comma = false;
                            }
                            StringResult.Remove(StringResult.Length - 1, 1);
                        }
                        Console.Clear();
                        Console.WriteLine(Output);
                        Console.Write(StringResult);
                    }
                    if ((PressedKey.Key == ConsoleKey.Enter) && (StringResult.Length == 0))
                    {
                        PressedKey = new ConsoleKeyInfo();
                    }
                    if ((PressedKey.Key == ConsoleKey.Enter) && (Comma == true) && ((StringResult[StringResult.Length - 1] == '0') || (StringResult[StringResult.Length - 1] == ',')))
                    {
                        PressedKey = new ConsoleKeyInfo();
                    }
                }
                if (!double.TryParse(StringResult.ToString(), out DoubleResult))
                {
                    Console.Clear();
                    Console.WriteLine("Введенное вами значение не помещается в допустимый диапазон.");
                    Console.WriteLine("Допустимый диапазон от {0} до {1}", double.MinValue, double.MaxValue);
                    Console.WriteLine("Повторите попытку");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey(true);
                    FlagOverflow = true;
                }
            }
            return DoubleResult;
        }
    }
}
