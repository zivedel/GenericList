using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("list 1:\n");
            var l1 = new GenericList<double>();
            Console.WriteLine(l1);
            l1.Add(3.6);
            l1.Add(9.9);
            Console.WriteLine(l1);
            l1.RemoveAt(1);
            Console.WriteLine(l1);

            Console.WriteLine("\n\nlist 2:\n");
            var l2 = new GenericList<Person>();
            Console.WriteLine(l2);
            l2.Add(new Person("Name1", 15));
            l2.Add(new Person("Name2", 20));
            Console.WriteLine(l2);
            l2.RemoveAt(1);
            Console.WriteLine(l2);
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

    }

    class GenericList<T>
    {
        private T[] _innerArray;
        public GenericList()
        {
            _innerArray = new T[0];
        }

        public T Get(int index)
        {
            return _innerArray[index];
        }

        public void Add(T item)
        {
            T[] temp = new T[_innerArray.Length + 1];
            for (int i = 0; i < _innerArray.Length; i++)
                temp[i] = _innerArray[i];
            temp[_innerArray.Length] = item;
            _innerArray = temp;
        }

        public void RemoveAt(int index)
        {
            if (index >= _innerArray.Length)
                throw new IndexOutOfRangeException();

            T[] temp = new T[_innerArray.Length - 1];
            for (int i = 0; i < index; i++)
                temp[i] = _innerArray[i];

            for (int i = index + 1; i < _innerArray.Length; i++)
                temp[i - 1] = _innerArray[i];

            _innerArray = temp;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(_innerArray);
        }
    }
}
