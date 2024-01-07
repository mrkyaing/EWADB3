public class Car
{
    //state or member
    public int Speed;
    public string Color;
    public string Type;

    public Car(){

    }
    public Car(int speed,string color,string type){
        Speed=speed;
        Color=color;
        Type=type;
    }
    //behavior
    public void StartEngine()
    {
        Console.WriteLine("car engine is started.");
    }
    private void ChangePinion(){
        Console.WriteLine("car engine pinion change.");
    }
    public void ChangeGear(){
        ChangePinion();
        Console.WriteLine("gear no change ");
    }
    public void StopEngine()
    {
        Console.WriteLine("car engine is stopped.");
    }
    public void PlayHorn()
    {
        Console.WriteLine("T");
    }
    public void PlayHorn(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine("T");
            Console.Beep();
        }
    }
    public override string ToString()
    {
        return $"[Car Infromation>>Color:{Color},Type:{Type},Speed:{Speed}]";
    }
}