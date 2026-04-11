using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    public class MySet<T> : IEnumerable<T>
    {
        private List<T> items;

        // Конструктор
        public MySet(IEnumerable<T> collection)
        {
            items = new List<T>();

            foreach (T element in collection)
            {
                if (!items.Contains(element))
                {
                    items.Add(element);
                }
            }
        }

        public MySet()
        {
            items = new List<T>();
        }

        // Объединение |
        public static MySet<T> operator |(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T item in a.items)
            {
                if (!result.Contains(item))
                    result.Add(item);
            }

            foreach (T item in b.items)
            {
                if (!result.Contains(item))
                    result.Add(item);
            }

            return new MySet<T>(result);
        }

        // Разность -
        public static MySet<T> operator -(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T item in a.items)
            {
                if (!b.items.Contains(item))
                    result.Add(item);
            }

            return new MySet<T>(result);
        }

        // Пересечение &
        public static MySet<T> operator &(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T item in a.items)
            {
                if (b.items.Contains(item))
                    result.Add(item);
            }

            return new MySet<T>(result);
        }

        // Симметрическая разность /
        public static MySet<T> operator /(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T item in a.items)
            {
                if (!b.items.Contains(item))
                    result.Add(item);
            }

            foreach (T item in b.items)
            {
                if (!a.items.Contains(item))
                    result.Add(item);
            }

            return new MySet<T>(result);
        }

        // ==
        public static bool operator ==(MySet<T> a, MySet<T> b)
        {
            if (ReferenceEquals(a, b)) return true;
            if ((object)a == null || (object)b == null) return false;

            if (a.items.Count != b.items.Count)
                return false;

            foreach (T item in a.items)
            {
                if (!b.items.Contains(item))
                    return false;
            }

            return true;
        }

        // !=
        public static bool operator !=(MySet<T> a, MySet<T> b)
        {
            return !(a == b);
        }

        // Equals
        public override bool Equals(object obj)
        {
            MySet<T> other = obj as MySet<T>;
            if (other == null) return false;

            return this == other;
        }

        // GetHashCode (простой, лишь бы был)
        public override int GetHashCode()
        {
            return items.Count;
        }

        // ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            for (int i = 0; i < items.Count; i++)
            {
                sb.Append(items[i]);

                if (i != items.Count - 1)
                    sb.Append(", ");
            }

            sb.Append("}");
            return sb.ToString();
        }

        // Чтобы foreach работал
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
