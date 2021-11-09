using System.Collections.Generic;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        protected List<string> myList;

        public AddCollection()
        {
            this.myList = new List<string>();
        }

        public virtual int Add(string item)
        {
            int index = this.myList.Count;
            this.myList.Insert(index, item);
            return index;
        }
    }
}