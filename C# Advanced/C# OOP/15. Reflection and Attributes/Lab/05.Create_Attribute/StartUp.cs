namespace AuthorProblem
{
    [Author("Radostin")]
    public class StartUp
    {
        [Author("Georgiev")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}