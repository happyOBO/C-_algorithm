using System;
using System.Collections.Generic;

namespace CSharp
{
    abstract class Monster
    {
        public abstract void Shout();
    }

    class Orc : Monster
    {
        public override void Shout()
        {
            Console.WriteLine("록타르 오가르");
        }
    }

    abstract class Flyable
    {
        public abstract void Fly();
    }

    class Skeleton : Monster
    {
        public override void Shout()
        {
            Console.WriteLine("끄에엑");
        }

    }


    class Program
    {



        static void Main(string[] args)
        {
            Monster m1 = new Monster(); // 에러!
            Skeleton s1 = new Skeleton(); // 통과
        }
    }
}
