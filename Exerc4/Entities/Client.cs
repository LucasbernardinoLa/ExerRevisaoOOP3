

namespace Exerc4.Entities
{
    internal class Client : IComparable
    {
        public string Nome { get; private set; }
        public long Cpf { get; private set; }

        public Client(string nome, long cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Client other)
            {
                if (Cpf == other.Cpf)
                {    
                    return true;
                }
                return false;
            }
            return false;
        }

        public int CompareTo(object? obj)
        {
            if(!(obj is Client))
            {
                throw new ArgumentException("O objeto deve ser do tipo client! ");
            }
            Client other = obj as Client;
            return Cpf.CompareTo(other.Cpf);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Cpf: {Cpf}";
        }
    }
}
