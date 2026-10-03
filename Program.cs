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
                Console.WriteLine("3. Запустить контрольный пример (тестовые данные)");
                Console.WriteLine("0. Выход из программы");
                Console.WriteLine("==================================================");

                int choice = InputHelper.ReadInt("Выберите действие (0-3): ", 0, 3);

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
                else if (choice == 3)
                {
                    Console.WriteLine("\n--- Контрольный пример тестовых данных ---");
                    arrays = new double[5][]
                    {
                        new double[] { 1.5, 2.3, 4.0, 10.2 },      // Все положительные (№1)
                        new double[] { -3.2, -1.0, -5.5 },         // Все отрицательные (№2)
                        new double[] { 1.2, -2.5, 3.0 },           // Разные знаки (№3)
                        new double[] { -4.1, -2.0, 0, -1.1 },      // Содержит ноль (№4)
                        new double[] { 100.1, 0.5, 7.8, 9.9 }      // Все положительные (№5)
                    };
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

    /// <summary>
    /// Вспомогательный класс валидации и ввода данных (Студент 2)
    /// </summary>
    public static class InputHelper
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Ошибка! Введите целое число от {min} до {max}.");
            }
        }

        public static double ReadDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input.Replace('.', ','), out result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка! Введено неверное вещественное число. Попробуйте снова.");
            }
        }

        public static double[] InputArrayManually(int arrayIndex)
        {
            int size = ReadInt($"Введите размер массива №{arrayIndex} (от 1 до 100): ", 1, 100);
            double[] array = new double[size];

            Console.WriteLine($"Заполнение массива №{arrayIndex} из {size} элементов:");
            for (int i = 0; i < size; i++)
            {
                array[i] = ReadDouble($"  Элемент [{i + 1}]: ");
            }

            return array;
        }

        public static double[] GenerateRandomArray(int arrayIndex, Random rnd)
        {
            int size = rnd.Next(3, 10);
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = Math.Round((rnd.NextDouble() * 20.0 - 10.0), 1);
            }

            return array;
        }
    }
}
