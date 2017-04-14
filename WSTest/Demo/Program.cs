using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"C:\Users\HopTech\Documents\Visual Studio 2015\Projects\WSTest\Demo\data.xml");
            XmlElement root = xdoc.DocumentElement;
            
            //string ns = root.ChildNodes[1].NamespaceURI;


            XmlNamespaceManager nsmg = new XmlNamespaceManager(xdoc.NameTable);
            nsmg.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
            //var result = root.ChildNodes[1].SelectSingleNode("NewDataSet");
            //Console.WriteLine(result.ChildNodes[0].SelectSingleNode("TotalCar").InnerText);

            Console.WriteLine(xdoc.SelectSingleNode("",nsmg)==null);
            Console.ReadKey();
           
        }
    }
}
