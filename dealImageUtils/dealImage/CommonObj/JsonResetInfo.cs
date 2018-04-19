using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dealImage.CommonObj
{
    public class JsonResetInfo
    {
        public HashSet<string> dictPlists = new HashSet<string>();
        public HashSet<string> dictSingleImage = new HashSet<string>();

        public List<string> listUpdateInfo = new List<string>();

        /// <summary>
        /// plist相对路径
        /// </summary>
        /// <param name="path"></param>
        public void addPlist(string path)
        {
            dictPlists.Add(path);
        }

        public void addSingleImage(string path)
        {
            dictSingleImage.Add(path);
        }

        public void addUpdateInfo(string str)
        {
            listUpdateInfo.Add(str);
        }
    }

}
