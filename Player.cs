using System;

namespace B20_Ex02_MatchingGame
{
    class Player
    {
        private int m_PlayerScore;
        private readonly string r_PlayerName;
        private readonly bool b_IsHuman;

        public  Player(string i_PlayerName)
        {
            r_PlayerName = i_PlayerName;
            m_PlayerScore = 0;
            b_IsHuman = true;
        }

        public Player()
        {
            r_PlayerName = "PC Player";
            m_PlayerScore = 0;
            b_IsHuman = !true;
         
        }

        public int score
        {
            get
            {
                return m_PlayerScore;
            }
            set
            {
                m_PlayerScore = value;
            }
        }

        public string name
        {
            get
            {
                return r_PlayerName;
            }
           
        }

        public bool isHuman
        {
            get
            {
                return b_IsHuman;
            }
            
        }

    }
}
