using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string name;
    public float mass;
    public string description;
    public string category;

    public Planet(string name, float mass, string description, string category)
    {
        this.name = name;
        this.mass = mass;
        this.category = category;
        this.description = description;
    }
}
public class SolarSystem
{
    public string Name;
    public List<Planet> Planets;

    public SolarSystem(string name)
    {
        this.Name = name;
        this.Planets = new List<Planet>();
    }
    public void AddPlanet(Planet planet)
    {
        Planets.Add(planet);
    }
}

public class Galaxy
{
    public List<SolarSystem> SolarSystems;

    public Galaxy()
    {
        this.SolarSystems = new List<SolarSystem>();
    }

    public void AddSolarSystem(SolarSystem system)
    {
        this.SolarSystems.Add(system);
    }
}

public class Program
{
    public static void Main()
    {
        // Create Galaxy
        Galaxy galaxy = new Galaxy();
        // Create Sol Solar System
        SolarSystem sol = new SolarSystem("Sol");

        // Create Planets
        Planet earth = new Planet("Earth", 15f, "A thriving place.", "s");

        // Add planet to Sol System
        sol.AddPlanet(earth);

        // Add SolarSystem to Galaxy
        galaxy.SolarSystems.Add(sol);
     }
}

