namespace OnlineShop.Models.Products.Computers
{
    using System;
    using Components;
    using Peripherals;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using static Common.Constants.ExceptionMessages;
    using static Common.Constants.SuccessMessages;

    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance =>
            this.components.Count == 0 ? 
                base.OverallPerformance :
                base.OverallPerformance + this.components.Average(c => c.OverallPerformance);

        public override decimal Price =>
            base.Price +
            this.components.Sum(c => c.Price) +
            this.peripherals.Sum(p => p.Price);

        public IReadOnlyCollection<IComponent> Components => 
            (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => 
            (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(
                    string.Format(ExistingComponent, 
                    component.GetType().Name, 
                    GetType().Name, 
                    Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (this.components.Count == 0 || component == null)
            {
                throw new ArgumentException(
                    string.Format(NotExistingComponent, 
                    componentType, 
                    GetType().Name, 
                    Id));
            }

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(
                    string.Format(ExistingPeripheral, 
                    peripheral.GetType().Name, 
                    GetType().Name, 
                    Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (this.peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException(
                    string.Format(NotExistingPeripheral, 
                    peripheralType, 
                    GetType().Name, 
                    Id));
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine(string.Format(ComputerComponentsToString, this.components.Count));

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            double averageOverallPerformance = this.peripherals.Count == 0 ? 
                0 : 
                this.peripherals.Average(p => p.OverallPerformance);

            sb.AppendLine(string.Format(ComputerPeripheralsToString, 
                this.peripherals.Count,
                averageOverallPerformance.ToString("F2")));

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}