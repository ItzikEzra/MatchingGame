using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02_MatchingGame
{
    class CharLocation
    {
        private char[] m_Location;
        private char m_Value;

        public CharLocation(char[] i_Location, char i_Value)
        {
            m_Location = i_Location;
            m_Value = i_Value;

        }

        public char Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

        public char[] Location
        {
            get
            {
                return m_Location;
            }
            set
            {
                m_Location = value;
            }
        }
    }
}
