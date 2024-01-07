namespace Day1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var today = DateTime.Now;
        if (today.Hour > 12)
        {
            Console.WriteLine($"Hello,Good Afternoon today is {today}");
        }
        else
        {
            Console.WriteLine($"Good morning today is {today}");
        }
        Car myCar = new Car();//create a object for car 
        myCar.Color = "RED";// . access operator to called member or behavior of class 
        myCar.Type = "TOYATA";
        myCar.Speed = 20;
        myCar.StartEngine();
        myCar.StopEngine();
        myCar.PlayHorn();
        myCar.PlayHorn(3);
        Console.WriteLine(myCar);

        Car yourCar = new Car()
        {
            Color = "BLACK",
            Type = "BMW",
            Speed = 30
        };
        yourCar.StartEngine();
        yourCar.StopEngine();
        yourCar.PlayHorn();
        Console.WriteLine(yourCar);

        Car c=new Car(10,"YELLOW","TOYATA");
        Console.WriteLine(c);
        c.PlayHorn(3);
        c.ChangeGear();
        Console.WriteLine(Computer.i);//10
        Computer.Spec();//i7

    }
}
