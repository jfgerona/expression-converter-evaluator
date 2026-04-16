using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create and instantiate all List
            List<string> InFix = new List<string>();
            List<string> PreFix = new List<string>();
            List<string> PostFix = new List<string>();
            List<string> PreFixEvaluated = new List<string>();
            List<string> PostFixEvaluated = new List<string>();
            List<string> Comparison = new List<string>();

            //De-serialize CSV input to C# List named InFix
            InFix = CSVFile.CSVDeserialize("Project 2_INFO_5101.csv");

            //Convert Infix expressions stored in the InFix list to prefix
            //expressions and save them in a generic list named PreFix
            PreFix = InfixToPrefix.infix2Prefix(InFix);

            //Convert Infix expressions stored in the InFix list to postfix
            //expressions and save them in a generic list named PostFix
            PostFix = InfixToPostfix.infix2Postfix(InFix);

            //Evaluate each expression in the PreFix list using Expression Tree
            PreFix.ForEach(str => PreFixEvaluated.Add(ExpressionEvaluation.evaluatePrefix(str).ToString()));

            //Evaluate each expression in the PostFix list using Expression Tree.
            PostFix.ForEach(str => PostFixEvaluated.Add(ExpressionEvaluation.evaluatePostfix(str).ToString()));

            //Use the IComparer interface to compare the results from Prefix and Postfix evaluation
            for (int i = 0; i < PreFix.Count; i++)
            {
                Comparison.Add(new CompareExpressions().Compare(PostFixEvaluated[i], PreFixEvaluated[i]) == 0 ? "True" : "False");
            }

            //output the result
            Console.WriteLine("=====================================================================================================");
            Console.WriteLine("*                                        Summary Report                                             *");
            Console.WriteLine("=====================================================================================================\n");
            Console.WriteLine("|{0,4}|{1,20}|{2,20}|{3,20}|{4,10}|{5,10}|{6,10}", "Sno", "InFix", "PostFix", "PreFix", "Prefix Res", "PostFix Res", "Match");
            Console.WriteLine("=====================================================================================================");
            
            for (int i = 0; i < InFix.Count; i++)
            {
                Console.WriteLine("|{0,4}|{1,20}|{2,20}|{3,20}|{4,10}|{5,10}|{6,10}", i+1, InFix[i],PostFix[i],PreFix[i],PreFixEvaluated[i],PostFixEvaluated[i], Comparison[i]);
            }
            Console.WriteLine("\n=====================================================================================================");

            //Generate an XML file using extension methods by extending StreamWriter
            Console.Write("Please enter a file name to generate the XML file (e.g. project.xml): ");
            string file = Console.ReadLine();
            try
            {
                var output = File.CreateText(@"..\..\..\Data\" + file);
                output.WriteStartDocument();
                output.WriteStartRootElement();
                for (int i = 0; i < InFix.Count; i++)
                {
                    output.WriteStartElement();
                    output.WriteAttribute("sno", (i + 1).ToString());
                    output.WriteAttribute("infix", InFix[i]);
                    output.WriteAttribute("prefix", PreFix[i]);
                    output.WriteAttribute("postfix", PostFix[i]);
                    output.WriteAttribute("evalutaion", PreFixEvaluated[i]);
                    output.WriteAttribute("comparison", Comparison[i]);
                    output.WriteEndElement();
                }
                output.WriteEndRootElement();

                //prompt the user to upload the required XML file and bring it up on any web browser
                Console.Write("Press any key to generate and upload the xml file and view it on a web browser: ");
                Console.ReadKey();
                output.Flush();
                //view the file on web browser
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = @"..\..\..\Data\" + file,
                    UseShellExecute = true
                });

                //prompt the use to quit the application
                Console.WriteLine("Press any key to quit:");
                output.Close();

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}
