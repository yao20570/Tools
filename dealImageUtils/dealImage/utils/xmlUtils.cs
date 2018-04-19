using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace dealImage.utils
{
    public class XmlUtils
    {
        static public XmlDocument getXmlFromFile(string fileFullName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            settings.ProhibitDtd = false;
            XmlReader reader = XmlReader.Create(fileFullName, settings);
            xmlDoc.Load(reader);

            return xmlDoc;
        }
    }
}
