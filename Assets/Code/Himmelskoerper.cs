/// <summary>
/// --------------------------------------------------------------------------------------------------------
/// Solar Simulation with UNITY and C#
/// (c) Jonathan Ramos Weigend, Johannes Weigend
/// November 2022, Blumenau Brasilien
/// --------------------------------------------------------------------------------------------------------
/// </summary>

using System.Numerics;
using System.Drawing;
using System;

public class Himmelskoerper
{ 
    public string name { get; }
    public double masse { get; }
    public double radius { get; }
    public Vector3d position { get; set; }
    public Vector3d geschwindigkeit { get; set; }
    public Color farbe { get; }

    public Himmelskoerper(string name, double masse, double radius, Vector3d position, Vector3d geschwindigkeit, Color farbe)
    {
        this.name = name;
        this.masse = masse;
        this.radius = radius;
        this.position = position;
        this.geschwindigkeit = geschwindigkeit;
        this.farbe = farbe;
    }

    public void Print()
    {
        Console.WriteLine("**** Himmelskörper ****");
        Console.WriteLine("  Name: " + name);
        Console.WriteLine("  Masse in kg: " + masse);
        Console.WriteLine("  Radius in km: " + radius);
        Console.WriteLine("  Position in km: " + position);
        Console.WriteLine("  Geschwindigkeit in km/h: " + geschwindigkeit, "\n");
        Console.WriteLine("  Farbe: " + farbe + "\n");
    }
}