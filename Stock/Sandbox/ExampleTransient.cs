namespace Stock.Examples
{
    public class ExampleTransient
    {
        public void DoSomething()
        {
            Console.WriteLine($"Transient HashCode: {this.GetHashCode()}");
        }
    }
}
