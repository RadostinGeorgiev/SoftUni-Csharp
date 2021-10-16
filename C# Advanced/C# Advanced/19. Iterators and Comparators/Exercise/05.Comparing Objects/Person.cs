using System;

namespace ComparingObjects
{
    class Person : IComparable<Person>
    {
        private string _name;

        public Person(string name, int age, string town)
        {
            _name = name;
            _age = age;
            _town = town;
        }

        private int _age;
        private string _town;

        public int CompareTo(Person other)
        {
            int result = this._name.CompareTo(other._name);

            if (result == 0)
            {
                result = this._age.CompareTo(other._age);
            }

            if (result == 0)
            {
                result = this._town.CompareTo(other._town);
            }

            return result == 0 ? 0 : result;
        }
    }
}