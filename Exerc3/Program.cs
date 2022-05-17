using Exerc3.Extensions;

try
{
    Console.WriteLine("Digite o número: ");
    int n = int.Parse(Console.ReadLine());

    n.IsArmstrong();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
