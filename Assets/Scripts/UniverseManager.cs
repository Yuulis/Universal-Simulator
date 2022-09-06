using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseManager : MonoBehaviour
{
    [HideInInspector] public List<Planet> planets;


    void Start()
    {
        planets = new();
    }
}
