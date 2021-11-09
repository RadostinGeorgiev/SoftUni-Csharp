using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public AddRemoveCollection() 
            : base()
        {
        }

        public override int Add(string item)
        {
            int index = 0;
            myList.Insert(index, item);
            return index;
        }

        public virtual string Remove()
        {
            int index = this.myList.Count -1;
            string item = this.myList[index];
            this.myList.RemoveAt(index);
            return item;
        }
    }
}