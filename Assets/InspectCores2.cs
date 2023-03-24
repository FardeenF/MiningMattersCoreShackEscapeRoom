using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectCores2 : MonoBehaviour
{
    public Material wet;
    public Renderer render;


    //Checks if water from sprayer collides with core 2
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collides with Particle");
        render.material = wet;
    }




}
