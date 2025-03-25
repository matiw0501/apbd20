
namespace ConsoleApp1;

public class LiquidContainer : Contener, IHazardNotifier
{
    private bool _isDanger;

    public LiquidContainer(int weightOfStuff, int heigth, int weightOfBox, int boxDeepth, string typeCon, bool isDanger, int maxWeight) 
        : base(weightOfStuff, heigth, weightOfBox, boxDeepth, typeCon, maxWeight)
    {
        _isDanger = isDanger ;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine(message + " in conteiner numer: " + getSerialNumber());
    }

    public override void Load(int weightToLoad)
    {
        if (_isDanger) {
            if (getMaxWeight() * 0.5 < getWeightOfStuff() + weightToLoad)
            {
                NotifyHazard("We tried overfill");
                throw new OverfillException();
            }
            base.Load(weightToLoad);
        }
        else
        {
            if (getMaxWeight() * 0.9 < getWeightOfStuff() + weightToLoad)
            {
                NotifyHazard("We tried overfill");
                throw new OverfillException();
            }
            base.Load(weightToLoad);
        }

    }
}