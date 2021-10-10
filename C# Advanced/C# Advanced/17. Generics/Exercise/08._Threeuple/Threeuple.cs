namespace Threeuple

{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            firstElement = item1;
            secondElement = item2;
            thirdElement = item3;
        }
        public T1 firstElement { get; set; }
        public T2 secondElement { get; set; }
        public T3 thirdElement { get; set; }

        public override string ToString()
        {
            return $"{firstElement} -> {secondElement} -> {thirdElement}";
        }
    }
}