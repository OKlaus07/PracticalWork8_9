using System;

namespace PracticalWork8_9
{
    public static class InputHelper
    {
        /// <summary>
        /// Ввод целого числа в заданном диапазоне (для размеров и меню)
        /// </summary>
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

        /// <summary>
        /// Ввод вещественного числа (double)
        /// </summary>
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

        /// <summary>
        /// Ручной ввод 1D массива с валидацией
        /// </summary>
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

        /// <summary>
        /// Автоматическая генерация массива случайными числами
        /// </summary>
        public static double[] GenerateRandomArray(int arrayIndex, Random rnd)
        {
            int size = rnd.Next(3, 10); // Размер от 3 до 9
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                // Генерируем числа от -10.0 до 10.0 с округлением
                array[i] = Math.Round((rnd.NextDouble() * 20.0 - 10.0), 1);
            }

            return array;
        }
    }
}