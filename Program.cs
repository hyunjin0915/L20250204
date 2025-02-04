using System;

namespace L20250204
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[52];  // 1~52 저장
            for (int i = 0; i < 52; i++)
            {
                arr[i] = i + 1;
            }

            Random randomObj = new Random();

            // Fisher-Yates Shuffle
            for (int i = 51; i > 0; i--)
            {
                int j = randomObj.Next(0, i + 1);
                (arr[i], arr[j]) = (arr[j], arr[i]);  // Swap
            }

            // 앞에서 8개 출력
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}