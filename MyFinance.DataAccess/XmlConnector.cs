using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace MyFinance.DataAccess
{
    public class XmlConnector
    {
        private string _path;

        public XmlConnector(string path)
        {
            _path = path;
        }

        public void SaveToXmlFile(string xmlString)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlString);
            xdoc.Save(_path);
        }

        public static T XmlStringToObject<T>(string xmlString) where T : class
        {
            using (StringReader stringReader = new StringReader(xmlString))
            {
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(stringReader) as T;
            }
        }

        public static string ObjectToSmlString<T>(T item) where T : class
        {
            using (StringWriter stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(item.GetType());
                serializer.Serialize(stringwriter, item);
                return stringwriter.ToString();
            }
        }
    }
}
