using Domain.Model;
using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();


    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();

        int option = 0;

        while (option < 1 || option > 3)
        {
            Console.Clear();
            Console.Write($"Como posso ajudar {pessoa.Nome}?\n" +
            "1 - Depósito\n" +
            "2 - Saque\n" +
            "3 - Sair");

            Console.WriteLine("");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção:");

            option = int.Parse(Console.ReadLine());
        }

        if (option == 1)
        {
            Console.WriteLine("Depósito");
        }
        else if (option == 2)
        {
            Console.WriteLine("Saque");
        }
        else if (option == 3)
        {
            Console.ReadKey();
        }

        Console.ReadKey();

        return pessoa;
    }
}