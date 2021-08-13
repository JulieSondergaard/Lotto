using System;



namespace Lotto

{

    class Program

    {
        public static int[] winningNumbers = new int[7];
        public static Random random = new Random();
        public static int[] lottoCoupon = new int[7];
        public static int correct = 0;

        static void Main(string[] args)

        {
            GetWinningNumbers();
            Console.WriteLine("Indtast venligst de tal du vil have på din lottokupon mellem 1-20. Du kan ikke bruge det samme tal to gange. Tryk enter mellem hvert tal.");
            GetLottoCoupon();
            GetCheckUp();
            GetWinningPrice();
        }

            public static void GetWinningNumbers()
            {
                for (int i = 0; i < winningNumbers.Length; i++)
                {
                    int randomNumber = random.Next(1, 21);
                    winningNumbers[i] = randomNumber;

                    for (int j = 0; j <= i; j++)
                    {
                        if (randomNumber == winningNumbers[j])
                        {
                            randomNumber = random.Next(1, 21);
                            j = -1;
                        }
                    }
                    winningNumbers[i] = randomNumber;
                }
            }

        public static void GetLottoCoupon()
        {
            for (int i = 0; i < lottoCoupon.Length; i++)
            {
                lottoCoupon[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(winningNumbers);
            Array.Sort(lottoCoupon);         
        }

        public static void GetCheckUp()
        { 
            for (int i = 0; i < winningNumbers.Length; i++)
            {
                for (int j = 0; j < lottoCoupon.Length; j++)
                {
                    if (winningNumbers[i] == lottoCoupon[j])
                    {
                        correct++;
                    }
                }
            }
        }
        public static void GetWinningPrice()
        {
           int winningPrice = 0;
           for (int i = 0; i < winningNumbers.Length; i++)
            {
                if (correct > 2 && correct <= 6)
                {
                    winningPrice = 1000 * correct;
                }
                else if (correct == 7)
                {
                    winningPrice = 1000000;
                }
            }
            if (correct > 2)
            {
                Console.WriteLine($"Tillykke! Du havde {correct} rigtige og har vundet {winningPrice} kr.!");
            }
            else
            {
                Console.WriteLine($"Du fik {correct} rigtig(e) og der er desværre ingen gevinst idag.");
            }

        }
    }
}