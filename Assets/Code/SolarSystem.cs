/// <summary>
/// --------------------------------------------------------------------------------------------------------
/// Solar Simulation with UNITY and C#
/// (c) Jonathan Ramos Weigend, Johannes Weigend
/// November 2022, Blumenau Brasilien
/// --------------------------------------------------------------------------------------------------------
/// </summary>
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Mapping zwischen Unity und der von Unity unabh‰ngigen Logik des Sonnensystems.
/// Die Idee f¸r die Dimensionen ist folgende:
/// Die Sonne hat die Grˆﬂe 1,1,1. Alle anderen Planeten sind in Bezug auf die Grˆﬂe der Sonne angegeben.
/// Die Position beginnt bei 0,0,0 und ist auf den Durchmesser der Sonne 1,1,1 bezogen.
/// Beispiel: Sonnendurchmesser = 1Mio KM, Abstand Erde = 149 Mio KM -> Abstand in Unity = 149Mio / 1Mio = 149
/// </summary>
public class SolarSystem : MonoBehaviour
{
    // The solar system. Logic based on original measures.
    private Sonnensystem sonnensystem = new Sonnensystem();

    // The corresponding List of Unity Spheres 
    private List<GameObject> solarObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Himmelskoerper h in sonnensystem.GetHimmelskoerper())
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.name = h.name;
            sphere.transform.localScale = GetUnityScale(h.radius);
            sphere.transform.position = GetUnityPosition(h.position);
            Renderer renderer = sphere.GetComponent<Renderer>();
            Color color = new Color(h.farbe.R / 256f, h.farbe.G / 256f, h.farbe.B / 256f);
            renderer.material.color = color;
            renderer.material.SetFloat("_Metallic", 0.7f);
            solarObjects.Add(sphere);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //if (Input.anyKey)
        //{
        for (int i = 0; i < Time.deltaTime * 1000; i++)
        {
            sonnensystem.Tick();
        }
        //}

        int idx = 0;
        foreach (Himmelskoerper h in sonnensystem.GetHimmelskoerper())
        {
            GameObject sphere = solarObjects[idx++];
            sphere.transform.position = GetUnityPosition(h.position);
        }
    }

    /// <summary>
    /// Maﬂstab 1:10 in Sonnendurchmessern.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private Vector3 GetUnityPosition(Vector3d position)
    {
        return new Vector3(
            (float)(position.x / (DIAMETER_OF_SUN * 10)),
            (float)(position.y / (DIAMETER_OF_SUN * 10)),
            (float)(position.z / (DIAMETER_OF_SUN * 10))
            );
    }

    /// <summary>
    /// Maﬂstab 1/10 in Sonnendurchmessern. Maximum ist 5.
    /// </summary>
    /// <param name="radius"></param>
    /// <returns></returns>
    private Vector3 GetUnityScale(double radius)
    {
        double diameter = radius + radius;
        float percentOfSun = (float)(diameter / DIAMETER_OF_SUN) * 10;
        float d = Mathf.Min(percentOfSun, 3);
        return new Vector3(d, d, d);
    }

    private const double DIAMETER_OF_SUN = 1391000.0;
}