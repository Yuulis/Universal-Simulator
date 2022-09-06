using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawn : MonoBehaviour
{
    Settings settings;
    UniverseManager universeManager;

    public GameObject planet_obj;


    void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        universeManager = GameObject.Find("UniverseManager").GetComponent<UniverseManager>();

        for (int i = 0; i < settings.spawnPlanetNum; i++)
        {
            Spawn(settings.spawnArea_x, settings.spawnArea_y, settings.spawnArea_z);
        }
    }


    public void Spawn(float x, float y, float z)
    {
        GameObject obj = Instantiate(
            planet_obj, 
            new Vector3(Random.Range(-x, x), Random.Range(-y, y), Random.Range(-z, z)), 
            Quaternion.identity
        );

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        Material material = obj.GetComponent<Renderer>().material;
        TrailRenderer trail = obj.GetComponent<TrailRenderer>();
        Planet planet = new(obj, rb, material, trail, 1, settings);

        universeManager.planets.Add(planet);
    }
}
