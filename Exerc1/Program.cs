using Exerc1.Services;
using Exerc1.Entities;
using Newtonsoft.Json;

string fileName = @"C:\Users\lucas\source\repos\ExerRevisaoOOP3\Exerc1\Jsons\Clientes.json";
string jsonString = File.ReadAllText(fileName);
 var validador = JsonConvert.DeserializeObject<List<Validador>>(jsonString);


Client c = new Client();
c.AddValidador(validador);
c.Imprime();
