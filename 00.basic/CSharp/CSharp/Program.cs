using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSharp
{



    class Program
    {


        static int Find()
        {


            return 0;
        }
        static void Main(string[] args)
        {

            int? number = null;
            number = 3;
            //int a = number; // 오류 발생
            //int a = number.Value;

            //number = null;
            //int a = number.Value; // 컴파일 후 오류 발생


            if(number != null)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }

            if(number.HasValue)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }
        }
    }
}
