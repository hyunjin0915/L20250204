using System.Diagnostics;

namespace L20250204
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[53];
            bool[] isSelected = new bool[53];
            Random randomObj = new Random();
            int cnt = 0;
            for (int i = 1; i <= 52; i++)
            {
                arr[i] = i;
            }
            while (cnt<8)
            {
                
                int randomNum = randomObj.Next(1, 52);
                if (isSelected[randomNum])
                {
                    continue;
                }
                isSelected[randomNum] = true;
                cnt++;
            }
            for (int i = 1; i <= 52; i++)
            {
                if (isSelected[i])
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}
