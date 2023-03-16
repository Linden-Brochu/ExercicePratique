namespace Core.System;

internal class ResourceFactory
{
    public Queue<Resource> Generate(int quantityOfResource)
    {
        var resources = new Queue<Resource>();

        for (var i = 0; i < quantityOfResource; i++)
        {
            resources.Enqueue(new Resource
            {
                Name = "Piment jalapeno super spicy 2000 pro gamer rgb 360 no scope 'I fucked your mom yesterday'",
                SpaceTaken = quantityOfResource - i,
            });
        }
        
        return resources;
    }
}