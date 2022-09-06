using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravity : MonoBehaviour
{
    Settings settings;
    UniverseManager universeManager;

    private float G;


    void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        universeManager = GameObject.Find("UniverseManager").GetComponent<UniverseManager>();

        G = settings.CONST_GRAVITATION;
    }


    void FixedUpdate()
    {
        for (int i = 0; i < universeManager.planets.Count; i++)
        {
            Vector3 force = Vector3.zero;
            for (int j = 0; j < universeManager.planets.Count; j++)
            {
                // Same planet will be skipped
                if (i == j)
                {
                    continue;
                }

                Vector3 rVec = universeManager.planets[j].m_obj.transform.position - universeManager.planets[i].m_obj.transform.position;
                float r = rVec.magnitude;
                force += rVec.normalized * G * (universeManager.planets[i].m_rb.mass * universeManager.planets[j].m_rb.mass) / (r * r);
            }
            universeManager.planets[i].m_rb.AddForce(force);
        }
    }

}
