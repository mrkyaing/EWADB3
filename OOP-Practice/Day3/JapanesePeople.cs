namespace Day3
{
    public class JapanesePeople : SayHello
    {
        public override void AboutMe()
        {
            Console.WriteLine("Watashi wa genkidesu");
        }

        public override void SayGreetingMessage()
        {
            Console.WriteLine("Aete ureshī");
        }
    }
}