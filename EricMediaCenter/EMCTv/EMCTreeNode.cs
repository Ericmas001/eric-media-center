using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCTv
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
