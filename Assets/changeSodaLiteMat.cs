using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSodaLiteMat : MonoBehaviour
{
    public Material main;
    public Material UV;

    private GameObject sodaliterock;

    private void Update()
    {
        if (sodaliterock != null)
        {
            if (this.gameObject.GetComponent<Light>().enabled == false)
            {
                sodaliterock.gameObject.GetComponent<MeshRenderer>().material = main;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SodaLiteRock")
        {
            sodaliterock = other.gameObject;
            other.gameObject.GetComponent<MeshRenderer>().material = UV;
            Debug.Log("Light Collides with Rock");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SodaLiteRock")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = main;
            Debug.Log("Light Stopped Colliding with Rock");
        }
    }
}
