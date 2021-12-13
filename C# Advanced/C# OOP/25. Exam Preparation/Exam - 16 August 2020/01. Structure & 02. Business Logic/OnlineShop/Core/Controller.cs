namespace OnlineShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Products.Components;
    using Models.Products.Computers;
    using Models.Products.Peripherals;
    using static Common.Constants.ExceptionMessages;
    using static Common.Constants.SuccessMessages;

    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IPeripheral> peripherals;
        private readonly ICollection<IComponent> components;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.peripherals = new List<IPeripheral>();
            this.components = new List<IComponent>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExistingComputerId);
            }

            IComputer computer = computerType switch
            {
                nameof(DesktopComputer) => new DesktopComputer(id, manufacturer, model, price),
                nameof(Laptop) => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException(InvalidComputerType)
            };

            this.computers.Add(computer);

            return string.Format(AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(NotExistingComputerId);
            }

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExistingPeripheralId);
            }

            IPeripheral peripheral = peripheralType switch
            {
                nameof(Headset) => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(InvalidPeripheralType)
            };

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(NotExistingComputerId);
            }

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return string.Format(RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(NotExistingComputerId);
            }

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExistingComponentId);
            }

            IComponent component = componentType switch
            {
                nameof(CentralProcessingUnit) => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                nameof(Motherboard) => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                nameof(SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                nameof(VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(InvalidComponentType)
            };

            computer.AddComponent(component);
            this.components.Add(component);

            return string.Format(AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(NotExistingComputerId);
            }

            IComponent component = computer.RemoveComponent(componentType);

            this.components.Remove(component);

            return string.Format(RemovedComponent, componentType, component.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(NotExistingComputerId);
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException(string.Format(CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
           
            if (computer == null)
            {
                throw new ArgumentException(NotExistingComputerId);
            }

            return computer?.ToString();
        }
    }
}