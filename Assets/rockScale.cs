using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class rockScale : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineVirtualCamera VC_RockSampleDesk;
    public bool placedRock = false;

    public GameObject rockLocation;
    public TextMeshProUGUI weight;

    public GameObject emptyIgneous;
    public GameObject emptyMetamorphic;
    public GameObject emptySedimentary;

    public GameObject Igneous;
    public GameObject Metamorphic;
    public GameObject Sedimentary;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && VC_RockSampleDesk.Priority == 1)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if you collect the PPE Boots
                if (hit.transform.gameObject.name == "Sedimentary")
                {
                    if (placedRock == false)
                    {
                        hit.transform.position = rockLocation.transform.position;

                        Igneous.transform.position = emptyIgneous.transform.position;
                        Metamorphic.transform.position = emptyMetamorphic.transform.position;

                        weight.text = "3g";
                        placedRock = true;
                    }
                    else if (placedRock == true && hit.transform.position == rockLocation.transform.position)
                    {
                        hit.transform.position = emptySedimentary.transform.position;
                        weight.text = "0g";
                        placedRock = false;
                    }
                }

                else if (hit.transform.gameObject.name == "Metamorphic")
                {
                    if (placedRock == false)
                    {
                        hit.transform.position = rockLocation.transform.position;

                        Igneous.transform.position = emptyIgneous.transform.position;
                        Sedimentary.transform.position = emptySedimentary.transform.position;

                        weight.text = "4g";
                        placedRock = true;
                    }
                    else if (placedRock == true && hit.transform.position == rockLocation.transform.position)
                    {
                        hit.transform.position = emptyMetamorphic.transform.position;
                        weight.text = "0g";
                        placedRock = false;
                    }
                }

                else if (hit.transform.gameObject.name == "Igneous")
                {
                    if (placedRock == false)
                    {
                        hit.transform.position = rockLocation.transform.position;

                        Sedimentary.transform.position = emptySedimentary.transform.position;
                        Metamorphic.transform.position = emptyMetamorphic.transform.position;

                        weight.text = "6g";
                        placedRock = true;
                    }
                    else if (placedRock == true && hit.transform.position == rockLocation.transform.position)
                    {
                        hit.transform.position = emptyIgneous.transform.position;
                        weight.text = "0g";
                        placedRock = false;
                    }
                }
            }
        }
    }
}