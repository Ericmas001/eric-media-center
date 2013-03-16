namespace EMCMasterPluginLib
{
    public class SettingEntry
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_TypeSetting;

        public string TypeSetting
        {
            get { return m_TypeSetting; }
            set { m_TypeSetting = value; }
        }

        private string m_Value;

        public string Value2
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        public SettingEntry(string name, string type, string value)
        {
            m_Name = name;
            m_TypeSetting = type;
            m_Value = value;
        }

        public T GetValue<T>()
        {
            return default(T);
        }
    }
}