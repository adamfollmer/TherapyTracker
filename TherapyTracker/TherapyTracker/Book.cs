using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace TherapyTracker
{
    public class Book
    {
        string title;
        public Book (string Title)
        {
            title = Title;
        }

        public void Test()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<item><name>wrench</name></item>");

            XmlElement newElem = doc.CreateElement("price");
            newElem.InnerText = "10.95";
            doc.DocumentElement.AppendChild(newElem);

            XmlTextWriter writer = new XmlTextWriter(@"C:\PrintLog\data.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
        }

    }
}
