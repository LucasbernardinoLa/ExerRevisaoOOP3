using Exerc4.Extensions;
using Exerc4.Entities;


List<string> listString = new List<string> {"conan", "conan", "conan", "aurea", "aurea", "maga"};
List<int> listInt = new List<int> { 1, 2, 1, 2, 3, 4, 5 };
List<Client> listClient = new List<Client> { new Client("conan", 15399715708), new Client("aurea", 18640470707), new Client ("conan", 144778824), new Client("bob", 15399715708) };

listString.RemoveRepetidos();
Console.WriteLine();
listInt.RemoveRepetidos();
Console.WriteLine();
listClient.RemoveRepetidos();
