namespace Company.Money;

public class CannotTravelException : Exception
{
    public CannotTravelException() : base("Not enough money to travel")
    {
        
    }
}