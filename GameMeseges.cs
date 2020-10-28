using System;

namespace B20_Ex02_MatchingGame
{
     static class GameMeseges
    {
        public static void HelloMesege()
        {
            Console.WriteLine("Hello, welcome to Matching-Game");
        }

        public static void BeReady(string i_Name)
        {
            Console.WriteLine("be ready {0} its your turn", i_Name);
        }

        public static void QtoExitMessege()
        {
            Console.WriteLine("Choose cell you want to expuse or Q to exit");
        }

        public static void SameCellMessage()
        {
            Console.WriteLine("you cant choose the same cell");
        }

        public static void NotInBorderMessege()
        {
            Console.WriteLine("Wrong input! out of border cell ");

        }

        public static void OpenCellMessege()
        {
            Console.WriteLine("Wrong input!  you cant choose an open cell");

        }       

        public static void WrongInputMessege()
        {
         
            Console.WriteLine("Wrong input! type again");
        }

        public static void WrongTemlateMessege()
        {
            Console.WriteLine("Wrong input! you must to choose big letter and a number (A1 for exmple)");
        }

        public static void WinnerMessege( string i_Name)
        {
            Console.WriteLine("The winner is: {0}" , i_Name);
        }

        public static void ItsTieMessege()
        {
            Console.WriteLine("it's a tie");
        }
                        
        public static void InputNumbers()
        {
            string inputNumbersMessege = string.Format(
@"Choose height and width. The numbers need to be between 4 to 6 and the cell amount need to be equal");
            Console.WriteLine(inputNumbersMessege);
        }

        public static void GetNameMesege()
        {
            Console.WriteLine("Please enter name below:");
        }

        public static void TypeOfPlayerChoiseMwesege()
        {
            string typeOfPlayerChoiseMwesege = string.Format(
@"Please choose number of players:
1 = One Player , Play against the PC.
2 = Two Players , Play against a friend.");

            Console.WriteLine(typeOfPlayerChoiseMwesege);
        }

        public static void WrongSizesMessege()
        {
            Console.WriteLine("Wrong sizes. Please type again");
        }

        public static void PlayAgainMessege()
        {
            Console.WriteLine("if you want to play again press 1");
        }

        public static void Printinfo(ref Player i_PlayerOne, ref Player i_PlayerTwo)
        {
            Console.WriteLine("{0}'s score is:{1}", i_PlayerOne.name, i_PlayerOne.score);
            Console.WriteLine("{0}'s score is:{1}", i_PlayerTwo.name, i_PlayerTwo.score);
            MatchingGameExe.GameOver();
        }

    }
}