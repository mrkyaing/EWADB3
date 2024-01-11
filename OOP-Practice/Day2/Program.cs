namespace Day2;
using TeacherInfo;
using StudentInfo;
using System.Diagnostics;

class Program
{

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Hello, World!");
            Teacher.ShowInfo();
            Student.ShowInfo();
            int line1 = 1;
            int line2 = int.Parse("Test");
            Student s=new Student();
            s.Name="Su Su";
            s.SetAge(21);
            Console.WriteLine(s);
            
            Student s2=new Student();
            s2.Name="Mg Mg";
            s2.SetAge(30);
            Console.WriteLine(s2);

            Student s3=new Student();
            s3.Name="Min Min";
            s3.SetAge(20);
            s3.Email="minmin@gmail.com";
            Console.WriteLine(s3);
            
            Cat myCat=new Cat();
            myCat.Name="Shwe Wha";
            myCat.Type="HomePet";
            myCat.LifeSpan=1.3m;
            myCat.Eat();
            myCat.Speak();

            Dog myDog=new Dog(){
            Name="Jame",
            Type="HomePet",
            LifeSpan=3.1m
            };
            myDog.Eat();
            myCat.Speak();

        }
        
         catch (Exception ex)
        {      
        var st = new StackTrace(ex, true);
        var frame = st.GetFrame(st.FrameCount - 1);
        var linenumber = frame.GetFileLineNumber();
        Console.WriteLine("error occur because of "+ex.Message);
        Console.WriteLine(linenumber);
        }
    }
}
