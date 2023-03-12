namespace Company.Money;

public class Account
{
    private double _money;

    public double Money
    {
        get => _money;
        internal set => _money = value;
    }
}