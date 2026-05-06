namespace Stock.Examples
{
    public class ExampleSingleton
    {
        public void DoSomething()
        {
            Console.WriteLine($"Singleton HashCode: {this.GetHashCode()}");
        }
    }
}
