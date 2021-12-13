namespace Bakery.Core.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.BakedFoods;
    using Models.BakedFoods.Contracts;
    using Models.Drinks;
    using Models.Drinks.Contracts;
    using Models.Tables;
    using Models.Tables.Contracts;
    using static Utilities.Messages.OutputMessages;

    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> bakedFoods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = type switch
            {
                nameof(Bread) => new Bread(name, price),
                nameof(Cake) => new Cake(name, price),
                _ => null
            };

            if (bakedFood == null) return null;

            this.bakedFoods.Add(bakedFood);

            return string.Format(FoodAdded, bakedFood.Name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                nameof(Tea) => new Tea(name, portion, brand),
                nameof(Water) => new Water(name, portion, brand),
                _ => null
            };

            if (drink == null) return null;

            this.drinks.Add(drink);

            return string.Format(DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                nameof(InsideTable) => new InsideTable(tableNumber, capacity),
                nameof(OutsideTable) => new OutsideTable(tableNumber, capacity),
                _ => null
            };

            if (table == null) return null;

            this.tables.Add(table);

            return string.Format(TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return string.Format(ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(TableReserved, table.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(WrongTableNumber, tableNumber);
            }

            IBakedFood bakedFood = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (bakedFood == null)
            {
                return string.Format(NonExistentFood, foodName);
            }

            table.OrderFood(bakedFood);

            return string.Format(FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(WrongTableNumber, tableNumber);
            }

            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return string.Format(NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return string.Format(FoodOrderSuccessful, tableNumber, $"{drinkName} {drinkBrand}");
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(WrongTableNumber, tableNumber);
            }

            var bill = table.GetBill(); ;
            this.totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = this.tables.Where(t => t.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(TotalIncome, this.totalIncome);
        }
    }
}