using System.Windows.Forms;

namespace EMCCommon.Windows.Forms
{
    public class EMCTreeNode<T> : TreeNode
    {
        private T m_Info;

        public T Info
        {
            get { return m_Info; }
        }

        public EMCTreeNode(T nfo)
            : base(nfo.ToString())
        {
            m_Info = nfo;
        }
    }
}