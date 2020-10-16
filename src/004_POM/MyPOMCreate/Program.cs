using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace MyPOMCreate
{
    class Program
    {
        const string path = @"E:\code\java\datacenter\src\main\webapp\WEB-INF\lib";
        static void Main(string[] args)
        {
            

            CreateXML(path);

            Console.WriteLine("Hello World!");
        }


        public static void CreateXML(string path)
        {

            DirectoryInfo folder = new DirectoryInfo(path);

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);

            XmlElement root = doc.CreateElement("dependencies");
                       

            foreach (FileInfo file in folder.GetFiles("*.jar"))
            {
                if (!file.Name.Contains("chemaxon"))
                {
                    continue;
                }

                XmlElement dependency = CreateNode(doc,file);
                root.AppendChild(dependency);
            }
            doc.AppendChild(root);

            string xmlString = doc.OuterXml;
            doc.Save(@"c:\aa.xml");
        }


        public static XmlElement CreateNode(XmlDocument doc, FileInfo file)
        {
            XmlElement dependency = doc.CreateElement("dependency");
            

            XmlElement groupId = doc.CreateElement("groupId");
            groupId.InnerText = "com.chemaxon";
            dependency.AppendChild(groupId);

            XmlElement artifactId = doc.CreateElement("artifactId");
            artifactId.InnerText = file.Name.Replace(".jar","").Replace("com.chemaxon-","");
            dependency.AppendChild(artifactId);

            XmlElement version = doc.CreateElement("version");
            version.InnerText = "1.0.0";
            dependency.AppendChild(version);

            XmlElement scope = doc.CreateElement("scope");
            scope.InnerText = "system";
            dependency.AppendChild(scope);

            XmlElement systemPath = doc.CreateElement("systemPath");
            systemPath.InnerText = "${pom.basedir}/src/main/webapp/WEB-INF/lib/" + file.Name;
            dependency.AppendChild(systemPath);

            return dependency;
        }
    }
}
