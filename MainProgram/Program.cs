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
        static void Main(string[] args)
        {
            //input settings
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;  //independent from PC culture settings

            //core 
            var inputFileName = InputFileName();
            var textFromFile = ReadTXTfile(inputFileName);

        }

        private static string InputFileName()
        {
            string inputFileName = null;

            Console.WriteLine("Text file should be with UTF8 encoding! Otherwise, change the methods DecodeFromBase64 and EncodeToBase64!");
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
    
        private static string DecodeFromBase64(string inputTextInBytes)
        {
            var textInByteToString = Convert.FromBase64String(inputTextInBytes);           
            return Encoding.UTF8.GetString(textInByteToString);         //or change "UTF8" with "Unicode (UTF16)"
        }

        private static string EncodeToBase64(string inputText)
        {
            var inputTextToBytes = Encoding.UTF8.GetBytes(inputText);  //or change "UTF8" with "Unicode (UTF16)"            
            return Convert.ToBase64String(inputTextToBytes);
        }


    }
}
