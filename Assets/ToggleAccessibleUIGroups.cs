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
    public AccessibleUIGroupRoot BrokenCoreTable;


    public GameObject[] AllRoots;

    public GameObject testObject;
    public GameState gs;
    private Button selectedButton;

    public void Update()
    {
        ToggleUIGroup();
        CurrentCam(gs.GetCurrentCam());
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


    public void CurrentCam(string currentCamera)
    {
        if (currentCamera == "Room1_Main")
        {
            for (int i = 0; i < AllRoots.Length; i++)
            {
                if (AllRoots[i].name == "Room1" || AllRoots[i].name == "Doors")
                {
                    AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = true;
                    Debug.Log("Room1 stuff enabled");
                }

                else
                {
                    AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = false;
                    Debug.Log("Room1 stuff disabled");
                }

            }
        }

        else if (currentCamera == "Room1_BrokenCoreTable")
        {
            for (int i = 0; i < AllRoots.Length; i++)
            {
                if (AllRoots[i].name == "CoreHolder" || AllRoots[i].name == "BrokenCorePieces")
                {
                    AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = true;
                    Debug.Log("BrokenCorePieces enabled");
                }

                else
                {
                    AllRoots[i].GetComponent<AccessibleUIGroupRoot>().enabled = false;
                    Debug.Log("Everything else disabled");
                }

            }

        }
    }






}
