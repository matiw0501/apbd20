using System.ComponentModel;

namespace ConsoleApp1;

public class CoolingContainer : Contener
{
    private String _rodzaj;
    private double _temperature;
    private static  Dictionary<String, double> instructions =new() {
        {"Bananas", 13.3}, {"Chocolate", 18}, {"Fish", 2}, {"Meat", -15}, {"Ice cream", -18},
        {"Frozen pizza", -30}, {"Cheese", 7.2}, {"Sausages", 5}, {"Butter", 20.5}, {"Eggs", 19}
    };


    public CoolingContainer(int weightOfStuff, int heigth, int weightOfBox, int boxDeepth, string typeCon, int maxWeight, string rodzaj, double temperature) : base(weightOfStuff, heigth, weightOfBox, boxDeepth, typeCon, maxWeight)
    {
        _rodzaj = rodzaj;
        if (temperature<instructions[_rodzaj])
        {
            Console.WriteLine("Temperatura nieprawidłowa. Podaj mi temperature wiekszą niż " + temperature + ".");
            _temperature = double.Parse(Console.ReadLine());
        }
        else
        {
            _temperature = temperature;
        }
    }
}