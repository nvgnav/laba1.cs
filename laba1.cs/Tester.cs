using System;

namespace laba1.cs
{
    public class Tester
    {
        private static Random random = new Random(); // создаем объект для генерации случайных чисел

 
        public static void Testing()
        {
            ArrList list1 = new ArrList(); 
            ChainList list2 = new ChainList(); 

 
            for (int i = 0; i < 1000; i++)
            {
                int operation = random.Next(5); // выбираем случайную операцию (от 0 до 4)
                int value = random.Next(100); // случайное значение для добавления или изменения
                int index = random.Next(1, 10); // случайный индекс для вставки или удаления

                try
                {
                    // выбор операции по случайному числу
                    switch (operation)
                    {
                        case 0: // добавить элемент
                            list1.Add(value); // добавляем значение в динамический массив
                            list2.Add(value); // добавляем значение в связный список
                            break;
                        case 1: // вставить элемент в определенную позицию
                            if (list1.Count > 0 && list2.Count > 0) // проверяем, что списки не пусты
                            {
                                list1.Insert(value, index); // вставляем значение в динамический массив
                                list2.Insert(value, index); // вставляем значение в связный список
                            }
                            break;
                        case 2: // удалить элемент из определенной позиции
                            if (list1.Count > 0 && list2.Count > 0) // проверяем, что списки не пусты
                            {
                                list1.Delete(index); // удаляем элемент из динамического массива
                                list2.Delete(index); // удаляем элемент из связного списка
                            }
                            break;
                        case 3: // изменить элемент в определенной позиции
                            if (list1.Count > 0 && list2.Count > 0) // проверяем, что списки не пусты
                            {
                                list1[index] = value; // изменяем значение в динамическом массиве
                                list2[index] = value; // изменяем значение в связном списке
                            }
                            break;
                        case 4: // очистить списки 
                            // list1.Clear();
                            // list2.Clear();
                            break;
                    }
                }
                catch (Exception e) // ловим исключения
                {
                    Console.WriteLine($"Ошибка: {e.Message}"); // выводим сообщение об ошибке
                    break; 
                }
            }

            // проверка на одинаковость списков
            Console.WriteLine($"Проверка на идентичность: ");
            Console.WriteLine(list1.Count); // выводим количество элементов в динамическом массиве
            Console.WriteLine(list2.Count); // выводим количество элементов в связном списке

            if (list1.Count == list2.Count) // если количество элементов одинаковое
            {
                for (int i = 0; i < list1.Count; i++) // проходим по всем элементам
                {
                    if (list1[i] != list2[i]) // если элементы не совпадают
                    {
                        Console.WriteLine($"Листы отличаются"); // выводим сообщение, что списки разные
                    }
                }
            }
            else
            {
                Console.WriteLine("Листы одинаковые"); 
            }
        }
    }
}