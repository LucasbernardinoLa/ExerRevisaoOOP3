using Exerc1.Services;

namespace Exerc1.Entities
{
    internal class Client
    {
        public List<Validador> Validadores { get; private set; } = new List<Validador>();


        private void Conversao()
        {
            foreach(var validador in Validadores)
            {
                long.Parse(validador.Cpf);
                DateTime.Parse(validador.Dt_Nascimento);
                float.Parse(validador.Renda_Mensal);
                char.Parse(validador.Estado_Civil);
                int.Parse(validador.Dependente);
            }
        }

        public Client()
        {
        }

        public void Imprime()
        {

            foreach(var validador in Validadores)
            {
                Console.WriteLine(validador);
            }
        }
        public void AddValidador(List <Validador> v)
        {
            Conversao();
            Validadores = v;
           
        }
    }
}
