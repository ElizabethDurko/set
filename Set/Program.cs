using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Set
    {
        public string[] Mas = { "тут", "должны", "быть", "элементы", "множества", "тут" };

        public static Set operator >(Set obj1, Set obj2)
        {
            int count = 0;
            for (int i = 0; i < obj1.Mas.Length; i++)
            {
                for (int j = 0; j < obj2.Mas.Length; j++)
                {
                    if (obj2.Mas[j] == obj1.Mas[i]) { count++; }
                }
            }

            if (count == obj1.Mas.Length) { Console.WriteLine($"\nЯвляетcя"); } //определение подмножества
            else { Console.WriteLine($"\nНЕ является"); }
            return new Set();
        }

        public static Set operator <(Set obj1, Set obj2)
        {
            int count = 0;
            for (int i = 0; i < obj1.Mas.Length; i++)
            {
                for (int j = 0; j < obj2.Mas.Length; j++)
                {
                    if (obj2.Mas[j] == obj1.Mas[i]) { count++; }
                }
            }
            if (count == obj1.Mas.Length) { Console.WriteLine($"\nЯвляетcя"); }
            else { Console.WriteLine($"\nНЕ является"); }
            return new Set();
        }

        public static Set operator !=(Set obj1, Set obj2) //проверка множеств на неравенство
        {
            int count = 0;
            if (obj1.Mas.Length == obj2.Mas.Length)
            {
                for (int i = 0; i < obj1.Mas.Length; i++)
                {
                    if (obj1.Mas[i] == obj2.Mas[i]) { count++; }
                }
            }
            if (count == obj1.Mas.Length) { Console.WriteLine($"Pавны{count}"); }
            else { Console.WriteLine($"НЕ равны{count}"); }
            return new Set();
        }

        public static Set operator ==(Set obj1, Set obj2)
        {
            int count = 0;
            if (obj1.Mas.Length == obj2.Mas.Length)
            {
                for (int i = 0; i < obj1.Mas.Length; i++)
                {
                    if (obj1.Mas[i] == obj2.Mas[i]) { count++; }
                }
            }
            if (count == obj1.Mas.Length) { Console.WriteLine($"Pавны"); }
            else { Console.WriteLine($"НЕ равны"); }
            return new Set();
        }

        public static Set operator <<(Set obj1, int x) //добавляет элемент
        {
            Array.Resize(ref obj1.Mas, obj1.Mas.Length + 1); //Array - содержит весь функционал для работы с массивами Resize - содержит два значения 1)ссылка на объект 2)что мы с ним делаем
            obj1.Mas[obj1.Mas.Length - 1] = obj1.Mas[x];
            return new Set();
        }

        public static Set operator %(Set obj1, Set obj2) //пересечение
        {
            Console.Write($"\n");
            for (int i = 0; i < obj2.Mas.Length; i++)
            {
                for (int j = 0; j < obj1.Mas.Length; j++)
                {
                    if (obj2.Mas[i] == obj1.Mas[j]) { Console.Write($"{obj1.Mas[j]} "); break; }
                }
            }
            return new Set();
        }

        public Set() { }

        public class Owner
        {
            Set id;
            Set name;
            Set place;

            public void GetInfo()
            {
                Console.Write($"\nid = {id}, name = {name}, place = {place}");
            }
        }

        public class Date
        {
            Set date;
        }
    }



    public static class MathOperation
    {
        public static void Min(string[] Mas)
        {
            int count = 0, k = 99, id = 0;
            for (int i = 0; i < Mas.Length; i++)
            {
                count = Mas[i].Length;
                if (count < k) { k = count; id = i; }
            }
            Console.WriteLine($"\nНомер самого короткого слова - {id};");
        }

        public static void Max(string[] Mas)
        {
            int count = 0, k = 0, id = 0;
            for (int i = 0; i < Mas.Length; i++)
            {
                count = Mas[i].Length;
                if (count > k) { k = count; id = i; }
            }
            Console.WriteLine($"\nНомер самого длинного слова - {id};");
        }

        public static void Length(string[] Mas)
        {
            Console.WriteLine($"\nВ масиве {Mas.Length} элементов;");
        }

        public static void Sort(string[] Mas) //по длине
        {
            int count = 0, id = 0;
            int k;
            string first;
            for (int j = 0; j < Mas.Length; j++)
            {
                int min = 99;
                for (int i = count; i < Mas.Length; i++)
                {
                    k = Mas[i].Length;
                    if (k < min) { min = k; id = i; }
                    if (i == Mas.Length - 1)
                    {
                        first = Mas[id];
                        Mas[id] = Mas[count];
                        Mas[count] = first;
                        count++;
                    }
                }
            }
        }

        public static void GetInfo(string[] Mas)
        {
            for (int i = 0; i < Mas.Length; i++)
            {
                Console.Write($"{Mas[i]} ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set obj1 = new Set();
            Set obj2 = new Set();

            Set.Owner alina = new Set.Owner();
            Set.Date day = new Set.Date();

            MathOperation.GetInfo(obj1.Mas);
            MathOperation.Min(obj1.Mas);
            MathOperation.Max(obj1.Mas);
            MathOperation.Length(obj1.Mas);
            MathOperation.Sort(obj1.Mas);
            MathOperation.GetInfo(obj1.Mas);

            Console.WriteLine(obj1 < obj2);
            Console.WriteLine(obj1 != obj2);
            Console.WriteLine(obj1 << 2);
            MathOperation.GetInfo(obj1.Mas);
            Console.WriteLine(obj1 % obj2);
            Console.ReadLine();
        }
    }
}