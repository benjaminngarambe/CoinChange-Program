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

        //greedy change function for general algorithm
        public static void makeGreedyChangeGeneral(int[] arrayOfCoins, int change)
        {
            //assigning of variables
            int[] coins = new int[arrayOfCoins.Length];
            Array.Copy(arrayOfCoins, coins, arrayOfCoins.Length);
            Array.Sort(coins);

            int[] minCoins = new int[change + 1];
            int[] firstCoinIndex = new int[change + 1];

            for (int secChange = 0; secChange < change + 1; secChange++)
            {
                int coinCount = secChange;
                int newCoinIndex = 0;

                for (int coinIndex = 0; coinIndex < coins.Length; coinIndex++)
                {
                    int coin = coins[coinIndex];
                    if (coin > secChange)
                    {
                        continue;
                    }
                    if (1 + minCoins[secChange - coin] < coinCount)
                    {
                        coinCount = 1 + minCoins[secChange - coin];
                        newCoinIndex = coinIndex;
                    }
                }
                minCoins[secChange] = coinCount;
                firstCoinIndex[secChange] = newCoinIndex;
            }

            int currChange2 = change;
            int[] coincount = new int[arrayOfCoins.Length];
            List<string> change_list = new List<string>();

            while (currChange2 > 0)
            {
                int coin = coins[firstCoinIndex[currChange2]];
                coincount[firstCoinIndex[currChange2]]++;
                currChange2 -= coin;
            }
            for (int i = 0; i < coincount.Length; i++)
            {
                if (coincount[i] > 0)
                {
                    change_list.Add(coincount[i] + "x" + coins[i]);
                }
            }
            //Writing the coin change statement
            Console.WriteLine("the coin change is:" + string.Join(", ", change_list.ToArray()));
        }

        private static void Main(string[] args)
        {
            int change;
            int AnswerOne;
            Console.WriteLine("***Coin change Program***");
            Console.WriteLine(" Enter 1 if you want the program to make for you a change Automatically");
            Console.WriteLine(" Enter 2 if you want to enter your own array of changes Manually");
            AnswerOne = Convert.ToInt16(Console.ReadLine());

            //if he chooses to do it automatically

            if (AnswerOne == 1)
            {
                int[] Coins = { 1, 2, 5, 10, 20, 50, 100 };
                Console.WriteLine("----------------------------------------------------");
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
                Console.WriteLine("-------------------------------");
                //implementing the make greedy change function
                makeGreedyChange(Coins, change);
                makeGreedyChangeGeneral(Coins, change);
            }

            //if he chooses to enter it by himself
            else if (AnswerOne == 2)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("You have chosen to enter the number available for making changes");
                //to prompt the user to enter the number of elements that are going to be needed for him to make a change
                Console.WriteLine("Enter the Number of changes that are going to compose the array");
                int z = Convert.ToInt32(Console.ReadLine());

                //the string that is going to save the user array of changes
                int[] answerTwo = new int[z];
                for (int i = 0; i < answerTwo.Length; i++)
                {
                    answerTwo[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("---------------------------");
                //display the array the user entered
                Console.WriteLine("this is the array you entered: ");
                Console.WriteLine("[{0}]", string.Join(", ", answerTwo));
                Console.WriteLine("---------------------------");
                //the code to make the change that was previously used in the AnswerOne == 1 statement
                //prompting the user to enter the value to be changed
                Console.WriteLine("Enter value for change");
                change = Convert.ToInt32(Console.ReadLine());

                //if statement to make sure that rules for being give change are applied
                if (change < 0)
                {
                    Console.WriteLine("!!! Input should be a positive integer !!!");
                }
                else if (change == 0)
                {
                    Console.WriteLine("empty string");
                }
                Console.WriteLine("-------------------------------");
                //implementing the make greedy change function
                makeGreedyChange(answerTwo, change);
                makeGreedyChangeGeneral(answerTwo, change);
            }
            else
            {
                Console.WriteLine("!!! you have entered the wrong variables !!!");
                Console.WriteLine("!!! Try again...and try to enter the right variables !!!");
            }
        }
    }
}