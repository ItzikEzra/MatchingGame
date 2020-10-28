using System;

namespace B20_Ex02_MatchingGame
{
    class DrawBoard
    {
        public static void DrawTheBoard(Board i_GameBoard)
        {
            drawTopIndexes(i_GameBoard.Boardwidth);
            drawLineSeperator(i_GameBoard.Boardwidth);

            for (int i = 0; i < i_GameBoard.Boardheight; i++)
            {
                  drawLineCells(i, i_GameBoard);
                  drawLineSeperator(i_GameBoard.Boardwidth);
             
            }
        }

        private static void drawTopIndexes(int i_SizeBoard)
        {
            Console.Write("    ");
            char upLetterIndex = 'A';
            for (int i = 0; i < i_SizeBoard; i++)
            {
                Console.Write("{0}   ", upLetterIndex++);
            }
            Console.Write(Environment.NewLine);
        }

        private static void drawLineSeperator(int i_SizeBoard)
        {
            Console.Write("  =");
            for (int i = 0; i < i_SizeBoard; i++)
            {
                Console.Write("====");
            }
            Console.Write(Environment.NewLine);
        }

        private static void drawLineCells(int i_LineIndex, Board i_GameBoard)
        {
            Console.Write(i_LineIndex + 1);
            for (int index = 0; index < i_GameBoard.Boardwidth; index++)
            {
                if (i_GameBoard.GameBoardFlag[i_LineIndex, index] != 0)
                {
                    string lineCells = string.Format("| {0} ", i_GameBoard.GameBoard[i_LineIndex, index], index);
                    Console.Write(lineCells);
                }
                else
                {
                    string lineCells = string.Format("|   " );
                    Console.Write(lineCells);
                }
            }
            Console.WriteLine("|");
        }

        public static void GenerateSigns(ref int i_HowMany , ref int[] i_SignsToFill)
        {
            Random random = new Random();
            int rnd = random.Next('a', 'a' + i_HowMany);
            if (i_HowMany != 0)

            {
                i_SignsToFill[0] = rnd;
            }
            for (int i = 1; i < i_SignsToFill.Length; i++)
            {
                rnd = random.Next('a', 'a' + i_HowMany);
                for (int j = 0; j < i; j++)
                {
                    while (i_SignsToFill[j] == rnd)
                    {
                        rnd = random.Next(97, 97 + i_HowMany);
                        j = 0;
                    }
                    i_SignsToFill[i] = rnd;
                }
            }
        }

        public static void FillTable (ref Board i_TableToFill)
        { 
            int howMany = (i_TableToFill.Boardheight * i_TableToFill.Boardwidth) / 2;
            int[] signsToFill = new int[howMany];
            int flagIfInsideTwice = 0;
            int signsArrayIndex = 0;

            GenerateSigns(ref howMany , ref signsToFill);
            for (int i = 0; i < i_TableToFill.Boardheight; i++)
            {
                for(int j = 0; j < i_TableToFill.Boardwidth; j++)
                {
                    if(flagIfInsideTwice == 2)
                    {
                        signsArrayIndex++;
                        flagIfInsideTwice = 0;
                    }

                    flagIfInsideTwice++;
                    i_TableToFill.GameBoard[i, j] = (char)signsToFill[signsArrayIndex];
                    
                }
            }

            mixTable(ref i_TableToFill);
        }

        private static void swapCell(ref char i_First, ref char i_Second)
        {

            char tempswap = i_First;
            i_First = i_Second;
            i_Second = tempswap;
        }

        private static void mixTable(ref Board i_Board)
        {
            Random random = new Random();
            int col, row;
            for (int i = 0; i < i_Board.Boardheight; i++)
            {
                for (int j = 0; j < i_Board.Boardwidth; j++)
                {
                    col = random.Next(0, i_Board.Boardheight);
                    row = random.Next(0, i_Board.Boardwidth);
                    swapCell(ref i_Board.GameBoard[i, j], ref i_Board.GameBoard[col, row]);

                }
            }
        }

    }
}