using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using System;

public class DirectionalLock : MonoBehaviour
{
    public GameState gs;
    public TextMeshProUGUI topText;
    public CinemachineVirtualCamera Room3Door_VC;
    public Camera mainCam;

    public string code;

    public Animation anim;

    public AudioSource click;

    public TextMeshPro[] codeDisplay;

    public GameObject[] displayBlocks;

    private int displayCounter;

    private float originalY;

    public float offSetHeight = 0.00f;

    public float floatStrength = 0.10f;


    private void Start()
    {
        displayCounter = 0;
        originalY = displayBlocks[0].transform.position.y;
        offSetHeight = 0.0f;
        floatStrength = 0.10f;

        for (int i = 0; i < codeDisplay.Length; i++)
        {
            codeDisplay[i].text = " ";

            displayBlocks[i].SetActive(false);
        }
    }

    public void AccessibleDirectionLock()
    {
        //Check if you collect the PPE Boots
        if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "North")
        {
            anim.Play(animation: "North");
            click.Play();

            if (displayCounter < 5)
            {
                code += " North";
                codeDisplay[displayCounter].text = "N";
                displayCounter++;
            }
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "South")
        {
            anim.Play(animation: "South");
            click.Play();

            if (displayCounter < 5)
            {
                code += " South";
                codeDisplay[displayCounter].text = "S";
                displayCounter++;
            }
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "East")
        {
            anim.Play(animation: "East");
            click.Play();

            if (displayCounter < 5)
            {
                code += " East";
                codeDisplay[displayCounter].text = "E";
                displayCounter++;
            }
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "West")
        {
            anim.Play(animation: "West");
            click.Play();

            if (displayCounter < 5)
            {
                code += " West";
                codeDisplay[displayCounter].text = "W";
                displayCounter++;
            }
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "Check")
        {
            anim.Play(animation: "Check");
            click.Play();

            if (code == " North North North East East" )
            {
                topText.text = code + " has been the entered code. The code is correct! Room 3 is now unlocked!";
                topText.GetComponent<AccessibleLabel>().SelectItem(true);
                gs.SetIsRoom3Unlocked(true);
            }
            else if(code == "")
            {
                topText.text = "No directions have been added to the passcode. Please enter directions before checking the code.";
                topText.GetComponent<AccessibleLabel>().SelectItem(true);

                for (int i = 0; i < codeDisplay.Length; i++)
                {
                    codeDisplay[i].text = " ";
                }
            }
            else
            {
                code = "";
                topText.text = code + " has been the entered code. Wrong Code, try again. This is a directional lock that has 5 direction codes. This appears to be a grid-based solution...";
                topText.GetComponent<AccessibleLabel>().SelectItem(true);

                for (int i = 0; i < codeDisplay.Length; i++)
                {
                    codeDisplay[i].text = " ";
                }
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Room3Door_VC.Priority == 1)
        {
            //Enable Blocks
            do
            {
                for (int i = 0; i < codeDisplay.Length; i++)
                {
                    displayBlocks[i].SetActive(true);
                }

            } while (!displayBlocks[0].activeInHierarchy);


            for (int i = 0; i < codeDisplay.Length; i++)
            {
                if (i == 0 || i == 2 || i == 4)
                {
                    displayBlocks[i].transform.position = new Vector3(displayBlocks[i].transform.position.x,
                    originalY + offSetHeight + ((float)Math.Sin(Time.time) * floatStrength),
                    displayBlocks[i].transform.position.z);
                }
                else
                {
                    displayBlocks[i].transform.position = new Vector3(displayBlocks[i].transform.position.x,
                    originalY + offSetHeight + ((float)Math.Sin(Time.time) * floatStrength) * -1.0f,
                    displayBlocks[i].transform.position.z);
                }
            }

            
        }
        else
        {
            for (int i = 0; i < codeDisplay.Length; i++)
            {
                displayBlocks[i].SetActive(false);
            }
        }

        if (Room3Door_VC.Priority == 1 && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if you collect the PPE Boots
                if (hit.transform.gameObject.name == "North")
                {
                    anim.Play(animation: "North");
                    click.Play();

                    if(displayCounter < 5)
                    {
                        code += " North";
                        codeDisplay[displayCounter].text = "N";
                        displayCounter++;
                    }
                }

                else if (hit.transform.gameObject.name == "South")
                {

                    anim.Play(animation: "South");
                    click.Play();

                    if (displayCounter < 5)
                    {
                        code += " South";
                        codeDisplay[displayCounter].text = "S";
                        displayCounter++;
                    }
                }

                else if (hit.transform.gameObject.name == "East")
                {
                    anim.Play(animation: "East");
                    click.Play();

                    if (displayCounter < 5)
                    {
                        code += " East";
                        codeDisplay[displayCounter].text = "E";
                        displayCounter++;
                    }

                }

                else if (hit.transform.gameObject.name == "West")
                {
                    anim.Play(animation: "West");
                    click.Play();

                    if (displayCounter < 5)
                    {
                        code += " West";
                        codeDisplay[displayCounter].text = "W";
                        displayCounter++;
                    }
                }

                else if (hit.transform.gameObject.name == "Check")
                {
                    anim.Play(animation: "Check");
                    click.Play();
                    if (code == " North North North East East")
                    {
                        topText.text = "The code is correct! Room 3 is now unlocked!";
                        gs.SetIsRoom3Unlocked(true);
                    }
                    else
                    {
                        code = "";
                        topText.text = "Wrong Code, try again. This is a directional lock that has 5 direction codes. This appears to be a grid-based solution...";

                        displayCounter = 0;

                        for (int i = 0; i < codeDisplay.Length; i++)
                        {
                            codeDisplay[i].text = " ";
                        }
                    }

                }
            }
        }
    }
}
