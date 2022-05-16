using Exerc3.Extensions;

try
{
    Console.WriteLine("Digite o número: ");
    int n = int.Parse(Console.ReadLine());

    Armstrong.IsArmstrong(n);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
