using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ToggleAccessibleUIGroups : MonoBehaviour
{
    public AccessibleUIGroupRoot controlsMenu;
    public AccessibleUIGroupRoot GameUI;
    public AccessibleUIGroupRoot Room1;
    private CinemachineVirtualCamera mainCam;
    public GameObject testObject;
    public GameState gs;
    private Button selectedButton;

    public void Update()
    {
        ToggleUIGroup();
    }

    public void GetButtonObject(Button button)
    {
        selectedButton = button;
        Debug.Log(selectedButton.name);
        
    }
    public void SwitchMenuUIGroup(AccessibleUIGroupRoot root)
    {
        
        selectedButton.GetComponentInParent<AccessibleUIGroupRoot>().m_PopUp = false;
        
        root.m_PopUp = true;
        //root1.m_PopUp = false;
        //root2.m_PopUp = true;
    }

    public void SwitchMenuUIGroup2(AccessibleUIGroupRoot root)
    {

        selectedButton.GetComponentInParent<AccessibleUIGroupRoot>().m_PopUp = false;


        root.m_PopUp = false;

    }

    public void SwitchMenuUIGroup3()
    {

        selectedButton.GetComponentInParent<AccessibleUIGroupRoot>().m_PopUp = false;
       

    }

    public void ToggleUIGroup()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            mainCam.MoveToTopOfPrioritySubqueue();
            testObject.GetComponent<AccessibleUIGroupRoot>().enabled = !testObject.GetComponent<AccessibleUIGroupRoot>().enabled;
        }
    }

    //public void SwitchUIGroup()
    //{
    //    root1.m_PopUp = false;
    //    root2.m_PopUp = true;
    //}

}
