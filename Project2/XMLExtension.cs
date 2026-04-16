using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class XMLExtension
    {
        //WriteStartDocument: This method should include xml version and encoding
        public static void WriteStartDocument(this StreamWriter a)
        {
             a.WriteLine( "<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        }
        //WriteStartRootElement: This method should add the root tag to the file
        public static void WriteStartRootElement(this StreamWriter a)
        {
            a.WriteLine("<root>");
        }
        //WriteEndRootElement: This method should end the root tag.
        public static void WriteEndRootElement(this StreamWriter a)
        {
            a.WriteLine("</root>");
        }
        //WriteStartElement: This method should add the element tag to the file
        public static void WriteStartElement(this StreamWriter a)
        {
            a.WriteLine("\t<element>");
        }
        //WriteEndElement: This method should end the element tag
        public static void WriteEndElement(this StreamWriter a)
        {
            a.WriteLine("\t</element>");
        }
        //WriteAttribute: This method should add each attribute with its values.
        public static void WriteAttribute(this StreamWriter a, string att, string val)
        {
            a.WriteLine("\t\t<" + att +">" + val + "</" + att + ">");
        }

    }
}
