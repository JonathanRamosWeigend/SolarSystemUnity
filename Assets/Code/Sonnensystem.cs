/// <summary>
/// --------------------------------------------------------------------------------------------------------
/// Solar Simulation with UNITY and C#
/// (c) Jonathan Ramos Weigend, Johannes Weigend
/// November 2022, Blumenau Brasilien
/// --------------------------------------------------------------------------------------------------------
/// </summary>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;


public class Sonnensystem
{
    private List<Himmelskoerper> himmelkoerper = new List<Himmelskoerper>();

    public Sonnensystem() 
    {
        himmelkoerper.Add(new Himmelskoerper("Sonne", 
            1.989 * Math.Pow(10, 30), 
            1391000 / 2, 
            new Vector3d(0.0f * Math.Pow(10, 6), 0, 0), 
            new Vector3d(0, 0, 0), 
            Color.Yellow
            ));

        himmelkoerper.Add(new Himmelskoerper("Merkur",
            3.3 * Math.Pow(10, 23),
            4878 / 2,
            new Vector3d(58 * Math.Pow(10, 6), 0, 0),
            new Vector3d(0, 172332, 0),
            Color.LightGray
            ));

        himmelkoerper.Add(new Himmelskoerper("Venus",
            4.9 * Math.Pow(10,24),
            12103 / 2,
            new Vector3d(108 * Math.Pow(10, 6), 0, 0),
            new Vector3d(0, 126072, 0),
            Color.OrangeRed
            ));

        himmelkoerper.Add(new Himmelskoerper("Erde",
            6.0 * Math.Pow(10,24),
            12756.28 / 2,
            new Vector3d(149 * Math.Pow(10,6), 0, 0),
            new Vector3d(0, 107208, 0),
            Color.SkyBlue
            ));

        himmelkoerper.Add(new Himmelskoerper("Mars",
            6.4 * Math.Pow(10, 23),
            6794 / 2,
            new Vector3d(228 * Math.Pow(10, 6), 0, 0),
            new Vector3d(0, 86868, 0),
            Color.DarkRed
            ));

        himmelkoerper.Add(new Himmelskoerper("Jupiter",
            1.9 * Math.Pow(10, 27),
            142984 / 2,
            new Vector3d(778 * Math.Pow(10, 6), 0, 0),
            new Vector3d(0, 47052, 0),
            Color.Beige
            ));

        himmelkoerper.Add(new Himmelskoerper("Saturn",
            5.7 * Math.Pow(10,26),
            120536 / 2,
            new Vector3d(1427 * Math.Pow(10,6), 0, 0),
            new Vector3d(0, 34884, 0),
            Color.LightGray
            ));


        himmelkoerper.Add(new Himmelskoerper("Uranus",
            8.7 * Math.Pow(10, 25),
            51118 / 2,
            new Vector3d(2871 * Math.Pow(10,6), 0, 0),
            new Vector3d(0, 24516, 0),
            Color.LightSkyBlue
            ));

        himmelkoerper.Add(new Himmelskoerper("Neptun",
            1.02 * Math.Pow(10, 26),
            49532 / 2,
            new Vector3d(4498 * Math.Pow(10,6), 0, 0),
            new Vector3d(0, 19548, 0),
            Color.DeepSkyBlue
            ));

        himmelkoerper.Add(new Himmelskoerper("Pluto",
            1.3 * Math.Pow(10, 22),
            5906 / 2,
            new Vector3d(5906 * Math.Pow(10, 6), 0, 0),
            new Vector3d(0, 16812, 0),
            Color.White
            )); 
    }

    public double GetTotalSize()
    {
        return 15.0 * Math.Pow(10, 9);
    }

    public List<Himmelskoerper> GetHimmelskoerper()
    {
        return himmelkoerper;
    }

    private double G = 6.67430 * Math.Pow(10, -11);

    public void Tick()
    {
        foreach (var h1 in himmelkoerper)
        {
            foreach (var h2 in himmelkoerper)
            {
                if (h1 == h2) continue;
                double r = new Vector3d(
                    h1.position.x - h2.position.x, 
                    h1.position.y - h2.position.y,
                    h1.position.z - h2.position.z).GetLength();

                if (r < (h1.radius * 2 + h2.radius * 2)) continue; // colision

                // Berechne Kraft nach Newton F1, F2 -Radius in km
                double F = (G * h1.masse * h2.masse / (r * 1000 * r * 1000));

                // Berechne neue Geschwindigkeit des jeweils anderen Körpers
                double a = F / h2.masse; // -- m / s ^ 2

                double dv = a * 3600 * 3.6; // -- v = a * t(3600s) in km / h(*3, 6)

                // Berechne Richtungsvektor als Einheitsvektor
                Vector3d v0r = new Vector3d(
                    (1 / r * (h1.position.x - h2.position.x)),
                    (1 / r * (h1.position.y - h2.position.y)),
                    (1 / r * (h1.position.z - h2.position.z))
                    );

                // Multipliziere die Geschwindigkeiten in den Einheitsvektor
                h2.geschwindigkeit = new Vector3d(
                    (h2.geschwindigkeit.x + v0r.x * dv),
                    (h2.geschwindigkeit.y + v0r.y * dv),
                    (h2.geschwindigkeit.z + v0r.z * dv)
                    );
            }
        }
        foreach (var h in himmelkoerper)
        {
            double sx = h.geschwindigkeit.x; // -- == km / h * 1h
            double sy = h.geschwindigkeit.y;
            double sz = h.geschwindigkeit.z;

            double posx = h.position.x;
            double posy = h.position.y;
            double posz = h.position.z;

            h.position = new Vector3d(posx + sx, posy + sy, posz + sz);
        }
    }
}

