namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}