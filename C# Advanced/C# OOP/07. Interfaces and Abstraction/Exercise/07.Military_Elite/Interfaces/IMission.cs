using MilitaryElite.Enumerators;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }

        public void CompleteMission();
    }
}