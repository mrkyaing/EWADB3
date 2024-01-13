public abstract class SayHello{
public string Name { get; set; }
public string? Address { get; set; }
public abstract void SayGreetingMessage();
public abstract void AboutMe();
public override string ToString()=>$"[Name:{Name},Address:{Address}]";
}