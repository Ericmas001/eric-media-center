namespace EMCCommon.Entities
{
    public class ListedLink
    {
        private string m_Name;
        private string m_Title;
        private string m_Website;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Website
        {
            get { return m_Website; }
            set { m_Website = value; }
        }

        public override string ToString()
        {
            return m_Title;
        }
    }
}