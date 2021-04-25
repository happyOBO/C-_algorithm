using System;
using System.Collections.Generic;

namespace CSharp
{



    class Program
    {


        delegate int OnClicked();
        // 함수가 아니라 형식인데
        // 함수 자체를 인자로 넘겨주는 그런 형식
        // 반환은 int 입력은 : void

        static int TestDelegate()
        {
            Console.WriteLine("hello dele");
            return 0;
        }


        static int TestDelegate2()
        {
            Console.WriteLine("hello dele2");
            return 0;
        }

        static void Main(string[] args)
        {
            OnClicked clicked = new OnClicked(TestDelegate);
            clicked += TestDelegate2;

            clicked();
        }
    }
}
