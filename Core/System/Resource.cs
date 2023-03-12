namespace Core.System;

public struct Resource
{
    public const double WeightPerResource = 10d;
    
    public readonly string Name { get; init; }
    
    public readonly double SpaceTaken { get; init; }
}