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

Console.WriteLine("---------------------------");
Console.WriteLine("jogo de adivinhação");
Console.WriteLine("---------------------------");

Console.WriteLine();
Console.Write("Digite um numero: ");
string strnumeroDigitado = Console.ReadLine();

int numeroaleatorio = RandomNumberGenerator.GetInt32(1, 21);

Console.WriteLine("O numero aleatório: " + numeroaleatorio);

Console.ReadLine();