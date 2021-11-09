using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList() 
            : base()
        {
        }

        public int Used() => this.myList.Count;

        public override string Remove()
        {
            int index = 0;
            string item = this.myList[index];
            this.myList.RemoveAt(index);
            return item;
        }
    }
}