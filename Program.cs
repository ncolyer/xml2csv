using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Configuration;

namespace xml2csv
{
    class Program
    {
        static int Main(string[] args)
        {
            string xmlFile = "";
            string xslFile = "";
            string outputFile = "";
            string appPath = Path.GetDirectoryName(System.Environment.CurrentDirectory);
            string dPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // No args? No dice.
            if (args.Length != 3)
            {
                string myString = @"
-------------------------------------------------------------------------------
XML2CSV (v1.0) converts an XML document into a CSV using an XSLT Stylesheet.
 
    USAGE: xml2csv.exe [xslt template] [source] [destination]
                                
Example:
 xml2csv.exe trasform.xslt report.xml outfile.csv

-------------------------------------------------------------------------------
    ";
                Console.WriteLine(myString);
                return -1;
            }
            else
            {
                int i = 0;
                while (i <= 1)
                {
                    if (!File.Exists(args[i]))
                    {
                        if (!File.Exists(dPath + "\\" + args[i]))
                        {
                            if (!File.Exists(appPath + "\\" + args[i]))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Argument error. File: " + args[i] + " does not exists.");
                            }
                            else
                            {
                                if (i == 0)
                                    xslFile = appPath + "\\" + args[i];
                                if (i == 1)
                                    xmlFile = appPath + "\\" + args[i];
                            }

                        }
                        else
                        {
                            if (i == 0)
                                xslFile = dPath + "\\" + args[i];
                            if (i == 1)
                                xmlFile = dPath + "\\" + args[i];
                        }
                    }
                    else
                    {
                        if (i == 0)
                            xslFile = args[i];
                        if (i == 1)
                            xmlFile = args[i];
                    }
                    i++;
                }

                outputFile = args[2];
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();                    //Create a new XML document and load the XML file
                XslCompiledTransform xslTran = new XslCompiledTransform(); //Create an XSLT object and load the XSLT file           

                xmlDoc.Load(xmlFile);
                xslTran.Load(xslFile);

                // This is for generating the output
                XmlTextWriter writer = new XmlTextWriter(outputFile, System.Text.Encoding.ASCII);
                xslTran.Transform(xmlDoc, null, writer);
                writer.Close();
                Console.WriteLine("");
                Console.WriteLine("Successfully exported.");
                
                return 1;
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("An error occurred. Please make sure that the file output is not currently locked by another process such as excel.");
                return -1;
            }
        }
    }
}