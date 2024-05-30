using System;

namespace laba1.cs
{
    using laba1.cs;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;

    class Program
    {
        static void Main(string[] args)
        {

            TestArrList(); 
            TestChainList();
            TestLists();

        }
        static void TestArrList()
        {
            Console.WriteLine("Тестирование ArrList:");
            ArrList arrList = new ArrList(); // создаем новый список

            
            arrList.Add(1); // добавляем элемент в список
            arrList.Add(2); // добавляем элемент в список
            arrList.Add(3); // добавляем элемент в список
            arrList.Add(3); // добавляем элемент в список
            arrList.Add(4); // добавляем элемент в список       
            arrList.Add(3); // добавляем элемент в список

            arrList.FindMostFrequent(); //huy

            Console.WriteLine();

            Console.WriteLine("До удаления дубликатов:");
            arrList.Print(); // выводим элементы списка

            arrList.DeleteDuplicates(); // удаляем дубликаты

            Console.WriteLine("После удаления дубликатов:");
            arrList.Print(); 
            Console.WriteLine();
        }
        static void TestChainList()
        {
            Console.WriteLine("Тестирование ChainList:");
            ChainList chainList = new ChainList(); // создаем новый список

            chainList.Add(1); // добавляем элемент в список
            chainList.Add(2); // добавляем элемент в список
            chainList.Add(3); // добавляем элемент в список
            chainList.Add(3); // добавляем элемент в список
            chainList.Add(4); // добавляем элемент в список
            chainList.Add(3); // добавляем элемент в список
            chainList.FindMostFrequent();

            Console.WriteLine("До удаления дубликатов:");
            chainList.Print(); // выводим элементы списка

            chainList.DeleteDuplicates(); // удаляем дубликаты

            Console.WriteLine("После удаления дубликатов:");
            chainList.Print(); 
            Console.WriteLine();
        }

        static void TestLists()
        {
            Tester.Testing(); // Запускаем тестирование
        }
    }

}
