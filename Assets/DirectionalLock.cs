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
            if (code == " North North North East East")
            {
                topText.text = "The code is correct! Room 3 is now unlocked!";
                gs.SetIsRoom3Unlocked(true);
            }
            else
            {
                code = "";
                topText.text = "Wrong Code Try Again. Navigate to the other mines using the core analysis results";
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
                        topText.text = "Wrong Code Try Again. Navigate to the other mines using the core analysis results";
                    }

                }
            }
        }
    }
}
