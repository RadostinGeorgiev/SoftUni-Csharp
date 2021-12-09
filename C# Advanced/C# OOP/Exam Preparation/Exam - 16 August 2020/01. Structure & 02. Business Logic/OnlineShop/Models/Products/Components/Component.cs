namespace OnlineShop.Models.Products.Components
{
    using static Common.Constants.SuccessMessages;

    public abstract class Component : Product, IComponent
    {
        protected Component(
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; private set; }

        public override string ToString()
        {
            return base.ToString() + 
                   string.Format(ComponentToString, Generation);
        }
    }
}