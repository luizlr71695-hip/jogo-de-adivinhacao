using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

/*

v1

Iremos fazer um jogo onde o usuário terá chances de acertar um número aleatório decidido pelo sistema.

Input (Entrada de Dados)
O usuário digita número inteiro

Processamento
O sistema compara o número digitado com um número inteiro aleatório

Output (Saída de Dados)
O sistema informará o usuário se o mesmo acertou ou não, podendo incluir dicas sobre a proximidade do "chute"

*/

bool jogodevecontinuar = true;

while (jogodevecontinuar == true)
{
    Console.Clear();

    Console.WriteLine("---------------------------");
    Console.WriteLine("jogo de adivinhação");
    Console.WriteLine("---------------------------");
    Console.WriteLine("Escolha o nivel de dificuldade:");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("1- Facil (10 tentativas)");
    Console.WriteLine("2- médio (5 tentativas)");
    Console.WriteLine("3- Dificil (3 tentativas)");
    Console.WriteLine("-------------------------------");

    Console.Write("Digite sua escolha: ");
    string dificuldadeEscolhida = Console.ReadLine();

    int numeroaleatorio;
    int tentativasmaximas;

    switch (dificuldadeEscolhida)
    {
        case "1":
            numeroaleatorio = RandomNumberGenerator.GetInt32(1, 21);
            tentativasmaximas = 10;
            break;

        case "2":
            numeroaleatorio = RandomNumberGenerator.GetInt32(1, 51);
            tentativasmaximas = 5;
            break;

        case "3":
            numeroaleatorio = RandomNumberGenerator.GetInt32(1, 101);
            tentativasmaximas = 3;
            break;

        default:
            Console.WriteLine("----------------------------");
            Console.WriteLine("Por favor, selecione uma dificuldade válida.");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            continue;
    }

    int pontuacao = 1000;

    int[] numerosdigitados = new int[tentativasmaximas];
    int contadornumerodigitados = 0;


    for (int tentativaAtual = 1; tentativaAtual <= tentativasmaximas; tentativaAtual++)
    {
        Console.Clear();
        Console.WriteLine("----------------------------");
        Console.WriteLine("jogo da adivinhação");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"tentativa {tentativaAtual} de {tentativasmaximas}");
        Console.WriteLine("-----------------------------");


        Console.Write("Digite um numero: ");
        int numerosdigitado = Convert.ToInt32(Console.ReadLine());

        bool numeroEstarepetido = false;

        for (int indiceatual = 0; indiceatual < numerosdigitados.Length; indiceatual++)
        {
            if (numerosdigitados[indiceatual] == numerosdigitado)
            {
                numeroEstarepetido = true;
                break;
            }
        }

        if (numeroEstarepetido == true)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("vôce ja digitou este numero, tente novamente.");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();

            tentativaAtual--;
            continue;
        }

        if (contadornumerodigitados < numerosdigitados.Length)
        {
            numerosdigitados[contadornumerodigitados] = numerosdigitado;
            contadornumerodigitados++;
        }
        else
        {
            numerosdigitados = new int[tentativasmaximas];
            contadornumerodigitados = 0;

            numerosdigitados[contadornumerodigitados] = numerosdigitado;
            contadornumerodigitados++;

        }

        if (numerosdigitado == numeroaleatorio)

        {
            Console.WriteLine("Parabéns, você acertou! o numero era " + numeroaleatorio);
            break;
        }

        else if (numerosdigitado > numeroaleatorio)
        {
            Console.WriteLine("O numero digitado foi maior que o numero secreto!");
        }
        else
        {
            Console.WriteLine("O numero digitado foi menor que o numero secreto!");
        }

        int diferencanumerica = Math.Abs(numeroaleatorio - numerosdigitado);

        if (diferencanumerica >= 10)
        {
            pontuacao -= 100;
        }

        else if (diferencanumerica >= 5)
        {
            pontuacao -= 50;
        }
        else
        {
            pontuacao -= 20;
        }

        Console.WriteLine("-----------------------------");
        Console.WriteLine("Sua pontuação é: " + pontuacao);
        Console.WriteLine("-----------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    Console.WriteLine("------------------------------------------");
    Console.Write("Deseja continuar? (s/N): ");
    string opcaocontinuar = Console.ReadLine();

    if (opcaocontinuar != "S" && opcaocontinuar != "s")
    {
        jogodevecontinuar = false;
    }
    Console.ReadLine();
}

















