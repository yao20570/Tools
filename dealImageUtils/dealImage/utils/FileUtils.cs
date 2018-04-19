using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dealImage.utils
{
    /// <summary>
    /// 处理文件
    /// </summary>
    /// <param name="file">文件信息</param>
    public delegate void delegateDealFile(FileInfo file);
    
    public class FileUtils
    {
        /// <summary>
        /// 不遍历的文件夹
        /// </summary>
        static private HashSet<string> noTraverseFolderDict = new HashSet<string>();

        /// <summary>
        /// 遍历文件夹
        /// </summary>
        /// <param name="path">遍历的根目录</param>
        /// <param name="callback">遍历到文件时回调函数</param>
        static public void TraverseFolders(string path, delegateDealFile callback)
        {
            DirectoryInfo folder = new DirectoryInfo(path);

            //隐藏的文件夹，掠过
            if ((folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {   
                return;
            }

            //忽略的文件夹
            if (noTraverseFolderDict.Contains(folder.Name) == true)
            {
                LogUtils.WriteLine("不需要遍历的文件夹=====>{0}", folder.Name);
                return;
            }

            //遍历文件
            foreach (FileInfo file in folder.GetFiles())
            {
                callback(file);
            }

            //递归遍历文件夹
            foreach (DirectoryInfo subFolder in folder.GetDirectories())
            {
                TraverseFolders(subFolder.FullName, callback);                
            }
        }

        /// <summary>
        /// 添加不遍历的文件夹
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        static public void addNoTraverseFolder(string folderName)
        {
            noTraverseFolderDict.Add(folderName);
        }

        static public void copyFile(string srcFileFullName, string destFileFullName, bool isOverWrite)
        {
            if (File.Exists(srcFileFullName) == false)
            {
                LogUtils.WriteLine("拷贝源文件不存在:{0}", srcFileFullName);
            }

            string destFolderPath = destFileFullName.Substring(0, destFileFullName.LastIndexOfAny((@"\/").ToCharArray()) + 1);
            if (Directory.Exists(destFolderPath) == false)
            {
                Directory.CreateDirectory(destFolderPath);
            }

            File.Copy(srcFileFullName, destFileFullName, true);
        }
    }
}
