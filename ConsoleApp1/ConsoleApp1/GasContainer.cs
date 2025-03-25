namespace ConsoleApp1;

public class GasContainer : Contener, IHazardNotifier
{
    private int _pressure;

    public GasContainer(int weightOfStuff, int heigth, int weightOfBox, int boxDeepth, string typeCon, int maxWeight, int pressure)
        : base(weightOfStuff, heigth, weightOfBox, boxDeepth, typeCon, maxWeight)
    {
        _pressure = pressure;
    }

    public override void Empty()
    {
        Empty(5);
    }
    public override void Empty(int percent)
    {
        Empty(5);
    }
    

    public void NotifyHazard(string message)
    {
        Console.WriteLine(message + " in conteiner numer: " + getSerialNumber());
    }
}