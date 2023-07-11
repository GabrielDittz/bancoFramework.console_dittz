using Application;
using Domain.Model;
using CpfCnpjLibrary;
using Microsoft.Extensions.DependencyInjection;
using Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Dependency injection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var provider = serviceCollection.BuildServiceProvider();
        var service = provider.GetService<IClienteRepository>();
        #endregion

        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");

        Console.ReadKey();

        var cliente = Identificacao(service);

        var calculo = new Calculo();
        int opcao = 0;

        while(opcao != 3)
        {
            opcao = Menu(cliente, opcao);

            if(opcao == 1)
            {
                Console.Clear();

                Console.WriteLine("\"Digite o valor para depositar:");
                var valor = float.Parse(Console.ReadLine());

                cliente.Saldo = calculo.Soma(cliente.Saldo, valor);

                service.Update(cliente);

                Console.WriteLine($"Seu saldo atual é {cliente.Saldo.ToString("C")}");

                Console.ReadLine();
            }else if(opcao == 2)
            {
                Console.Clear();

                Console.WriteLine("Digite o valor para sacar:");
                var valor = float.Parse(Console.ReadLine());

                cliente.Saldo = calculo.Subtracao(cliente.Saldo, valor);

                service.Update(cliente);

                Console.WriteLine($"Seu saldo atual é {cliente.Saldo.ToString("C")}");

                Console.ReadLine();
            }
        }
    }

    static Cliente Identificacao(IClienteRepository clienteRepository)
    {
        var cliente = new Cliente();

        var erros = new List<string>
        {
            " "
        };

        while (erros.Count() != 0)
        {
            erros.Clear();

            Console.Clear();

            Console.WriteLine("Seu número de identificação:");
            var id = Console.ReadLine();

            if (!int.TryParse(id, out _))
            {
                erros.Add("Identificador não é válido.");
            }
            else
            {
                cliente.Id = int.Parse(id);

                var getCliente = clienteRepository.GetClienteById(cliente.Id);

                if (getCliente != null)
                {
                    return getCliente;
                }
            }

            Console.WriteLine("Seu nome:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Seu CPF:");
            cliente.Cpf = Console.ReadLine();

            if (Cpf.Validar(cliente.Cpf) == false)
            {
                erros.Add("CPF digitado não é válido.");
            }

            Console.WriteLine("Seu saldo:");
            var saldo = Console.ReadLine();

            if (!float.TryParse(saldo, out _))
            {
                erros.Add("Saldo não é válido.");
            }
            else
            {
                cliente.Saldo = float.Parse(saldo);
            }

            if (erros.Count() > 0)
            {
                foreach (var item in erros)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }

            Console.Clear();
        }
        clienteRepository.Add(cliente);

        return cliente;
    }

    static int Menu(Cliente cliente, int opcao)
    {
        Console.Clear();

        Console.Write($"Como posso ajudar {cliente.Nome}?\n" +
            "1 - Depósito\n" +
            "2 - Saque\n" +
            "3 - Sair");

        Console.WriteLine("");

        Console.WriteLine("----------");
        Console.WriteLine("Selecione uma opção:");

        opcao = int.Parse(Console.ReadLine());

        return opcao;
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
    }
}