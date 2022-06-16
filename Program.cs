using System;
using System.Threading;

namespace Game
{
    public class Raffle
    {
        public bool victory;

        // display welcome message
        public void Welcome()
        {
            Console.WriteLine("\n\n*********************************");
            Console.WriteLine("Welcome to the lotto game\n");
        }

        // show dots while raffling
        static void ShowDots()
        {
            int i = 0;
            while (i < 3)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                i++;
            }
            Console.WriteLine("\n\n");
        }

        void GetResult()
        {
            var rand = new Random();
            if (rand.Next(100) > 70)
            {
                this.victory = true;
            }
            else
            {
                this.victory = false;
            }
        }
        //GetResult overload for additional task
        void GetResult(int guess = 0)
        {
            var rand = new Random().Next(10);

            if (rand == guess)
            {
                this.victory = true;
                Console.WriteLine("Raffle result was: {0}", rand);
            }
            else
            {
                this.victory = false;
                Console.WriteLine("Raffle result was: {0}", rand);
            }
        }

        // play the game
        public void Play()
        { //I lazily refactored this method to work with new game logic..
            Console.Write("Enter number between 1 and 10: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            //Console.ReadKey(true);
            Console.Write("Raffling ");
            ShowDots();
            GetResult(userInput);
        }


        
    }
    //Extension method as per requested
    public static class MyExtension
    {
        public static void GivePrize(this Raffle raffle)
        {
            if (raffle.victory) Console.WriteLine("You won 3 million alpacas!");
            else Console.WriteLine("You != winner...");
        }
    }


    class Exercise
    {
        static void Main(string[] args)
        {

            Raffle lotto = new Raffle();

            lotto.Welcome();
            lotto.Play();

            //Extension method in use
            lotto.GivePrize();
          

            Console.WriteLine("*********************************");
        }
    }


}