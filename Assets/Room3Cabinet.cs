using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room3Cabinet : MonoBehaviour
{
    public bool isOpen = false;
    public Animation anim;
    public string animName;
    public AudioSource OpenClose;

    public TextMeshProUGUI topText;
    
    public void AccessibleOpenCabinet()
    {
        if (isOpen == false)
        {
            anim[animName].time = 0.03f;
            anim[animName].speed = 1;
            anim.Play(animation: animName);
            OpenClose.Play();
            isOpen = true;
        }
        else if (isOpen == true)
        {
            anim[animName].time = 0.3f;
            anim[animName].speed = -1;
            anim.Play(animation: animName);
            OpenClose.Play();
            isOpen = false;
        }
    }

    public void EmptyCabinetMessage()
    {
        topText.text = "This drawer is empty.";
        topText.gameObject.GetComponent<AccessibleLabel>().SelectItem(true);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isOpen == false)
        {
            anim[animName].time = 0.03f;
            anim[animName].speed = 1;
            anim.Play(animation: animName);
            OpenClose.Play();
            isOpen = true;
        }
        else if (Input.GetMouseButtonDown(0) && isOpen == true)
        {
            //anim.Rewind("Cube.025|RightRightDoor");
            anim[animName].time = 0.3f;
            anim[animName].speed = -1;
            anim.Play(animation: animName);
            OpenClose.Play();
            isOpen = false;
        }
    }


    
}
