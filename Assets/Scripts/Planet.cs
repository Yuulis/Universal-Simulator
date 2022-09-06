using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planet
{
    readonly Settings settings;

    public GameObject m_obj;
    public Rigidbody m_rb;
    public Material m_material;
    public TrailRenderer m_trail;
    public int m_type;


    public Planet(GameObject obj, Rigidbody rb, Material material, TrailRenderer trail, int type, Settings settings)
    {
        m_obj = obj;
        m_rb = rb;
        m_material = material;
        m_trail = trail;
        m_type = type;
        this.settings = settings;

        RandomSet(
            this.settings.initialVelocityRange_x,
            this.settings.initialVelocityRange_y,
            this.settings.initialVelocityRange_z,
            this.settings.mass_min,
            this.settings.mass_max
        );
    }


    private void RandomSet(float vx, float vy, float vz, float mass_min, float mass_max)
    {
        m_rb.velocity = new Vector3(Random.Range(-vx, vx), Random.Range(-vy, vy), Random.Range(-vz, vz));
        m_rb.mass = Random.Range(mass_min, mass_max);

        Color color = new(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        m_material.color = color;
        m_trail.startColor = color;
        m_trail.endColor = color;

        m_trail.Clear();
    }
}