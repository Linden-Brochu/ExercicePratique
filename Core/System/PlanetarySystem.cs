namespace Core.System;

public class PlanetarySystem
{
    private readonly Dictionary<Planet, double> _planets;

    public double this[Planet p]
    {
        get => _planets[p];
        set
        {
            if (_planets.ContainsKey(p))
            {
                _planets[p] = value;
            }
            else
            {
                _planets.Add(p, value);
            }
        }
    }

    public PlanetarySystem()
    {
        _planets = new Dictionary<Planet, double>();
    }
}