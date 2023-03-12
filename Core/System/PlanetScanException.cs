namespace Core.System;

public class PlanetScanException : Exception
{
    public PlanetScanException() : base("This planet is already scanned")
    {
        
    }
}