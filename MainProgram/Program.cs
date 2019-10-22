using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainProgram
{
    class Program
    {
        private static int choice;
        static void Main(string[] args)
        {
            //input settings
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;  //independent from PC culture settings

            //core 
            var inputFileName = InputFileName();
            var textFromFile = ReadTXTfile(inputFileName);

            var textAsHex = ConverToHex(textFromFile);

            PrintToFile(textAsHex);
        }

        private static void PrintToFile(StringBuilder textAsHex)
        {
            var outputToText = new StreamWriter("output (base64-to-hex_separated).txt");
            outputToText.WriteLine(textAsHex);
            outputToText.Close();

            var outputToText_Separated = new StreamWriter("output (base64-to-hex).txt");
            outputToText_Separated.WriteLine(textAsHex.ToString().Replace(" ", ""));
            outputToText_Separated.Close();
        }

        private static StringBuilder ConverToHex(string textFromFile)
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "What to convert? " +
                                  Environment.NewLine + "1-base64-to-Hex / 2-base64-to-text / 3-plain text-to-Hex");
                choice = int.Parse(Console.ReadLine());
            } while (!(choice >= 1 && choice <= 3));

            var hexAsSB = new StringBuilder();

            if (choice == 1)
            {
                var base64decoded = Convert.FromBase64String(textFromFile);

                for (int i = 0; i < base64decoded.Length; i++)
                {
                    hexAsSB.Append((base64decoded[i]).ToString("X"));  //convert char to int and then to hexadecimal sum

                    if (i < base64decoded.Length - 1)
                    {
                        hexAsSB.Append(' ');
                    }
                }
            }
            else if (choice == 2)
            {
                var textInByteToString = Convert.FromBase64String(textFromFile);

                hexAsSB.Append(Encoding.UTF8.GetString(textInByteToString));  //or change "UTF8" with "Unicode (UTF16)"
            }
            else if (choice == 3)
            {
                for (int i = 0; i < textFromFile.Length; i++)
                {
                    hexAsSB.Append(((int)textFromFile[i]).ToString("X"));  //convert char to int and then to hexadecimal sum

                    if (i < textFromFile.Length - 1)
                    {
                        hexAsSB.Append(' ');
                    }
                }
            }

            return hexAsSB;
        }

        private static string InputFileName()
        {
            string inputFileName = null;

            Console.WriteLine("Text file should be with UTF8 encoding!");
            do
            {
                Console.Write("Please enter the name of TXT file: ");
                inputFileName = Console.ReadLine();
            }
            while (inputFileName == null || inputFileName == string.Empty);

            return inputFileName;
        }

        private static string ReadTXTfile(string inputFileName)
        {
            var stream = new StreamReader(inputFileName);
            var textAsStr = stream.ReadToEnd();
            stream.Close();

            return textAsStr;
        }
    }
}
