namespace Day2;
using TeacherInfo;
using StudentInfo;
class Program
{

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Hello, World!");
            Teacher.ShowInfo();
            Student.ShowInfo();
            
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
        catch (IndexOutOfRangeException e1)
        {      
            Console.WriteLine("error occur because of "+e1.Message);
        }
         catch (NullReferenceException e1)
        {      
            Console.WriteLine("error occur because of "+e1.Message);
        }
         catch (Exception e1)
        {      
            Console.WriteLine("error occur because of "+e1.Message);
        }
    }

}
