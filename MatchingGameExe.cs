using System;
using System.Collections.Generic;
namespace B20_Ex02_MatchingGame
{
    class MatchingGameExe
    {
        private static Player s_PlayerOne;
        private static Player s_PlayerTwo;
        private static Board s_gameBoard;
        private static List <CharLocation> m_Memory;

        public static void Run()
        {
            
            GameMeseges.HelloMesege();
            GameMeseges.GetNameMesege();
            string playerName = Console.ReadLine();
            s_PlayerOne = new Player(playerName);
            s_PlayerTwo = new Player();
            s_gameBoard = new Board();
            m_Memory = new List<CharLocation>();


            Logic.SetEnemyType(ref s_PlayerTwo);
            Logic.SetBoardSize(ref s_gameBoard);
            DrawBoard.FillTable(ref s_gameBoard);
         
            while (true)
            {
                Logic.TurnManager(ref s_gameBoard, ref s_PlayerOne, ref s_PlayerTwo ,ref m_Memory); 
            }
          
        }

        public static void GameOver()
        {
            int maxPoint = s_gameBoard.Boardheight * s_gameBoard.Boardwidth / 2;
            if (s_PlayerOne.score + s_PlayerTwo.score == maxPoint)
            {
                if (s_PlayerOne.score > s_PlayerTwo.score)
                {
                    GameMeseges.WinnerMessege(s_PlayerOne.name);
                }
                else if (s_PlayerOne.score == s_PlayerTwo.score)
                {
                    GameMeseges.ItsTieMessege();
                }
                else
                {
                    GameMeseges.WinnerMessege(s_PlayerTwo.name);
                }
                GameMeseges.PlayAgainMessege();
                string newGame = Console.ReadLine();
                {
                    if(newGame == "1")
                    {
                        Run();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}

