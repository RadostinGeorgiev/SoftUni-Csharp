using System;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string _name;
        private int _age;
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this._name.CompareTo(other._name);

            if (result == 0)
            {
                result = this._age.CompareTo(other._age);
            }

            return result == 0 ? 0 : result;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() + _age.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person person)
            {
                return _name.Equals(person._name) && _age.Equals(person._age);
            }

            return false;
        }
    }
}