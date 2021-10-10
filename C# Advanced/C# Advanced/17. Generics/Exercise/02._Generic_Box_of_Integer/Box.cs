namespace GenericBox
{
    public class Box<T>
    {
        private T data;
        public Box(T item)
        {
            data = item;
        }

        public override string ToString()
        {
            return $"{data.GetType()}: {data}";
        }
    }
}