namespace Core.System;

public class ResourceHarvestingException : Exception
{
    public ResourceHarvestingException() : base("This planet does have resource")
    {
        
    }
}