public class Animal{
    private string name;
    public string Name{
        get{return name;}
        set{name=value;}
    }
    private string type;
    public string Type{
        get{return type;}
        set{type=value;}
    }
    private decimal lifeSpan;
    public decimal LifeSpan{
        get{return lifeSpan;}
        set{lifeSpan=value;}
    }
   public virtual void Eat()=>Console.WriteLine($"{name} is eating.");
   public virtual void Speak()=>Console.WriteLine($"{name} is speak.");
}