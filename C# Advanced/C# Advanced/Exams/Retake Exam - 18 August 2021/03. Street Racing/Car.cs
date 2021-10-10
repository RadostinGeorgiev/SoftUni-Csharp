using System;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            HorsePower = horsePower;
            LicensePlate = licensePlate;
            Make = make;
            Model = model;
            Weight = weight;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Make: {Make}")
                .AppendLine($"Model: {Model}")
                .AppendLine($"License Plate: {LicensePlate}")
                .AppendLine($"Horse Power: {HorsePower}")
                .AppendLine($"Weight: {Weight}");

            return sb.ToString().TrimEnd();
        }
    }
}