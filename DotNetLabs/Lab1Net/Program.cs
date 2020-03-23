using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Net
{
    public class Program
    {
        public static void Main()
        {
            InfoDisplay infoDisplay = new InfoDisplay();
            Info info = new Info();

            Info.InfoDelegate del = new Info.InfoDelegate(infoDisplay.InfoChanged);
            info.InfoChanged += del;

            info.SetInfo = "changed";

            info.InfoChanged -= del;
        }
    }
}
