using System;
using System.Collections.Generic;
namespace B20_Ex02_MatchingGame
{
    static class Logic
    {
        private static void changeFlags(ref char[] i_CellArray, ref Board i_GameBoard)
        {
            if (i_GameBoard.GameBoardFlag[i_CellArray[1], i_CellArray[0]] == 0)
            {
                i_GameBoard.GameBoardFlag[i_CellArray[1], i_CellArray[0]]++;
            }
        }

        private static void compare(ref char[] i_FirstCell, ref char[] i_SecondCell, ref Board i_GameBoard, ref Player i_Player)
        {
            char firstChar = i_GameBoard.GameBoard[i_FirstCell[1], i_FirstCell[0]];
            char secondChar = i_GameBoard.GameBoard[i_SecondCell[1], i_SecondCell[0]];
           
            while (true)
            {
                if (i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] == 2 && (i_GameBoard.GameBoardFlag[i_SecondCell[1], i_SecondCell[0]] == 1))
                {
                    i_GameBoard.GameBoardFlag[i_SecondCell[1], i_SecondCell[0]] = 0;
                    break;
                }
                if (i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] == 1 && (i_GameBoard.GameBoardFlag[i_SecondCell[1], i_SecondCell[0]] == 2))
                {
                    i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] = 0;
                    break;
                }
                if (i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] == 2 || (i_GameBoard.GameBoardFlag[i_SecondCell[1], i_SecondCell[0]] == 2))
                {
                    break;
                }
                if (i_FirstCell[0] == i_SecondCell[0] && i_FirstCell[1] == i_SecondCell[1])
                {
                    i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] = 0;
                    break;
                }
                if (firstChar == secondChar)
                {
                    i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] = 2;
                    i_GameBoard.GameBoardFlag[i_SecondCell[1], i_SecondCell[0]] = 2;
                    i_Player.score++;
                    break;

                }
                if (firstChar != secondChar)
                {
                    System.Threading.Thread.Sleep(2000);
                    i_GameBoard.GameBoardFlag[i_FirstCell[1], i_FirstCell[0]] = 0;
                    i_GameBoard.GameBoardFlag[i_SecondCell[1], i_SecondCell[0]] = 0;
                    break;
                }

            }

        }

        public static void SetEnemyType(ref Player i_Player)
        {
            int typeOfPlayerChoise;
            bool v_validInput = true;

            while (true)
            {
                GameMeseges.TypeOfPlayerChoiseMwesege();
                v_validInput = int.TryParse(Console.ReadLine(), out typeOfPlayerChoise);
                while (!v_validInput)
                {
                    GameMeseges.TypeOfPlayerChoiseMwesege();
                    v_validInput = int.TryParse(Console.ReadLine(), out typeOfPlayerChoise);
                }
                if (typeOfPlayerChoise == 1)
                {
                    i_Player = new Player();
                    break;
                }
                if (typeOfPlayerChoise == 2)
                {
                    GameMeseges.GetNameMesege();
                    string playerName2 = Console.ReadLine();
                    i_Player = new Player(playerName2);
                    break;
                }
            }
        }

        public static void SetBoardSize(ref Board i_GameBoard)
        {
            bool v_validInputHeight = true;
            bool v_validInputWidth = true;
            bool v_checkIfEquel = true;
            
            GameMeseges.InputNumbers();
            v_validInputHeight = int.TryParse(Console.ReadLine(), out int choosenHeigth);
            v_validInputWidth = int.TryParse(Console.ReadLine(), out int choosenWitdh);
            while (true)
            {
                while (!v_validInputHeight || !v_validInputWidth)
                {
                    GameMeseges.WrongInputMessege();
                    v_validInputHeight = int.TryParse(Console.ReadLine(), out choosenHeigth);
                    v_validInputWidth = int.TryParse(Console.ReadLine(), out choosenWitdh);

                }
                v_checkIfEquel = (choosenHeigth * choosenWitdh % 2 == 0);
                if (choosenHeigth >= 4 && choosenHeigth <= 6 && choosenWitdh >= 4 && choosenWitdh <= 6 && v_checkIfEquel)
                {
                    i_GameBoard = new Board(choosenHeigth, choosenWitdh);

                    break;
                }
                else
                {
                    GameMeseges.WrongSizesMessege();
                    v_validInputHeight = int.TryParse(Console.ReadLine(), out choosenHeigth);
                    v_validInputWidth = int.TryParse(Console.ReadLine(), out choosenWitdh);
                }

            }

        }

        private static char[] inputCell(ref Board i_GameBoard)
        {
            char[] location = new char[2];
            string inputFromUser = Console.ReadLine();
            while (true)
            {
                while (inputFromUser.Length != 2)
                {
                    if (inputFromUser == "Q")
                    {
                        Environment.Exit(0);
                    }
                    GameMeseges.WrongTemlateMessege();
                    inputFromUser = Console.ReadLine();
                }
                location = inputFromUser.ToCharArray();

                if (location.Length == 2 && char.IsUpper(location[0]) && char.IsDigit(location[1]))
                {

                    location[0] -= 'A';
                    location[1] -= '1';
                    if (inBorder(location, i_GameBoard))
                    {
                      if(i_GameBoard.GameBoardFlag[location[1], location[0]] == 0)
                        {
                            break;
                        }
                        else
                        {
                            GameMeseges.OpenCellMessege();
                        }
                    }
                    else
                    {
                        GameMeseges.NotInBorderMessege();
                    }
                }
                else
                {
                    GameMeseges.WrongTemlateMessege();
                }

                inputFromUser = Console.ReadLine();

            }
            return location;

        }

        private static bool inBorder(char[] i_Location, Board i_GameBoard)
        {
            return (i_Location[0] >= 0 && i_Location[0] < i_GameBoard.Boardwidth && i_Location[1] >= 0 && i_Location[1] < i_GameBoard.Boardheight);

        }

        private static void oneTurn(ref Board i_GameBoard, ref Player i_Player, ref bool v_Win, ref List<CharLocation> i_Memory)
        {
            int scoreBefore = i_Player.score;
            char[] firstChoice = new char[2];
            char[] secondChoice = new char[2];
            int[] tempLocation = new int[2];
            bool foundCouple = !true;
            
            DrawBoard.DrawTheBoard(i_GameBoard);
            GameMeseges.BeReady(i_Player.name);
            GameMeseges.QtoExitMessege();
            if (i_Player.isHuman)
            {
                firstChoice = inputCell(ref i_GameBoard);
                round(ref i_GameBoard, ref firstChoice);
                GameMeseges.QtoExitMessege();
                secondChoice = inputCell(ref i_GameBoard);
                round(ref i_GameBoard, ref secondChoice);
            }
            else
            {
                tempLocation = pcRandomMove(ref i_GameBoard, ref i_Player);
                firstChoice[0] = (char)tempLocation[0];
                firstChoice[1] = (char)tempLocation[1];
                CharLocation firstPc = new CharLocation(firstChoice, i_GameBoard.GameBoard[firstChoice[1], firstChoice[0]]);
                i_Memory.Add(firstPc);
                GameMeseges.QtoExitMessege();
                System.Threading.Thread.Sleep(2000);
                smartmove(ref i_GameBoard, ref i_Memory, ref firstPc, ref foundCouple, ref secondChoice);
                if (!foundCouple)
                {
                    tempLocation = pcRandomMove(ref i_GameBoard, ref i_Player);
                    secondChoice[0] = (char)tempLocation[0];
                    secondChoice[1] = (char)tempLocation[1];

                }
                System.Threading.Thread.Sleep(2000);
            }
            Logic.compare(ref firstChoice, ref secondChoice, ref i_GameBoard, ref i_Player);

            if (i_Player.score > scoreBefore)
            {
                v_Win = true;
            }
            else
            {
                v_Win = false;
            }
        }

        public static void TurnManager(ref Board i_GameBoard, ref Player i_PlayerOne, ref Player i_PlayerTwo, ref List<CharLocation> m_Memory)
        {
            bool v_firstPlayer = true;
            bool v_secondPlayer = true;

            while (v_firstPlayer)
            {
                oneTurn(ref i_GameBoard, ref i_PlayerOne, ref v_firstPlayer, ref m_Memory);
                Ex02.ConsoleUtils.Screen.Clear();
                GameMeseges.Printinfo(ref i_PlayerOne, ref i_PlayerTwo);
            }

            while (v_secondPlayer)
            {
                oneTurn(ref i_GameBoard, ref i_PlayerTwo, ref v_secondPlayer, ref m_Memory);
                Ex02.ConsoleUtils.Screen.Clear();
                GameMeseges.Printinfo(ref i_PlayerOne, ref i_PlayerTwo);
            }

        }

        private static void round(ref Board i_GameBoard, ref char[] i_UserInput)
        {
            changeFlags(ref i_UserInput, ref i_GameBoard);
            Ex02.ConsoleUtils.Screen.Clear();
            DrawBoard.DrawTheBoard(i_GameBoard);

        }

        private static int[] pcRandomMove(ref Board i_GameBoard, ref Player i_Player)
        {
            char[] choise = new char[2];
            int[] tempLocation = new int[2];
            Random random = new Random();
            int row, col;
            row = random.Next(0, i_GameBoard.Boardwidth);
            col = random.Next(0, i_GameBoard.Boardheight);
            tempLocation[0] = row;
            tempLocation[1] = col;
            while (i_GameBoard.GameBoardFlag[col, row] != 0)
            {
                row = random.Next(0, i_GameBoard.Boardwidth);
                col = random.Next(0, i_GameBoard.Boardheight);
                tempLocation[0] = row;
                tempLocation[1] = col;
            }
            choise[0] = (char)tempLocation[0];
            choise[1] = (char)tempLocation[1];
            round(ref i_GameBoard, ref choise);
            return tempLocation;
        }

        public static void smartmove(ref Board i_GameBoard, ref List<CharLocation> i_Memory, ref CharLocation i_FirstPc, ref bool i_FoundCouple, ref char[] i_SecondChoice)
        {
            foreach (CharLocation listArgu in i_Memory)
            {
                if (listArgu.Value == i_FirstPc.Value && listArgu.Location != i_FirstPc.Location)
                {
                    if (i_GameBoard.GameBoardFlag[listArgu.Location[1], listArgu.Location[0]] == 0)
                    {
                        i_SecondChoice = listArgu.Location;
                        i_FoundCouple = true;
                        i_Memory.Remove(listArgu);
                        break;
                    }
                }
            }
        }

    }  
}
