using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    public abstract class FormEvent
    {
        public abstract void triggerEvent(object sender, MyEventArgs e, string eventName);
    }

    public class MyEventArgs : EventArgs
    {
        private object[] paras;
        public object[] Paras
        {
            get { return paras; }
            set { paras = value; }
        }
    }
}
