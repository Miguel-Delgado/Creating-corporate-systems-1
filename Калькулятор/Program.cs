using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калькулятор
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консольный калькулятор на C# (с памятью)");
            double memory = 0.0;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Арифметическая операция (+, -, *, /)");
                Console.WriteLine("2. Унарная операция (1/x, x^2, sqrt(x))");
                Console.WriteLine("3. Операции с памятью (M+, M-, MR)");
                Console.WriteLine("4. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformBinaryOperation();
                        break;
                    case "2":
                        PerformUnaryOperation();
                        break;
                    case "3":
                        PerformMemoryOperation(ref memory);
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Выход из калькулятора.");
                        break;
                    default:
                        Console.WriteLine("Ошибка: неверный выбор.");
                        break;
                }
            }
        }

        static void PerformBinaryOperation()
        {
            double num1 = ReadNumber("Введите первое число: ");
            double num2 = ReadNumber("Введите второе число: ");

            Console.Write("Введите операцию (+, -, *, /): ");
            string op = Console.ReadLine();

            double result = 0;
            bool valid = true;

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Console.WriteLine("Ошибка: деление на ноль!");
                        valid = false;
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка: неверная операция.");
                    valid = false;
                    break;
            }

            if (valid)
                Console.WriteLine($"Результат: {num1} {op} {num2} = {result}");
        }

        static void PerformUnaryOperation()
        {
            double num = ReadNumber("Введите число: ");

            Console.Write("Введите операцию (1/x, x^2, sqrt(x)): ");
            string op = Console.ReadLine();

            double result = 0;
            bool valid = true;

            switch (op)
            {
                case "1/x":
                    if (num != 0)
                        result = 1 / num;
                    else
                    {
                        Console.WriteLine("Ошибка: деление на ноль!");
                        valid = false;
                    }
                    break;
                case "x^2":
                    result = num * num;
                    break;
                case "sqrt(x)":
                    if (num >= 0)
                        result = Math.Sqrt(num);
                    else
                    {
                        Console.WriteLine("Ошибка: отрицательное число под корнем!");
                        valid = false;
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка: неверная операция.");
                    valid = false;
                    break;
            }

            if (valid)
                Console.WriteLine($"Результат: {op}({num}) = {result}");
        }

        static void PerformMemoryOperation(ref double memory)
        {
            Console.Write("Введите операцию с памятью (M+, M-, MR): ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "M+":
                    double addVal = ReadNumber("Введите число для добавления в память: ");
                    memory += addVal;
                    Console.WriteLine($"Память обновлена: {memory}");
                    break;
                case "M-":
                    double subVal = ReadNumber("Введите число для вычитания из памяти: ");
                    memory -= subVal;
                    Console.WriteLine($"Память обновлена: {memory}");
                    break;
                case "MR":
                    Console.WriteLine($"Значение в памяти: {memory}");
                    break;
                default:
                    Console.WriteLine("Ошибка: неверная операция памяти.");
                    break;
            }
        }

        static double ReadNumber(string message)
        {
            double num;
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out num))
                {
                    if (num >= -1000 && num <= 1000)
                        return num;
                    else
                        Console.WriteLine("Ошибка: число должно быть в диапазоне [-1000; 1000].");
                }
                else
                    Console.WriteLine("Ошибка: введите корректное число.");
            }
        }
    }

}

