namespace Exerc3.Extensions
{
    static class Armstrong
    {
        public static bool IsArmstrong(this int thisObj)
        {
            int value = thisObj;

            if (value == SomaValores(value))
            {
                Console.WriteLine($"{value} é um número de Armstrong ");

                Armstrong10000();
                return true;
            }
            else
            {
                Console.WriteLine($"{value} não é um numero de Armstrong");

                Armstrong10000();
                return false;
            }
        }
        private static int AchaPot(int num)
        {
            int i = 0;
            for (; num > 0; ++i) num /= 10;

            return i;
        }

        private static int SomaValores(int num)
        {
            int count = AchaPot(num);

            int sum = 0;
            while (num > 0)
            {
                sum += (int)Math.Pow(num % 10, count);
                num /= 10;
            }

            return sum;
        }
        private static void Armstrong10000()
        {
            Console.WriteLine();
            Console.WriteLine("Números de Armstrong entre 1 e 10000 ");
            for (int n = 1; n <= 10000; n++)
            {
                if (n == SomaValores(n)) Console.WriteLine(n);
            }
        }
    }
}

