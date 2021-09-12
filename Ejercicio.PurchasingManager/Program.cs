using System;
using System.Collections.Generic;

namespace Ejercicio.PurchasingManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> itemCount = new List<int>{ 10, 20, 30, 40, 15 };
            int target = 80;

            int result = restock(itemCount, target);

            Console.WriteLine(result);

        }

        public static int restock(List<int> itemCount, int target)
        {
            int purchased = 0;

            foreach (int item in itemCount)
            {
                purchased += item;

                if(purchased >= target)
                    break;
            }

            return purchased - target;
        }

    }
}
