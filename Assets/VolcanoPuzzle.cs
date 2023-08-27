using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;


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


    public void AccessibleVolcanoPuzzle()
    {
        //Check if you collect the PPE Boots
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "ThickLavaButton")
        {
            thickorthin = "Thick";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "ThinLavaButton")
        {
            thickorthin = "Thin";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();

        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "LowGasButton")
        {
            lowhighgas = "Low";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();

        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "HighGasButton")
        {
            lowhighgas = "High";
            ButtonSound.Play();
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();

        }
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "StartSimButton")
        {
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<Animation>().Play();
            ButtonSound.Play();
            if (thickorthin + lowhighgas == "ThinLow")
            {
                //Shield Volcano
                Debug.Log(thickorthin + lowhighgas);

                topText.text = "This results a Shield Volcano";
                Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].time = 0.03f;
                Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].speed = 1;
                Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Shield");
                StartCoroutine(MoveBack());

            }
            else if (thickorthin + lowhighgas == "ThinHigh")
            {
                //Cinder Volcano
                Debug.Log(thickorthin + lowhighgas);
                topText.text = "This results a Cinder Volcano";

            }
            else if (thickorthin + lowhighgas == "ThickLow")
            {
                //Cone Volcano
                Debug.Log(thickorthin + lowhighgas);
                topText.text = "This results a Cinder Volcano";
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
                StartCoroutine(MoveBack());
            }
            else
            {
                //None of the above selected
                topText.text = "Pick Thick or Thin & High or Low";
                Debug.Log("Pick Thick or Thin & High or Low");
            }
        }
    }    


    private void Update()
    {
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
                }
                if (hit.transform.gameObject.name == "ThinLavaButton")
                {
                    thickorthin = "Thin";                   
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();

                }
                if (hit.transform.gameObject.name == "LowGasButton")
                {
                    lowhighgas = "Low";               
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();

                }
                if (hit.transform.gameObject.name == "HighGasButton")
                {
                    lowhighgas = "High";    
                    ButtonSound.Play();
                    hit.transform.gameObject.GetComponent<Animation>().Play();

                }
                if (hit.transform.gameObject.name == "StartSimButton")
                {
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    ButtonSound.Play();
                    if (thickorthin + lowhighgas == "ThinLow")
                    {
                        //Shield Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        
                        topText.text = "This results a Shield Volcano";
                        Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].time = 0.03f;
                        Volcano.GetComponent<Animation>()["Volcano|Cinder-Shield"].speed = 1;
                        Volcano.GetComponent<Animation>().Play(animation: "Volcano|Cinder-Shield");
                        StartCoroutine(MoveBack());

                    }
                    else if (thickorthin + lowhighgas == "ThinHigh")
                    {
                        //Cinder Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        topText.text = "This results a Cinder Volcano";
                        
                    }
                    else if (thickorthin + lowhighgas == "ThickLow")
                    {
                        //Cone Volcano
                        Debug.Log(thickorthin + lowhighgas);
                        topText.text = "This results a Cinder Volcano";
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
                        StartCoroutine(MoveBack());
                    }
                    else
                    {
                        //None of the above selected
                        topText.text = "Pick Thick or Thin & High or Low";
                        Debug.Log("Pick Thick or Thin & High or Low");
                    }
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
