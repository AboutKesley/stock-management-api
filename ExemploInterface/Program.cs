using System;

namespace ExemplosOOP
{
    // =========================
    // EXEMPLO 1: ENCAPSULAMENTO
    // =========================
    public class ContaBancaria
    {
        // Campo privado → ninguém fora da classe pode acessar diretamente
        private decimal _saldo;

        // Propriedade pública somente leitura
        // Permite visualizar o saldo, mas NÃO alterar diretamente
        public decimal Saldo => _saldo;

        public void Depositar(decimal valor)
        {
            // Regra de negócio protegida dentro da classe
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");

            // Alteração controlada do estado interno
            _saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");

            // Regra: não pode sacar mais do que tem
            if (valor > _saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            _saldo -= valor;
        }
    }

    // =========================
    // EXEMPLO 2: DESACOPLAMENTO
    // =========================

    // Interface = contrato
    // Define o que deve ser feito, mas não como
    public interface INotificador
    {
        void Enviar(string mensagem);
    }

    // Implementação 1
    public class EmailNotificador : INotificador
    {
        public void Enviar(string mensagem)
        {
            Console.WriteLine($"E-mail enviado: {mensagem}");
        }
    }

    // Implementação 2
    public class SmsNotificador : INotificador
    {
        public void Enviar(string mensagem)
        {
            Console.WriteLine($"SMS enviado: {mensagem}");
        }
    }

    public class PedidoService
    {
        // Dependência da interface (não da classe concreta)
        // Isso é o que gera o DESACOPLAMENTO
        private readonly INotificador _notificador;

        // A implementação é "injetada" de fora
        public PedidoService(INotificador notificador)
        {
            _notificador = notificador;
        }

        public void ProcessarPedido()
        {
            Console.WriteLine("Pedido processado com sucesso.");

            // Não importa qual implementação está sendo usada
            // Apenas chamamos o contrato
            _notificador.Enviar("Seu pedido foi processado.");
        }
    }

    public class PedidoServiceAcoplado
    {
        public EmailNotificador _emailNotificador { get; set; }
        public SmsNotificador _smsNotificador { get; set; }

        public PedidoServiceAcoplado(EmailNotificador emailNotificador, SmsNotificador smsNotificador)
        {
            _emailNotificador = emailNotificador;
            _smsNotificador = smsNotificador;
        }

        public void ProcessarPedido(string usuario)
        {
            //....
            //Implementação propria do processamento do pedido.

            //Simula chamada ao banco para saber se o usuário tem email cadastrado ou não.
            //var hasUsuarioEmail = _usuarioRepositorio.HasEmail(usuario);
            var hasUsuarioEmail = true; // Simulando que o usuário tem email cadastrado

            if (hasUsuarioEmail)
            {
                var _notificador = new EmailNotificador();
                _notificador.Enviar("Seu pedido foi processado.");
                return;
            }
            else
            {
                var _notificador = new SmsNotificador();
                _notificador.Enviar("Seu pedido foi processado.");
                return;
            }
        }
    }

    // =========================
    // PROGRAMA PRINCIPAL
    // =========================
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== ENCAPSULAMENTO ===");

            var conta = new ContaBancaria();

            // Não conseguimos fazer:
            // conta._saldo = -1000; ❌ (não compila, está protegido)

            conta.Depositar(1000); // ✔ passa pela regra
            conta.Sacar(300);      // ✔ passa pela regra

            Console.WriteLine($"Saldo atual: {conta.Saldo}");

            Console.WriteLine();
            Console.WriteLine("=== DESACOPLAMENTO ===");

            var usuarioEscolhido = Console.ReadLine();

            INotificador notificador = new EmailNotificador(); // valor padrão
            if (usuarioEscolhido!.Equals("Maria"))
            {
                notificador = new SmsNotificador();
            }

            var pedidoService = new PedidoService(notificador);
            pedidoService.ProcessarPedido();

            Console.WriteLine();
            Console.WriteLine("=== ACOPLAMENTO ===");

            var pedidoServiceAcoplado = new PedidoServiceAcoplado(new EmailNotificador(), new SmsNotificador());
            pedidoServiceAcoplado.ProcessarPedido(usuarioEscolhido);
        }
    }
}