namespace Exerc4.Extensions
{
    static internal class GenericsExtensions
    {
        public static void RemoveRepetidos<T>(this List<T> thisObj) where T : IComparable
        {

            var result = new List<T>();
            foreach (var item in thisObj)
            {
                if (!(result.Contains(item)))
                {
                    result.Add(item);
                }
            }
            
            thisObj = result;
            foreach (var item in thisObj)
            {
                Console.WriteLine(item.ToString());
            }
        }

       
    }
}
