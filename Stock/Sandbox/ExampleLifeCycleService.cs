namespace Stock.Examples
{
    public class ExampleLifeCycleService
    {
        public ExampleSingleton _exampleSingleton { get; set; }
        public ExampleScoped _exampleScoped { get; set; }
        public ExampleTransient _exampleTransient { get; set; }

        public ExampleLifeCycleService(ExampleSingleton exampleSingleton, ExampleScoped exampleScoped, ExampleTransient exampleTransient)
        {
            _exampleSingleton = exampleSingleton;
            _exampleScoped = exampleScoped;
            _exampleTransient = exampleTransient;
        }
        public void OrchestrateLifeCycle()
        {
            Console.WriteLine("#############################");
            _exampleSingleton.DoSomething();
            _exampleScoped.DoSomething();
            _exampleTransient.DoSomething();
        }
    }
}
