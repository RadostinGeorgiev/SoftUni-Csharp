namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.username = username;
            this.level = level;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public override string ToString() => $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
    }
}