using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        public List<Person> FamilyMembers { get; set; }

        public void AddMember(Person member)
        {
            this.FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = this.FamilyMembers.Max(x => x.Age);
            return this.FamilyMembers.First(x => x.Age == maxAge);
        }
    }
}