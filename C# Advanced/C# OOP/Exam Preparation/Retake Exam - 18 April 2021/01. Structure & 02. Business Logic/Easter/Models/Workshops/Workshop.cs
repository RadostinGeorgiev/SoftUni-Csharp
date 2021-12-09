namespace Easter.Models.Workshops
{
    using Bunnies.Contracts;
    using Contracts;
    using Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone() && bunny.Energy > 0 && bunny.Dyes.Count > 0) 
            {
                bunny.Work();
                egg.GetColored();
            }
        }
    }
}