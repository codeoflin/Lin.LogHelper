using System;
using System.Drawing;

namespace Lin.LogHelper
{
    internal class Test
    {
        /// <summary>
        /// 
        /// </summary>
        public void main()
        {
            try
            {
                string str = null;
                var len = str.Length;
            }
            catch (Exception err)
            {
                err.LogForError();
            }

        }
    }
}
