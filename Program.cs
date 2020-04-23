using System;
using System.Collections.Generic;

namespace project2._1
{
    internal class Program
    {

        //greedy change function algorithm
        public static void makeGreedyChange(int[] coinsTemp, int change)
        {
            //creating an arrray that is going to hold the coins to use to make change
            int[] coins = new int[coinsTemp.Length];

            Array.Copy(coinsTemp, coins, coins.Length);
            Array.Sort(coins);
            Array.Reverse(coins);

            //creating new list for changes
            List<string> change_list = new List<string>();

            //for each statement to make sure that it is going to pick the right coins for change
            foreach (int coin in coins)
            {
                int how_many = change / coin;

                if (how_many > 0)
                {
                    change_list.Add(how_many + "x" + coin);
                }

                change = change % coin;
            }
            //Writing the coin change statement
            Console.WriteLine("the coin change is:" + string.Join(", ", change_list.ToArray()));
        }

        private static void Main(string[] args)
        {
            int[] Coins = { 1, 2, 5, 10, 20, 50, 100 };
            int change;
            //prompting the user to enter the value to be changed
            Console.WriteLine("Enter value for change");
            change = Convert.ToInt32(Console.ReadLine());

            //if statement to make sure that rules for being give change are applied
            if (change < 0)
            {
                Console.WriteLine("Input should be a positive integer");
            }
            else if (change == 0)
            {
                Console.WriteLine("empty string");
            }
            //implementing the make greedy cahnge function
            makeGreedyChange(Coins, change);
        }
    }
}