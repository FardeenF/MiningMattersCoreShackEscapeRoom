using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class VolcanoPuzzle : MonoBehaviour
{
    public CinemachineVirtualCamera Volcano_VC;
    public Camera mainCam;
    public GameState gs;
    public TextMeshProUGUI topText;

    public string thickorthin = "";
    public string lowhighgas = "";

    public GameObject Volcano;
    
    public AudioSource ButtonSound;
    public GameObject Diamond;

    public ToggleAccessibleUIGroups toggle;

    public TextMeshPro[] volcanoDisplay;

    public GameObject[] displayBlocks;

    public TextMeshPro[] volcanoCombinations;

    private int displayCounter;

    private float originalY;
    private float originalXTopRow;
    private float originalXBottomRow;

    public float offSetHeight = 2.0f;
    public float offSetX = 0.0f;
    public float offSetZ = -67.0f;

    public float floatStrength = 0.10f;
    public float floatStrength2 = 0.01f;

    private void Start()
    {
        originalY = displayBlocks[0].transform.position.y;
        originalXTopRow = displayBlocks[2].transform.localPosition.z;
        originalXBottomRow = displayBlocks[3].transform.localPosition.z;
        offSetHeight = 2.0f;
        offSetX = 0.0f;
        offSetZ = 0.0f;
        floatStrength = 0.10f;
        floatStrength2 = 0.02f;

        for (int i = 0; i < displayBlocks.Length; i++)
        {
            if(i < 2)
                volcanoDisplay[i].text = " ";

            displayBlocks[i].SetActive(false);
        }

        for (int i = 0; i < volcanoCombinations.Length; i++)
        {
            volcanoCombinations[i].text = "????? + ????? = ??????";
            volcanoCombinations[i].fontSize = 1.4f;
        }
    }

    public void AccessibleVolcanoPuzzle()
    {
        //Check if you collect the PPE Boots
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "ThickLavaButton")
        {
            thickorthin = "Thick";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
            volcanoDisplay[0].text = "Thick Lava";
        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "ThinLavaButton")
        {
            thickorthin = "Thin";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
            volcanoDisplay[0].text = "Thin Lava";
        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "LowGasButton")
        {
            lowhighgas = "Low";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
            volcanoDisplay[1].text = "Low Gas";
        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "HighGasButton")
        {
            lowhighgas = "High";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
            volcanoDisplay[1].text = "High Gas";
        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "StartSimButton")
        {
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
            ButtonSound.Play();
            if (thickorthin + lowhighgas == "ThinLow")
            {
                //Shield Volcano
                Debug.Log(thickorthin + lowhighgas);

                topText.text = "Thin Lava + Low Gas has resulted in a Shield Volcano. Nothing seems to have occured. Try a different combination.";
                topText.gameObject.GetComponent<AccessibleLabel>().SelectItem(true);

                Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].time = 0.03f;
                Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].speed = 1;
                Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Shield");

                for (int i = 0; i < volcanoDisplay.Length; i++)
                {
                    volcanoDisplay[i].text = " ";
                }

                volcanoCombinations[0].text = "Thin Lava + Low Gas = Shield Volcano";
                volcanoCombinations[0].fontSize = 0.8f;

                StartCoroutine(MoveBack());

            }
            else if (thickorthin + lowhighgas == "ThinHigh")
            {
                //Cinder Volcano
                Debug.Log(thickorthin + lowhighgas);
                topText.text = "Thin Lava + High Gas has resulted in a Cinder Volcano. Nothing seems to have occured. Try a different combination.";
                topText.gameObject.GetComponent<AccessibleLabel>().SelectItem(true);

                for (int i = 0; i < volcanoDisplay.Length; i++)
                {
                    volcanoDisplay[i].text = " ";
                }

                volcanoCombinations[1].text = "Thin Lava + High Gas = Cinder Volcano";
                volcanoCombinations[1].fontSize = 0.8f;
            }
            else if (thickorthin + lowhighgas == "ThickLow")
            {
                //Cone Volcano
                Debug.Log(thickorthin + lowhighgas);
                topText.text = "Thick Lava + Low Gas has resulted in a Cone Volcano. Nothing seems to have occured. Try a different combination.";
                topText.gameObject.GetComponent<AccessibleLabel>().SelectItem(true);

                for (int i = 0; i < volcanoDisplay.Length; i++)
                {
                    volcanoDisplay[i].text = " ";
                }

                volcanoCombinations[3].text = "Thick Lava + Low Gas = Cone Volcano";
                volcanoCombinations[3].fontSize = 0.8f;
            }
            else if (thickorthin + lowhighgas == "ThickHigh")
            {
                //Composite Volcano
                Debug.Log(thickorthin + lowhighgas);
                Diamond.SetActive(true);
                topText.text = "Thick Lava + High Gas has resulted in a Composite Volcano. A diamond with a code has appeared!.";
                topText.gameObject.GetComponent<AccessibleLabel>().SelectItem(true);
                Volcano.GetComponent<Animation>()["Volcano|Cinder-Composite"].time = 0.03f;
                Volcano.GetComponent<Animation>()["Volcano|Cinder-Composite"].speed = 1;
                Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Composite");

                gs.SetVolcanoPuzzleSolved(true);

                for (int i = 0; i < volcanoDisplay.Length; i++)
                {
                    volcanoDisplay[i].text = " ";
                }

                volcanoCombinations[2].text = "Thick Lava + High Gas = Composite Volcano";
                volcanoCombinations[2].fontSize = 0.8f;

                toggle.Enable3DButtons();
                StartCoroutine(MoveBack());
               
            }
            else
            {
                //None of the above selected
                topText.text = "The combination is incomplete. Select both a lava and gas type to start a simulation.";
                topText.gameObject.GetComponent<AccessibleLabel>().SelectItem(true);
                Debug.Log("Pick Thick or Thin & High or Low");
            }

            thickorthin = "";
            lowhighgas = "";
        }
    }    


    private void Update()
    {

        if (Volcano_VC.Priority == 1)
        {
            //Enable Blocks
            do
            {
                for (int i = 0; i < displayBlocks.Length; i++)
                {
                    displayBlocks[i].SetActive(true);
                }

            } while (!displayBlocks[0].activeInHierarchy);


            for (int i = 0; i < displayBlocks.Length; i++)
            {
                if (i == 0)
                {
                    displayBlocks[i].transform.localPosition = new Vector3(displayBlocks[i].transform.localPosition.x,
                    originalY + offSetHeight + ((float)Math.Sin(Time.time) * floatStrength),
                    displayBlocks[i].transform.localPosition.z);
                }
                else if(i == 1)
                {
                    displayBlocks[i].transform.localPosition = new Vector3(displayBlocks[i].transform.localPosition.x,
                    originalY + offSetHeight + ((float)Math.Sin(Time.time) * floatStrength) * -1.0f,
                    displayBlocks[i].transform.localPosition.z);
                }
                else if (i == 2)
                {
                    displayBlocks[i].transform.localPosition = new Vector3(displayBlocks[i].transform.localPosition.x + offSetX,
                    displayBlocks[i].transform.localPosition.y,
                    originalXTopRow + offSetZ + ((float)Math.Sin(Time.time) * floatStrength2));
                }
                else if (i == 5)
                {
                    displayBlocks[i].transform.localPosition = new Vector3(displayBlocks[i].transform.localPosition.x + offSetX,
                    displayBlocks[i].transform.localPosition.y,
                    originalXBottomRow + offSetZ + ((float)Math.Sin(Time.time) * floatStrength2));
                }
                else if (i == 3)
                {
                    displayBlocks[i].transform.localPosition = new Vector3(displayBlocks[i].transform.localPosition.x + offSetX,
                    displayBlocks[i].transform.localPosition.y,
                    originalXBottomRow + offSetZ + ((float)Math.Sin(Time.time) * floatStrength2) * -1.0f);
                }
                else
                {
                    displayBlocks[i].transform.localPosition = new Vector3(displayBlocks[i].transform.localPosition.x + offSetX,
                    displayBlocks[i].transform.localPosition.y,
                    originalXTopRow + offSetZ + ((float)Math.Sin(Time.time) * floatStrength2) * -1.0f);
                }
            }


        }
        else
        {
            for (int i = 0; i < volcanoDisplay.Length; i++)
            {
                displayBlocks[i].SetActive(false);
            }
        }

        if (Volcano_VC.Priority == 1 && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if you collect the PPE Boots
                if (hit.transform.gameObject.name == "ThickLavaButton")
                {
                    thickorthin = "Thick";                   
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    volcanoDisplay[0].text = "Thick Lava";
                }
                if (hit.transform.gameObject.name == "ThinLavaButton")
                {
                    thickorthin = "Thin";                   
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    volcanoDisplay[0].text = "Thin Lava";
                }
                if (hit.transform.gameObject.name == "LowGasButton")
                {
                    lowhighgas = "Low";               
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    volcanoDisplay[1].text = "Low Gas";
                }
                if (hit.transform.gameObject.name == "HighGasButton")
                {
                    lowhighgas = "High";    
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    volcanoDisplay[1].text = "High Gas";
                }
                if (hit.transform.gameObject.name == "StartSimButton")
                {
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    ButtonSound.Play();
                    if (thickorthin + lowhighgas == "ThinLow")
                    {
                        //Shield Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        
                        topText.text = "This results in a Shield Volcano";
                        Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].time = 0.03f;
                        Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].speed = 1;
                        Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Shield");
                        StartCoroutine(MoveBack());

                        for(int i = 0; i < volcanoDisplay.Length; i++)
                        {
                            volcanoDisplay[i].text = " ";
                        }

                        volcanoCombinations[0].text = "Thin Lava + Low Gas = Shield Volcano";
                        volcanoCombinations[0].fontSize = 0.8f;
                    }
                    else if (thickorthin + lowhighgas == "ThinHigh")
                    {
                        //Cinder Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        topText.text = "This results in a Cinder Volcano";

                        for (int i = 0; i < volcanoDisplay.Length; i++)
                        {
                            volcanoDisplay[i].text = " ";
                        }

                        volcanoCombinations[1].text = "Thin Lava + High Gas = Cinder Volcano";
                        volcanoCombinations[1].fontSize = 0.8f;
                    }
                    else if (thickorthin + lowhighgas == "ThickLow")
                    {
                        //Cone Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        topText.text = "This results in a Cone Volcano";

                        for (int i = 0; i < volcanoDisplay.Length; i++)
                        {
                            volcanoDisplay[i].text = " ";
                        }

                        volcanoCombinations[3].text = "Thick Lava + Low Gas = Cone Volcano";
                        volcanoCombinations[3].fontSize = 0.8f;
                    }
                    else if (thickorthin + lowhighgas == "ThickHigh")
                    {
                        //Composite Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        Diamond.SetActive(true);
                        topText.text = "This results a Composite Volcano Which Can Bring Up Diamonds from the Mantel!";
                        Volcano.GetComponent<Animation>()["Volcano|Cinder-Composite"].time = 0.03f;
                        Volcano.GetComponent<Animation>()["Volcano|Cinder-Composite"].speed = 1;
                        Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Composite");

                        volcanoCombinations[2].text = "Thick Lava + High Gas = Composite Volcano";
                        volcanoCombinations[2].fontSize = 0.8f;

                        for (int i = 0; i < volcanoDisplay.Length; i++)
                        {
                            volcanoDisplay[i].text = " ";
                        }

                        StartCoroutine(MoveBack());
                    }
                    else
                    {
                        //None of the above selected
                        topText.text = "The combination is incomplete. Select both a lava and gas type to start a simulation.";
                        Debug.Log("Pick Thick or Thin & High or Low");
                    }

                    thickorthin = "";
                    lowhighgas = "";
                }

            }
        }
    }

    IEnumerator MoveBack()
    {
        
        yield return new WaitForSeconds(2);
        if (thickorthin + lowhighgas == "ThinLow")
        {
            Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].time = 0.3f;
            Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].speed = -1;
            Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Shield");
        }
        else if (thickorthin + lowhighgas == "ThickHigh")
        {
            Volcano.GetComponent<Animation>()["Volcano|Cinder-Composite"].time = 0.3f;
            Volcano.GetComponent<Animation>()["Volcano|Cinder-Composite"].speed = -1;
            Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Composite");
        }



        StopCoroutine(MoveBack());


    }

}
