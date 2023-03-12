namespace Core.Penguin;

public class SpaceShipResourceException : Exception
{
    public SpaceShipResourceException() : base("You cannot take more resource from the sout")
    {
        
    }
}