using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaxPayer
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public double AnnualIncome { get; set; }

    private const double LowIncomeLimit = 20000;   // граница низкого дохода
    private const double MediumIncomeLimit = 40000;   // граница среднего дохода

    private const double LowTaxRate = 0.12;  // 12% — до 20 000
    private const double MediumTaxRate = 0.20;  // 20% — 20 000–40 000
    private const double HighTaxRate = 0.35;  // 35% — свыше 40 000

    // Прогрессивная шкала налога
    public double CalculateTax()
    {
        if (AnnualIncome <= LowIncomeLimit)
        {
            return AnnualIncome * LowTaxRate;
        }
        else if (AnnualIncome <= MediumIncomeLimit)
        {
            return AnnualIncome * MediumTaxRate;
        }
        else
        {
            return AnnualIncome * HighTaxRate;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Бесконечный цикл меню, пока пользователь не выберет выход
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("         ЛАБОРАТОРНАЯ РАБОТА — МЕНЮ");
            Console.WriteLine("==================================================");
            Console.WriteLine("  1 — Задание №1 (прямая, поиск xk)");
            Console.WriteLine("  2 — Задание №2 (налогоплательщики, CSV)");
            Console.WriteLine("  0 — Выход");
            Console.WriteLine("==================================================");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;
                case "2":
                    RunTask2();
                    break;
                case "0":
                    return; // выход из программы
                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void RunTask1()
    {
        Console.Clear();
        Console.WriteLine("=== Задание №1: Нахождение xk ===");
        Console.WriteLine("Уравнение прямой: y = a*x + b\n");

        try
        {
            Console.Write("Введите параметр a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите параметр b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введите ординату y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.Write("Введите ординату y2: ");
            double y2 = double.Parse(Console.ReadLine());

            // Проверка деления на ноль
            if (a == 0)
            {
                Console.WriteLine("Ошибка: параметр 'a' не может быть равен 0.");
                Console.ReadKey();
                return;
            }

            // Находим x1 и x2 из уравнения прямой: x = (y - b) / a
            double x1 = (y1 - b) / a;
            double x2 = (y2 - b) / a;

            // --- Сложный момент ---
            // Т.к. |x1 - xk| = |x2 - xk|, точка xk — середина отрезка [x1, x2]
            double xk = (x1 + x2) / 2.0;

            Console.WriteLine("\n=== Результаты ===");
            Console.WriteLine($"x1 = {x1:F4}");
            Console.WriteLine($"x2 = {x2:F4}");
            Console.WriteLine($"Искомое xk = {xk:F4}");
            Console.WriteLine($"\n(Справка: Math.PI = {Math.PI})");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: нужно вводить числа.");
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
