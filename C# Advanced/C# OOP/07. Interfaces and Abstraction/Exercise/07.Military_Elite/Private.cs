using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:F2}";
        }
    }
}