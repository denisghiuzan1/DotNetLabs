using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Net
{
    public class Info
    {
        // delegate pentru eveniment
        public delegate void InfoDelegate(object obj);

        // event ce foloseste delegate InfoDelegate
        public event InfoDelegate InfoChanged;

        // data membru
        object _obiect;

        public object SetInfo
        {
            set
            {
                _obiect = value;

                InfoChanged(_obiect);
            }
        }
    }
}
