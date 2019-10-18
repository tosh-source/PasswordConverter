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
            Console.OutputEncoding = Encoding.UTF8;

            //core 
            

        }

        private static void DecodeBase64(String inputText)
        {
            throw new NotImplementedException();
        }

        private static void EncodeBase64()
        {
            throw new NotImplementedException();
        }
    }
}
