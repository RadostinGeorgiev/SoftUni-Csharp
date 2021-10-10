using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            data = new List<T>();
        }

        public void Add(T item)
        {
            data.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(int index1, int index2)
        {
            (data[index1], data[index2]) = (data[index2], data[index1]);
        }
    }
}