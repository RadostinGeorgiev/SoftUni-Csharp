using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; protected set; }
        public string Color { get; protected set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}")
                .AppendLine(Start())
                .AppendLine(Stop());

            return sb.ToString().Trim();
        }
    }
}