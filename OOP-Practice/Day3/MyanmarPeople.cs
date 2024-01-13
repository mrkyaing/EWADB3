using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3
{
    public class MyanmarPeople : SayHello
    {
         public override void AboutMe()
        {
            Console.WriteLine("Kya naw naykaung par taw");
        }

        public override void SayGreetingMessage()
        {
            Console.WriteLine("Minga Lar par.");
        }
    }
}