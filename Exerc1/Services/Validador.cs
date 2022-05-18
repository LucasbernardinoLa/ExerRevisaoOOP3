using System.Globalization;

namespace Exerc1.Services
{
    internal class Validador
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Renda_Mensal { get; set; }
        public string Dt_Nascimento { get; set; }
        public string Estado_Civil { get; set; }
        public string Dependente { get; set; }



        public Validador(string nome, string cpf, string dt_Nascimento, string renda_Mensal, string estado_Civil, string dependente)
        {

            Nome = nome;
            Cpf = cpf;
            Dt_Nascimento = dt_Nascimento;
            Renda_Mensal = renda_Mensal;
            Estado_Civil = estado_Civil;
            Dependente = dependente;


            string txt = $"Nome:{Nome} \n" +
                   $"Cpf: {Cpf} \n " +
                   $"Data de nascimento: {Dt_Nascimento}\n " +
                   $"Renda: {Renda_Mensal:F2}\n " +
                   $"Estado civil: {Estado_Civil.ToString().ToUpperInvariant()}\n " +
                   $"Dependentes: {Dependente}\n ";

            if (nome.Length < 5)
            {
                while (true)
                {

                    Console.WriteLine();
                    Console.WriteLine(txt);
                    Console.Write($"o valor digitado {nome} é inválido, o nome deve conter ao menos 5 caracteres, digite um nome válido: ");
                    Console.WriteLine();
                    nome = Console.ReadLine();

                    if (nome.Length >= 5)
                    {
                        break;
                    }
                }
            }

            if (!(ValidaCpf(cpf)))
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(txt);
                    Console.Write($"o valor digitado {cpf} é inválido, cpf inválido, digite novamente: ");
                    cpf = Console.ReadLine();

                    if (ValidaCpf(cpf))
                    {
                        break;
                    }
                }
            }
            if (!(ValidaRenda(Renda_Mensal)))
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(txt);
                    Console.Write($"o valor digitado {Renda_Mensal} é inválido, digite uma nova renda válida: ");
                    dt_Nascimento = Console.ReadLine();

                    if (ValidaData(Renda_Mensal))
                    {
                        break;
                    }
                }
            }
            if (!(ValidaData(dt_Nascimento)))
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(txt);
                    Console.Write($"o valor digitado {dt_Nascimento} é inválido, digite uma nova data válida: ");
                    dt_Nascimento = Console.ReadLine();

                    if (ValidaData(dt_Nascimento))
                    {
                        break;
                    }
                }
            }
            if (!(ValidaEstado(estado_Civil)))
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(txt);
                    Console.Write($"o valor digitado {estado_Civil} é inválido, digite novamente o caractere: ");
                    estado_Civil = Console.ReadLine();

                    if (ValidaEstado(estado_Civil))
                    {
                        break;
                    }
                }
            }
            if (!(VerificaDepen(dependente)))
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(txt);
                    Console.Write($"o valor digitado {dependente} é inválido, digite novamente o número de dependentes: ");
                    dependente = Console.ReadLine();

                    if (VerificaDepen(dependente))
                    {

                        break;
                    }
                }
            }
        }

        private static bool ValidaCpf(string cpf)
        {
            try
            {
                int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = cpf.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
                if (cpf.Length != 11)
                {
                    Console.WriteLine();
                    Console.WriteLine("O cpf deve conter exatamente 11 dígitos! ");
                    Console.WriteLine();
                    return false;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (i.ToString().PadLeft(11, char.Parse(i.ToString())) == cpf)
                    {
                        Console.WriteLine();
                        Console.WriteLine("O cpf não pode conter números repetidos! ");
                        Console.WriteLine();
                        return false;
                    }
                }

                string existeCpf = cpf.Substring(0, 9);
                int sum = 0;

                for (int i = 0; i < 9; i++)
                {
                    sum += int.Parse(existeCpf[i].ToString()) * mult1[i];
                }

                int resto = sum % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                string digito = resto.ToString();
                existeCpf += digito;
                sum = 0;
                for (int i = 0; i < 10; i++)
                    sum += int.Parse(existeCpf[i].ToString()) * mult2[i];

                resto = sum % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }
            catch (FormatException)
            {

                Console.WriteLine();
                Console.WriteLine("O cpf deve ser escrito em números! ");
                Console.WriteLine();
                return false;
            }
        }



        private static bool ValidaData(string data)
        {
            try
            {
                DateTime d_Data = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var idade = DateTime.Today.Year - d_Data.Year;
                if (DateTime.Today.DayOfYear < d_Data.DayOfYear)
                {
                    idade--;
                    if (idade < 18)
                    {
                        Console.WriteLine();
                        Console.WriteLine("O usuário precisa ter no minímo 18 anos!: ");
                        Console.WriteLine();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("O o input deve ser feito exatamente no formato especificado (dd/mm/aaaa)");
                Console.WriteLine();
                return false;
            }
        }
        private static bool VerificaDepen(string dependente)
        {
            try
            {
                if (dependente == null)
                {
                    dependente = "0";
                }
                int i_Dependente = int.Parse(dependente);
                if (i_Dependente <= 10 && i_Dependente >= 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Só podem ser aceitos os números de 0 a 10!");
                    Console.WriteLine();
                    return false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Digite a quantidade de dependentes em um formato válido! ");
                Console.WriteLine();
                return false;
            }

        }
        private static bool ValidaEstado(string estado)
        {
            try
            {
                if (estado.Length > 1)
                {

                    Console.WriteLine();
                    Console.WriteLine("Deve haver somente um caracter no campo!");
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    char c_Estado = char.Parse(estado);
                    if (c_Estado == 'C' || c_Estado == 'c')
                    {
                        return true;
                    }
                    if (c_Estado == 'S' || c_Estado == 's')
                    {
                        return true;
                    }
                    if (c_Estado == 'D' || c_Estado == 'd')
                    {
                        return true;
                    }
                    if (c_Estado == 'V' || c_Estado == 'v')
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Digite somente uma das letras listadas acima! ");
                        Console.WriteLine();
                        return false;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Digite o input do caractere em um formato válido! ");
                Console.WriteLine();
                return false;
            }
        }
        private static bool ValidaRenda(string renda)
        {
            try
            {
                float r_Renda = float.Parse(renda);
                if (r_Renda <= 0.0)
                {
                    Console.WriteLine("A renda deve ser maior que zero! ");
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {

                Console.WriteLine();
                Console.WriteLine("Digite a renda em um formato válido!");
                Console.WriteLine();
                return false;
            }
        }
        public override string ToString()
        {
            return $"Nome: {Nome} \n" +
                   $"Cpf: {Cpf} \n " +
                   $"Data de nascimento: {Dt_Nascimento}\n " +
                   $"Renda: {Renda_Mensal:F2}\n " +
                   $"Estado civil: {Estado_Civil.ToString().ToUpperInvariant()}\n " +
                   $"Dependentes: {Dependente}\n ";
        }
    }
}

