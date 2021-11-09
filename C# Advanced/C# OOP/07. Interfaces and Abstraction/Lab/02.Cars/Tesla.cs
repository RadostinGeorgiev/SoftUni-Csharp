using System.Text;

namespace Cars
{
    public class Tesla : Seat, IElectricCar

    {
        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries")
                .AppendLine(Start())
                .AppendLine(Stop());

            return sb.ToString().Trim();
        }
    }
}