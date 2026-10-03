using System;

namespace PracticalWork8_9
{
    public static class ArrayProcessor
    {
        /// <summary>
        /// Проверяет, состоят ли элементы массива из чисел одного знака (все положительные или все отрицательные).
        /// </summary>
        /// <param name="array">Массив вещественных чисел</param>
        /// <returns>true, если все элементы одного знака; иначе false</returns>
        public static bool IsSameSign(double[] array)
        {
            if (array == null || array.Length == 0)
                return false;

            // Если единственный элемент — ноль, у него нет знака
            if (array[0] == 0)
                return false;

            bool isPositive = array[0] > 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                    return false; // Ноль не является ни положительным, ни отрицательным

                if ((array[i] > 0) != isPositive)
                    return false; // Нарушение однозначности
            }

            return true;
        }
    }
}