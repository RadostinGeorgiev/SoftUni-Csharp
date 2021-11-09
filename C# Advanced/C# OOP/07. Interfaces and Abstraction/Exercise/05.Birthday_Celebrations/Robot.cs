namespace BirthdayCelebrations
{
    public class Robot : IInhabitant
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Id { get; }
        public string Model { get; protected set; }
    }
}