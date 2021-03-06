﻿namespace EMCMovie.Entities
{
    public class ListedMovie
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_Title;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public override string ToString()
        {
            return m_Title;
        }
    }
}