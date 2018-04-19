using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace dealImage.utils
{
    public class LogUtils
    {
        public delegate void delegateWriteLog(string strLog);
        static public delegateWriteLog onWriteLog;

        static public void WriteLine(string format, params object[] obj)
        {
            try
            {
                string str = string.Format(format, obj);
                if (onWriteLog != null)
                {
                    onWriteLog(str + "\n");
                }

                Console.WriteLine(str);
            }
            catch(Exception e)
            {

            }
        }
    }
}
