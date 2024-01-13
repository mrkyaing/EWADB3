namespace Day3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        JapanesePeople jp = new JapanesePeople()
        {
            Name = "jame",
            Address = "Tokyo"
        };
        jp.SayGreetingMessage();
        jp.AboutMe();
        Console.WriteLine(jp);

        MyanmarPeople mp = new MyanmarPeople()
        {
            Name = "Mg mg",
            Address = "YGN"
        };
        mp.SayGreetingMessage();
        mp.AboutMe();
        Console.WriteLine(mp);
        
        EnglishPeople ep = new EnglishPeople()
        {
            Name = "Mr Jone",
            Address = "USA"
        };
        ep.SayGreetingMessage();
        ep.AboutMe();
        Console.WriteLine(ep);
    }
}
