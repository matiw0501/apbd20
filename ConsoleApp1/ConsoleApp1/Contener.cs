namespace ConsoleApp1;

public abstract class Contener
{
    
    private int _weightOfStuff;
    private int _heigth;
    private int _weightOfBox;
    private int _boxDeepth;
    private String _serialNumber;
    static int _counter = 0;
    private int _maxWeight;

    public Contener(int weightOfStuff, int heigth, int weightOfBox, int boxDeepth, String typeCon, int maxWeight)
    {
        _weightOfStuff = weightOfStuff;
        _heigth = heigth;
        _weightOfBox = weightOfBox;
        _boxDeepth = boxDeepth;
        _serialNumber = "Kon-" + typeCon + _counter;
        _counter++;
        _maxWeight = maxWeight;
    }

    public void Empty()
    {
        _weightOfStuff = 0;
    }

    public void Load(int weightToLoad)
    {
        if (_maxWeight < _weightOfStuff + weightToLoad)
            throw new OverfillException();
        
        _weightOfStuff += weightToLoad;
    }


}