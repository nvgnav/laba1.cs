using System;

namespace laba1.cs
{
    public class ArrList
    {
        private int[] buffer; // массив элементов
        private int cnt; // количество элементов

        public ArrList()
        {
            buffer = new int[4]; // начальный размер массива
            cnt = 0; // начальное количество элементов
        }


        public void Add(int el)
        {
            if (cnt >= buffer.Length) // если массив заполнен
            {
                int[] newBuffer = new int[buffer.Length * 2]; // создаем новый массив в два раза больше
                for (int i = 0; i < buffer.Length; i++) // копируем элементы в новый массив
                {
                    newBuffer[i] = buffer[i];
                }
                buffer = newBuffer; // заменяем старый массив на новый
            }
            buffer[cnt] = el; // добавляем новый элемент в массив
            cnt++; // увеличиваем счетчик элементов
        }

        public void Clear()
        {
            cnt = 0; // просто обнуляем счетчик элементов
        }

        public void Insert(int el, int index)
        {
            if (index < 0 || index > cnt) // проверяем корректность индекса
            {
                return; // если индекс некорректный, выходим из метода
            }
            if (cnt >= buffer.Length) // если массив заполнен
            {
                int[] newBuffer = new int[buffer.Length * 2]; // создаем новый массив в два раза больше
                for (int i = 0; i < buffer.Length; i++) // копируем элементы в новый массив
                {
                    newBuffer[i] = buffer[i];
                }
                buffer = newBuffer; // заменяем старый массив на новый
            }
            for (int i = cnt; i > index; i--) // сдвигаем элементы вправо от индекса вставки
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[index] = el; // вставляем новый элемент
            cnt++; // увеличиваем счетчик элементов
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= cnt) // проверяем корректность индекса
            {
                return; // если индекс некорректный, выходим из метода
            }
            for (int i = index; i < cnt - 1; i++) // сдвигаем элементы влево от индекса удаления
            {
                buffer[i] = buffer[i + 1];
            }
            cnt--; // уменьшаем счетчик элементов
        }

        public void Print()
        {
            Console.WriteLine("ArrayList: "); // выводим заголовок
            for (int i = 0; i < cnt; i++) // перебираем все элементы
            {
                Console.Write(buffer[i] + "   "); // выводим элемент
            }
            Console.WriteLine(); // добавляем новую строку
        }

        public int Count
        {
            get
            {
                return cnt; // возвращаем количество элементов
            }
        }

        public int this[int i]
        {
            get
            {
                if (i >= cnt || i < 0) // проверяем корректность индекса
                {
                    throw new ArgumentOutOfRangeException("Элемент вне диапазона"); // выбрасываем исключение
                }
                return buffer[i]; // возвращаем элемент по указанному индексу
            }
            set
            {
                if (i >= cnt || i < 0) // проверяем корректность индекса
                {
                    return; // если индекс некорректный, выходим из метода
                }
                buffer[i] = value; // присваиваем новое значение элементу по указанному индексу
            }
        }

        public void DeleteDuplicates()
        {
            // Если в списке 1 или меньше элементов
            if (cnt <= 1)
            {
                return;
            }
            // Идем по каждому элементу списка до предпоследнего
            for (int i = 0; i < cnt - 1; i++)
            {
                int currentElement = buffer[i]; // текущий элемент
                for (int j = i + 1; j < cnt; j++)
                {
                    // Если найден элемент, который равен текущему элементу
                    if (buffer[j] == currentElement)
                    {
                        Delete(j); // Удаляем этот элемент
                        j--; // Уменьшаем j, чтобы не пропустить следующий элемент
                    }
                }
            }
        }

        public int MostRepeatingElement()
        {
            if (cnt == 0)
            {
                throw new InvalidOperationException("пустой список");
            }

            int[] frequency = new int[cnt];

            for (int i = 0; i < cnt - 1; i++)
            {
                int current = buffer[i];
                frequency[current]++; 
            }

            int elementWithMaxRepeating = buffer[0];
            int maxRepeating = frequency[buffer[0]];

            for (int j = 1; j < frequency.Length; j++)
            {
                int currentRepeating = frequency[j];
                if (currentRepeating > maxRepeating)
                {
                    maxRepeating = currentRepeating;
                    elementWithMaxRepeating = j;
                }
            }
            return elementWithMaxRepeating;

        }
    }
}