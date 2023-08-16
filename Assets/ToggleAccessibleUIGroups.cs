using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class ToggleAccessibleUIGroups : MonoBehaviour
{
    public AccessibleUIGroupRoot controlsMenu;
    public AccessibleUIGroupRoot GameUI;
    public AccessibleUIGroupRoot Room1;
    

    public TextMeshProUGUI TopText;

    public GameObject[] AllRoots;

    public GameObject testObject;
    public GameState gs;
    private Button selectedButton;

    public CinemachineVirtualCamera[] cameras;


    public AccessibleButton_3D[] BrokenCoreTableSubButtons;
    public AccessibleButton_3D[] ButtonTableSubButtons;
    public AccessibleButton_3D[] SedimentTableSubButtons;

    private bool SubItemsEnabled = false;

    public void Update()
    {
        ToggleUIGroup();
        //CurrentCam(gs.GetCurrentCam());

        if (cameras[0].Priority == 1)
        {
            gs.SetCurrentCam("Room1_Main");
        }

        if (gs.GetCurrentCam() == "Room1_Main" && SubItemsEnabled == true) // Toggle off all of the subitems
        {
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                BrokenCoreTableSubButtons[i].enabled = false;
                SubItemsEnabled = false;
            }

            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                ButtonTableSubButtons[i].enabled = false;
                SubItemsEnabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                SedimentTableSubButtons[i].enabled = false;
                SubItemsEnabled = false;
            }

            SubItemsEnabled = false;
        }
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
            
            testObject.GetComponent<AccessibleUIGroupRoot>().enabled = !testObject.GetComponent<AccessibleUIGroupRoot>().enabled;
        }
    }

    public void SwitchUIGroup()
    {
        //root1.m_PopUp = false;
        //root2.m_PopUp = true;
    }


    //public void CurrentCam(string currentCamera)
    //{
    //    if (currentCamera == "Room1_Main")
    //    {
    //        for (int i = 0; i < AllRoots.Length; i++)
    //        {
    //            if (AllRoots[i].name == "Room1" || AllRoots[i].name == "Doors")
    //            {
    //                AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = true;
    //                Debug.Log("Room1 stuff enabled");
    //            }

    //            else
    //            {
    //                AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = false;
    //                Debug.Log("Room1 stuff disabled");
    //            }

    //        }
    //    }

    //    else if (currentCamera == "Room1_BrokenCoreTable")
    //    {
    //        for (int i = 0; i < AllRoots.Length; i++)
    //        {
    //            if (AllRoots[i].name == "CoreHolder" || AllRoots[i].name == "BrokenCorePieces")
    //            {
    //                AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = true;
    //                Debug.Log("BrokenCorePieces enabled");
    //            }

    //            else
    //            {
    //                AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = false;
    //                Debug.Log("Everything else disabled");
    //            }

    //        }

    //    }


    //}



    public void AccessibleSelectLocation(CinemachineVirtualCamera moveTo)
    {
        
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = 0;
        }
        moveTo.Priority = 1;
        //gs.SetCurrentCam("Room1_BrokenCoreShackTable");
    }

    public void SetCam(string CameraName)
    {
        gs.SetCurrentCam(CameraName);
    }

    public void ReadLabelOnMove(string label)
    {
        TopText.text = label;
        TopText.GetComponent<UAP_BaseElement>().SelectItem();
    }

    public void Enable3DButtons()
    {
        //Broken Core Table
        if (gs.GetCurrentCam() == "Room1_BrokenCoreShackTable")
        {
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                BrokenCoreTableSubButtons[i].enabled = true;
                SubItemsEnabled = true;
            }

            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                ButtonTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                SedimentTableSubButtons[i].enabled = false;
            }

        }
        //Sound Table
        else if (gs.GetCurrentCam() == "Room1_ButtonTable")
        {
            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                ButtonTableSubButtons[i].enabled = true;
                SubItemsEnabled = true;
            }

            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                BrokenCoreTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                SedimentTableSubButtons[i].enabled = false;
            }
        }
        //Sediment Table
        else if (gs.GetCurrentCam() == "Room1_SedimentDesk")
        {
            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i].gameObject.name == "Safety Goggles_Textured")
                {
                    SedimentTableSubButtons[i].enabled = false;
                }
                else
                {
                    SedimentTableSubButtons[i].enabled = true;
                }
                SubItemsEnabled = true;
            }

            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                BrokenCoreTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                ButtonTableSubButtons[i].enabled = false;
            }
        }
    }

    




}
