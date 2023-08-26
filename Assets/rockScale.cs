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

    public SoundManager soundManager;


    public void ReadAccessibilityMessage(string text)
    {
        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().m_Text = text;
        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().SelectItem(true);
    }

    public void AccessibleRockMover()
    {
        //Check if you collect the PPE Boots
        if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "Sedimentary")
        {
            if (placedRock == false)
            {
                UAP_AccessibilityManager.GetCurrentFocusObject().transform.position = rockLocation.transform.position;

                Igneous.transform.position = emptyIgneous.transform.position;
                Metamorphic.transform.position = emptyMetamorphic.transform.position;

                weight.text = "3g";
                placedRock = true;

                soundManager.PlayAltPickupSound();

                ReadAccessibilityMessage("Sedimentary Rock Sample Weighs 3 grams. Select to return Rock back to table.");
            }
            else if (placedRock == true && UAP_AccessibilityManager.GetCurrentFocusObject().transform.position == rockLocation.transform.position)
            {
                UAP_AccessibilityManager.GetCurrentFocusObject().transform.position = emptySedimentary.transform.position;
                weight.text = "0g";
                placedRock = false;
                ReadAccessibilityMessage("Sedimentary Rock Sample Weighs 3 grams.");
            }
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "Metamorphic")
        {
            if (placedRock == false)
            {
                UAP_AccessibilityManager.GetCurrentFocusObject().transform.position = rockLocation.transform.position;

                Igneous.transform.position = emptyIgneous.transform.position;
                Sedimentary.transform.position = emptySedimentary.transform.position;

                weight.text = "4g";
                placedRock = true;

                soundManager.PlayAltPickupSound();
                ReadAccessibilityMessage("Metamorphic Rock Sample Weighs 4 grams. Select to return Rock back to table.");
            }
            else if (placedRock == true && UAP_AccessibilityManager.GetCurrentFocusObject().transform.position == rockLocation.transform.position)
            {
                UAP_AccessibilityManager.GetCurrentFocusObject().transform.position = emptyMetamorphic.transform.position;
                weight.text = "0g";
                placedRock = false;
                ReadAccessibilityMessage("Metamorphic Rock Sample Weighs 4 grams.");
            }
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "Igneous")
        {
            if (placedRock == false)
            {
                UAP_AccessibilityManager.GetCurrentFocusObject().transform.position = rockLocation.transform.position;

                Sedimentary.transform.position = emptySedimentary.transform.position;
                Metamorphic.transform.position = emptyMetamorphic.transform.position;

                weight.text = "6g";
                placedRock = true;

                soundManager.PlayAltPickupSound();
                ReadAccessibilityMessage("Igneous Rock Sample Weighs 6 grams. Select to return Rock back to table.");
            }
            else if (placedRock == true && UAP_AccessibilityManager.GetCurrentFocusObject().transform.position == rockLocation.transform.position)
            {
                UAP_AccessibilityManager.GetCurrentFocusObject().transform.position = emptyIgneous.transform.position;
                weight.text = "0g";
                placedRock = false;
                ReadAccessibilityMessage("Igneous Rock Sample Weighs 6 grams.");
            }
        }
    }


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

                        soundManager.PlayAltPickupSound();
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

                        soundManager.PlayAltPickupSound();
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

                        soundManager.PlayAltPickupSound();
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