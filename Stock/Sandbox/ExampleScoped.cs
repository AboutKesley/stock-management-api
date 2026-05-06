namespace Stock.Examples
{
    public class ExampleScoped
    {
        public void DoSomething()
        {
            Console.WriteLine($"Scoped HashCode: {this.GetHashCode()}");
        }
    }
}
