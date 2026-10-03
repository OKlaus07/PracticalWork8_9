using System;

namespace PracticalWork8_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Практическая работа №8-9 — Вариант 6";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("    Практическая работа №8-9. Вариант 6");
                Console.WriteLine("    Разработка и интеграция модулей (Команда)");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Ввести 5 массивов вручную с клавиатуры");
                Console.WriteLine("2. Сгенерировать 5 массивов случайными числами");
                Console.WriteLine("0. Выход из программы");
                Console.WriteLine("==================================================");

                int choice = InputHelper.ReadInt("Выберите действие (0-2): ", 0, 2);

                if (choice == 0)
                {
                    Console.WriteLine("\nПрограмма завершена.");
                    break;
                }

                double[][] arrays = new double[5][];

                if (choice == 1)
                {
                    Console.WriteLine("\n--- Ввод данных пользователем ---");
                    for (int i = 0; i < 5; i++)
                    {
                        arrays[i] = InputHelper.InputArrayManually(i + 1);
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\n--- Сгенерированные массивы ---");
                    Random rnd = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        arrays[i] = InputHelper.GenerateRandomArray(i + 1, rnd);
                    }
                }

                // Вывод исходных данных
                Console.WriteLine("\n================ ИСХОДНЫЕ ДАННЫЕ ================");
                for (int i = 0; i < arrays.Length; i++)
                {
                    Console.Write($"Массив №{i + 1} [{arrays[i].Length} эл.]: ");
                    Console.WriteLine(string.Join(", ", arrays[i]));
                }

                // Вызов модуля логики (Студент 1) и вывод результатов
                Console.WriteLine("\n================ РЕЗУЛЬТАТЫ ПРОВЕРКИ ============");
                bool hasSameSign = false;

                for (int i = 0; i < arrays.Length; i++)
                {
                    bool sameSign = ArrayProcessor.IsSameSign(arrays[i]);

                    if (sameSign)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[+] Массив №{i + 1}: Состоит из элементов ОДНОГО знака.");
                        Console.ResetColor();
                        hasSameSign = true;
                    }
                    else
                    {
                        Console.WriteLine($"[-] Массив №{i + 1}: Отрицательный ответ (знаки разные или присутствуют нули).");
                    }
                }

                if (!hasSameSign)
                {
                    Console.WriteLine("\nРезультат: Ни один из массивов не удовлетворяет условию задачи.");
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }
    }
}