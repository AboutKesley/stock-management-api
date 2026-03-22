using Microsoft.AspNetCore.Mvc;
using Stock.Dto;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Stock.Examples
{
    //🔁 Fluxo completo (resumido)
    //Chega requisição HTTP
    //.NET precisa do Controller
    //Container tenta criar o Controller
    //Vê dependências no construtor
    //Resolve cada dependência
    //Instancia tudo automaticamente
    //Entrega pronto 🚀
    //“Dependency Injection é um jeito elegante de parar de usar new espalhado no código, e reaproveitar instancias.”
    [ApiController]
    [Route("[controller]")]
    public class ExampleLifeCycleController : ControllerBase
    {
        public ExampleSingleton _exampleSingleton { get; set; }
        public ExampleScoped _exampleScoped { get; set; }
        public ExampleTransient _exampleTransient { get; set; }
        public ExampleLifeCycleService _exampleLifeCycleService { get; set; }

        public ExampleLifeCycleController(ExampleSingleton exampleSingleton, ExampleScoped exampleScoped, ExampleTransient exampleTransient, ExampleLifeCycleService exampleLifeCycleService)
        {
            _exampleSingleton = exampleSingleton;
            _exampleScoped = exampleScoped;
            _exampleTransient = exampleTransient;
            _exampleLifeCycleService = exampleLifeCycleService;
        }

        [HttpPost]
        [Route("dosomething")]
        public void DoSomething()
        {
            Console.WriteLine("REQUEST INIT");
            Console.WriteLine("#############################");
            _exampleSingleton.DoSomething();
            _exampleScoped.DoSomething();
            _exampleTransient.DoSomething();

            _exampleLifeCycleService.OrchestrateLifeCycle();
            Console.WriteLine("REQUEST FINAL");
        }
    }


    //Example of a class that has a dependency on another class. In this case, Carpinteiro depends on Serra.
    public class Carpinteiro
    {
        public Serra _serra { get; set; }

        // CLR creates an instance of Serra and injects it into the constructor of Carpinteiro.
        public Carpinteiro(Serra serra)
        {
            _serra = serra;
        }
        public void UsarSerra()
        {
            _serra.Serrar();
        }
    }

    public class Serra
    {
        public Serra()
        {
        }
        public void Serrar()
        {
            Console.WriteLine("Serrando");
        }
    }
}
