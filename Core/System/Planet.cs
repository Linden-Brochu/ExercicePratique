namespace Core.System;

public class Planet
{
    private static readonly ResourceFactory ResourceFactory = new();
    
    private string _name;

    public string Name
    {
        get => _name;
        init => _name = value;
    }

    private bool _isScan;
    
    public bool IsScan => _isScan;

    private Queue<Resource> _resources;

    public bool HasResources => _resources.Any();

    public Planet()
    {
        _isScan = false;
        _name = "";
        _resources = new Queue<Resource>();
    }

    internal Planet(Queue<Resource> resources) : this()
    {
        _resources = resources;
    }

    public void Scan()
    {
        if (_isScan)
        {
            throw new PlanetScanException();
        }

        _isScan = true;
        _resources = ResourceFactory.Generate(100);
    }

    public Resource Harvest()
    {
        if (!_resources.Any())
        {
            throw new ResourceHarvestingException();
        }

        return _resources.Dequeue();
    }
}