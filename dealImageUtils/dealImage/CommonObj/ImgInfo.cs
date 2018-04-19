using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dealImage.CommonObj
{
    /// <summary>
    /// 图片信息
    /// </summary>
    public class ImgInfo
    {
        private string _name;//图片名称
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value.Replace(@"\", @"/");
            }

        }

        private string _path;//图片相对路径
        public string path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value.Replace(@"\", @"/");
            }
        }
        private string _plist = null;//对应的plist文件相对路径+名称
        public string plist
        {
            get
            {
                return _plist;
            }
            set
            {
                _plist = value.Replace(@"\", @"/");
            }
        }

    }
}
