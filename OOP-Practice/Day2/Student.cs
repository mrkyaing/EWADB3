namespace StudentInfo
{
    public class Student
    {
        public string Name;
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("invalid email format");
                }
                email = value;
            }
        }
        private int age;
        public static void ShowInfo()
        {
            int i = 10;
            Console.WriteLine("i am a student comming from student info namespace");
        }
        public override string ToString() => $"Student Information \n Name:{Name} \n Age:{age} \n email:{email}";
        public void SetAge(int age)
        {
            if (age < 0)
            {
                throw new Exception("invalid age");
            }
            else
            {
                this.age = age;
            }
        }
    }//end of class 

}