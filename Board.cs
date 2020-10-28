using System;

namespace B20_Ex02_MatchingGame
{
    class Board
    {
        private char[,] m_GameBoard;
        private int[,] m_GameBoardFlag;
        private readonly int m_Boardheight;
        private readonly int m_Boardwidth;
        
        public Board(int i_Boardheight, int i_Boardwidth)
        {
            m_Boardheight = i_Boardheight;
            m_Boardwidth = i_Boardwidth;
            m_GameBoard = new char[i_Boardheight, i_Boardwidth];
            m_GameBoardFlag = new int[i_Boardheight, i_Boardwidth];
        }

        public Board()
        {
            m_Boardwidth = 0;
            m_Boardheight = 0;
            m_GameBoard = new char[0, 0];
            m_GameBoardFlag = new int[0, 0];
        }

        public char[,] GameBoard
        {
            get
            {
                return m_GameBoard;
            }
            set
            {
                m_GameBoard = value;
            }
        }

        public int[,] GameBoardFlag
        {
            get
            {
                return m_GameBoardFlag;
            }
            set
            {
                m_GameBoardFlag = value;
            }
        }

        public int Boardwidth
        {
            get
            {
                return m_Boardwidth;
            }
        }

        public int Boardheight
        {
            get
            {
                return m_Boardheight;
            }
        }
    }
}