using System;

namespace laba1.cs
{
    public class ChainList
    {
        // Внутренний класс для узла списка
        private class Node
        {
            public int Data; // данные в узле
            public Node Next; // ссылка на следующий узел

            // Конструктор для создания узла с данными
            public Node(int data)
            {
                Data = data; // инициализация данных
                Next = null; // начальное условие
            }
        }

        private Node head; // головной узел списка
        private int cnt; // количество узлов в списке

        // Создание пустого списка
        public ChainList()
        {
            head = null; // голова списка 
            cnt = 0; // начальное количество узлов 0
        }

        // Метод для добавления узла в конец списка
        public void Add(int data)
        {
            Node newNode = new Node(data); // создаем новый узел с данными
            if (head == null) // если список пуст
            {
                head = newNode; // новый узел становится головным
            }
            else
            {
                Node current = head; // начинаем с головного узла
                while (current.Next != null) // ищем последний узел
                {
                    current = current.Next; // переходим к следующему узлу
                }
                current.Next = newNode; // добавляем новый узел в конец
            }
            cnt++; // увеличиваем количество узлов
        }

        // Метод для вставки узла на указанную позицию
        public void Insert(int data, int pos)
        {
            if (pos < 0 || pos > cnt) // проверяем корректность позиции
            {
                return; // если позиция некорректная, выходим
            }

            Node newNode = new Node(data); // создаем новый узел с данными
            if (pos == 0) // вставка в начало списка
            {
                newNode.Next = head; // новый узел указывает на старую голову
                head = newNode; // новый узел становится головой
            }
            else // вставка в середину или конец
            {
                Node current = head; // начинаем с головного узла
                for (int i = 0; i < pos - 1; i++) // ищем узел перед позицией вставки
                {
                    current = current.Next; // переходим к следующему узлу
                }
                newNode.Next = current.Next; // новый узел указывает на следующий узел
                current.Next = newNode; // предыдущий узел указывает на новый узел
            }
            cnt++; // увеличиваем количество узлов
        }

        // Метод для удаления узла на указанной позиции
        public void Delete(int pos)
        {
            if (pos < 0 || pos >= cnt) // проверяем корректность позиции
            {
                return; // если позиция некорректная, выходим
            }
            if (pos == 0) // удаление головного узла
            {
                head = head.Next; // новая голова - следующий узел
            }
            else // удаление из середины или конца
            {
                Node current = head; // начинаем с головного узла
                for (int i = 0; i < pos - 1; i++) // ищем узел перед позицией удаления
                {
                    current = current.Next; // переходим к следующему узлу
                }
                current.Next = current.Next.Next; // пропускаем удаляемый узел
            }
            cnt--; // уменьшаем количество узлов
        }

        // Метод для очистки списка
        public void Clear()
        {
            head = null; // удаляем ссылку на голову
            cnt = 0; // обнуляем количество узлов
        }

        // Свойство для получения количества узлов
        public int Count
        {
            get { return cnt; }
        }

        // Индексатор для доступа к элементам списка
        public int this[int i]
        {
            get
            {
                Node current = head; // начинаем с головного узла
                for (int j = 0; j < i; j++) // ищем узел по индексу
                {
                    if (current != null)
                    {
                        current = current.Next; // переходим к следующему узлу
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Элемент вне диапазона"); // если индекс некорректный, выбрасываем исключение
                    }
                }
                if (current != null) // проверяем, что узел не null
                {
                    return current.Data; // возвращаем данные узла по индексу
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Элемент вне диапазона"); // если узел не существует, выбрасываем исключение
                }
            }
            set
            {
                Node current = head; // начинаем с головного узла
                for (int j = 0; j < i; j++) // ищем узел по индексу
                {
                    if (current != null)
                    {
                        current = current.Next; // переходим к следующему узлу
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Элемент вне диапазона"); // если индекс некорректный, выбрасываем исключение
                    }
                }
                if (current != null) // проверяем, что узел не null
                {
                    current.Data = value; // присваиваем новое значение
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Элемент вне диапазона"); // если узел не существует, выбрасываем исключение
                }
            }
        }

        // Метод для вывода элементов списка
        public void Print()
        {
            Console.WriteLine("ChaiList: "); // выводим заголовок
            Node current = head; // начинаем с головного узла
            while (current != null) // проходим по всем узлам
            {
                Console.Write(current.Data + " "); // выводим данные узла
                current = current.Next; // переходим к следующему узлу
            }
            Console.WriteLine(); // добавляем новую строку
        }

        // Метод для удаления дубликатов в списке
        public void DeleteDuplicates()
        {
            if (cnt <= 1) // Если в списке 1 или меньше элементов
            {
                return;
            }

            Node current = head; // Начинаем с головного узла

            // Внешний цикл проходит по каждому элементу списка
            while (current != null)
            {
                Node runner = current; // Устанавливаем бегуна на текущий элемент

                // Внутренний цикл проходит по элементам, которые следуют за текущим
                while (runner.Next != null)
                {
                    // Если найден элемент, который равен текущему элементу
                    if (runner.Next.Data == current.Data)
                    {
                        runner.Next = runner.Next.Next; // Удаляем следующий элемент, который является дубликатом
                        cnt--; // Уменьшаем счетчик элементов
                    }
                    else
                    {
                        runner = runner.Next; // Переходим к следующему элементу
                    }
                }
                current = current.Next; // Переходим к следующему элементу внешнего цикла
            }
        }

        public int MostRepeatingElement()
        {
            if (cnt == 0)
            {
                throw new InvalidOperationException("Список пуст.");
            }

            int[] frequency = new int[cnt];

            Node current = head;
            while (current != null)
            {
                frequency[current.Data]++;
                current = current.Next; 
            }

            int elementWithMaxRepeating = head.Data;
            int maxRepeating = frequency[head.Data]; 

            for (int j = 1; j < frequency.Length; j++)
            {
                if (frequency[j] > maxRepeating)
                {
                    maxRepeating = frequency[j]; 
                    elementWithMaxRepeating = j; 
                }
            }

            return elementWithMaxRepeating; 
        }
    }
}


