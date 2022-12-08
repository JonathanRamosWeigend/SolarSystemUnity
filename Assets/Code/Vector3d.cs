/// <summary>
/// --------------------------------------------------------------------------------------------------------
/// Solar Simulation with UNITY and C#
/// (c) Jonathan Ramos Weigend, Johannes Weigend
/// November 2022, Blumenau Brasilien
/// --------------------------------------------------------------------------------------------------------
/// </summary>
using System;

/// <summary>
/// Simple Vector of 3 doubles for double precision.
/// </summary>
public class Vector3d
{
    public double x { get; set; }
    public double y { get; set; }
    public double z { get; set; }

    public Vector3d()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

    public Vector3d(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double GetLength()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

}
