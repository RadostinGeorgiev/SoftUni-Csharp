using System;
using MilitaryElite.Enumerators;
using MilitaryElite.Exeptions;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = TryParseState(state);
        }

        public string CodeName { get; set; }
        public State State { get; private set; }

        public void CompleteMission()
        {
            if (State == State.Finished)
            {
                throw new InvalidMissionCompleteException();
            }

            State = State.Finished;
        }

        private State TryParseState(string stateStr)
        {
            State state;

            bool parsed= Enum.TryParse<State>(stateStr, out state);

            if (parsed) return state;
            throw new InvalidStateException();
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}