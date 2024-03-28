public class Check
{
    public CheckId Id { get; set; }
}

public record CheckId(Guid Val);

public class Call
{
    public void Test(Guid Id)
    {
        Console.WriteLine(Id);
    }
}

public class pr
{
    public static void main()
    {
        Check ch = new Check();

        Call call = new Call();
        call.Test(ch.Id);
    }
}