using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class DirectionalLock : MonoBehaviour
{
    public GameState gs;
    public TextMeshProUGUI topText;
    public CinemachineVirtualCamera Room3Door_VC;
    public Camera mainCam;

    public string code;

    public Animation anim;

    public AudioSource click;


    public void AccessibleDirectionLock()
    {
        //Check if you collect the PPE Boots
        if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "North")
        {
            anim.Play(animation: "North");
            code += " North";
            click.Play();
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "South")
        {

            anim.Play(animation: "South");
            code += " South";
            click.Play();
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "East")
        {
            anim.Play(animation: "East");
            code += " East";
            click.Play();
        }

        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.name == "West")
        {
            anim.Play(animation: "West");
            code += " West";
            click.Play();
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
            }
            else
            {
                code = "";
                topText.text = code + " has been the entered code. Wrong Code Try Again. Navigate from the diamond mine to the gold mine using the mine location chart.";
                topText.GetComponent<AccessibleLabel>().SelectItem(true);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
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
                    code += " North";
                    click.Play();
                }

                else if (hit.transform.gameObject.name == "South")
                {

                    anim.Play(animation: "South");
                    code += " South";
                    click.Play();
                }

                else if (hit.transform.gameObject.name == "East")
                {
                    anim.Play(animation: "East");
                    code += " East";
                    click.Play();
                }

                else if (hit.transform.gameObject.name == "West")
                {
                    anim.Play(animation: "West");
                    code += " West";
                    click.Play();
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
                        topText.text = "Wrong Code Try Again. Navigate from diamond mine to gold mine using the mine location chart.";
                    }

                }
            }
        }
    }
}
