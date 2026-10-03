using System;

namespace PracticalWork8_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Практическая работа №8-9. Вариант 6 ===");

            // Пример из 5 одномерных массивов
            double[][] arrays = new double[5][]
            {
                new double[] { 1.5, 2.3, 4.0, 10.2 },      // Все положительные (№1)
                new double[] { -3.2, -1.0, -5.5 },         // Все отрицательные (№2)
                new double[] { 1.2, -2.5, 3.0 },           // Разные знаки (№3)
                new double[] { -4.1, -2.0, 0, -1.1 },      // Содержит ноль (№4)
                new double[] { 100.1, 0.5, 7.8, 9.9 }      // Все положительные (№5)
            };

            Console.WriteLine("\nРезультаты проверки массивов:");
            for (int i = 0; i < arrays.Length; i++)
            {
                bool sameSign = ArrayProcessor.IsSameSign(arrays[i]);

                if (sameSign)
                {
                    Console.WriteLine($"Массив №{i + 1}: Составляет последовательность одного знака.");
                }
                else
                {
                    Console.WriteLine($"Массив №{i + 1}: Ответ отрицательный (элементы разных знаков или содержат 0).");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}