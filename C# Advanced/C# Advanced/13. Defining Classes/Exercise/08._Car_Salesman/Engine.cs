using System.Text;

namespace RawData
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public void AddEngineDisplacement(int displacement)
        {
            Displacement = displacement;
        }

        public void AddEngineEfficiency(string efficiency)
        {
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine(Displacement == 0 ? $"    Displacement: n/a" : $"    Displacement: {Displacement}");
            sb.Append(Efficiency == null ? $"    Efficiency: n/a" : $"    Efficiency: {Efficiency}");
            return sb.ToString();
        }
    }
}