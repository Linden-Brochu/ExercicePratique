namespace Company.Money;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException() : base("Not enough money")
    {
        
    }
}