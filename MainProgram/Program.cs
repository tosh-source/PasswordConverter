using System;
using System.Collections.Generic;
using System.Globalization;
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


        }

        private static string DecodeBase64(string inputTextInBytes)
        {
            var textInByteToString = Convert.FromBase64String(inputTextInBytes);           
            return Encoding.UTF8.GetString(textInByteToString);         //or change "UTF8" with "Unicode (UTF16)"
        }

        private static string EncodeBase64(string inputText)
        {
            var inputTextToBytes = Encoding.UTF8.GetBytes(inputText);  //or change "UTF8" with "Unicode (UTF16)"            
            return Convert.ToBase64String(inputTextToBytes);
        }
    }
}
