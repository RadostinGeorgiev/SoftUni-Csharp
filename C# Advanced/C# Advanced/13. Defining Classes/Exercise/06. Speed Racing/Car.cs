namespace Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double traveledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TraveledDistance = traveledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public bool MoveCar(double distance)
        {
            double availableFuel = this.FuelAmount - distance * this.FuelConsumptionPerKilometer;
            if (availableFuel >= 0)
            {
                this.FuelAmount = availableFuel;
                this.TraveledDistance += distance;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TraveledDistance}";
        }
    }
}