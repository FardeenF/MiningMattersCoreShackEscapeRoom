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
    public AccessibleUIGroupRoot Room2;


    public TextMeshProUGUI TopText;

    public GameObject[] AllRoots;

    public GameObject testObject;
    public GameState gs;
    private Button selectedButton;

    public CinemachineVirtualCamera[] cameras;

    //Room 1
    public AccessibleButton_3D[] BrokenCoreTableSubButtons;
    public AccessibleButton_3D[] ButtonTableSubButtons;
    public AccessibleButton_3D[] SedimentTableSubButtons;
    public AccessibleButton_3D[] CabinetSubButtons;
    public AccessibleButton_3D[] InsideTopCabinetSubButtons;
    public AccessibleButton_3D[] InsideBottomCabinetSubButtons;
    public AccessibleButton_3D[] ComputerDeskSubButtons;

    //Room 2
    public AccessibleButton_3D[] WaterShutOffSubButtons;
    public AccessibleButton_3D[] RockScaleSubButtons;
    public AccessibleButton_3D[] FilingCabinetSubButtons;
    public AccessibleButton_3D[] InsideFilingCabinetSubButtons;
    public AccessibleButton_3D[] DiamondSawSubButtons;
    public AccessibleButton_3D[] PowerCircuitSubButtons;
    public AccessibleButton_3D[] BoxDeskSubButtons;


    public GameObject[] MainRoom1Locations;
    public GameObject[] MainRoom2Locations;


    private bool SubItemsEnabled = false;

    public void MoveToOtherRoom(CinemachineVirtualCamera VC)
    {
        if (gs.GetCurrentRoom() == 1)
        {
            VC = cameras[0];
            Room2.enabled = false;
            Room1.enabled = true;
        }
        else if (gs.GetCurrentRoom() == 2)
        {
            VC = cameras[11];
            Room2.enabled = true;
            Room1.enabled = false;
        }
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = 0;
        }
        VC.Priority = 1;
    }

    public void ChangeGroupsRoom1and2()
    {
        if (gs.GetCurrentRoom() == 1)
        {
            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
                
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
        }
        else if (gs.GetCurrentRoom() == 2)
        {
            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
            }
        }
        
    }

    public void Update()
    {
        ToggleUIGroup();
        //CurrentCam(gs.GetCurrentCam());

        if (cameras[0].Priority == 1)
        {
            gs.SetCurrentCam("Room1_Main");
        }

        else if (cameras[11].Priority == 1)
        {
            gs.SetCurrentCam("Room2_Main");
        }

        if (gs.GetCurrentCam() == "Room1_Main" && SubItemsEnabled == true) // Toggle off all of the subitems
        {
            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                if (MainRoom1Locations[i] != null)
                    MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;

                SubItemsEnabled = false;
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

                SubItemsEnabled = false;
            }
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                if (BrokenCoreTableSubButtons[i] != null)
                    BrokenCoreTableSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                if (ButtonTableSubButtons[i] != null)
                    ButtonTableSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i] != null)
                    SedimentTableSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < CabinetSubButtons.Length; i++)
            {
                if (CabinetSubButtons[i] != null)
                    CabinetSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }
            for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
            {
                if (InsideTopCabinetSubButtons[i] != null)
                    InsideTopCabinetSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }
            for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
            {
                if (InsideBottomCabinetSubButtons[i] != null)
                    InsideBottomCabinetSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null)
                    ComputerDeskSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }
            

            SubItemsEnabled = false;
        }
        //Room 2 disable sub buttons
        if (gs.GetCurrentCam() == "Room2_Main" && SubItemsEnabled == true)
        {
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;

                SubItemsEnabled = false;
            }
            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                if (MainRoom1Locations[i] != null)
                    MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

                SubItemsEnabled = false;
            }


            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < RockScaleSubButtons.Length; i++)
            {
                if (RockScaleSubButtons[i] != null)
                    RockScaleSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            {
                if (FilingCabinetSubButtons[i] != null)
                    FilingCabinetSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
            {
                if (InsideFilingCabinetSubButtons[i] != null)
                    InsideFilingCabinetSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            {
                if (PowerCircuitSubButtons[i] != null)
                    PowerCircuitSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = false;

                SubItemsEnabled = false;
            }

            SubItemsEnabled = false;
        }


        //Disabling the other main location buttons
        if (gs.GetCurrentCam() == "Room1_Main")
        {
            for(int i = 0; i < MainRoom1Locations.Length; i++)
            {
                MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
            }
        }
        else if(gs.GetCurrentCam() == "Room2_Main")
        {
            for(int i = 0; i < MainRoom2Locations.Length; i++)
            {
                MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
            }

            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                if(MainRoom1Locations[i].name == "Door (1)")
                {
                    MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
                }
                else
                {
                    MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
                }
            }
        }
        else
        {
            //Disable Main Room 1
            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //Disable Main Room 2
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
        }
    }


    public void ReadAccessibilityMessage(string text)
    {
        //UAP_AccessibilityManager.GetCurrentFocusObject().gameObject.GetComponent<AccessibleButton_3D>().name = text;
        //UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().m_NameLabel = this.gameObject;
        //UAP_AccessibilityManager.GetCurrentFocusObject().gameObject.GetComponent<AccessibleButton_3D>().m_NameLabel.name = text;
        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().m_Text = text;
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
        //if(Input.GetKeyDown(KeyCode.L))
        //{
            
        //    testObject.GetComponent<AccessibleUIGroupRoot>().enabled = !testObject.GetComponent<AccessibleUIGroupRoot>().enabled;
        //}
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
                if (BrokenCoreTableSubButtons[i] != null)
                {
                    BrokenCoreTableSubButtons[i].enabled = true;
                }
                

                if ((BrokenCoreTableSubButtons[i].name == "Orange Core Piece" ||
                    BrokenCoreTableSubButtons[i].name == "Red Core Piece" ||
                    BrokenCoreTableSubButtons[i].name == "Yellow Core Piece" ||
                    BrokenCoreTableSubButtons[i].name == "Blue Core Piece") &&
                    gs.GetCorePasswordSolved())
                {
                    Debug.Log(BrokenCoreTableSubButtons[i].name);
                    BrokenCoreTableSubButtons[i].enabled = false;
                }

                if (BrokenCoreTableSubButtons[i].name == "Password Message")
                {
                    BrokenCoreTableSubButtons[i].enabled = false;
                }

                if (BrokenCoreTableSubButtons[i].name == "Password Message" && gs.GetCorePasswordSolved())
                {
                    BrokenCoreTableSubButtons[i].enabled = true;
                }

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                if (ButtonTableSubButtons[i] != null)
                    ButtonTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i] != null)
                    SedimentTableSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
            {
                if (InsideTopCabinetSubButtons[i] != null)
                    InsideTopCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
            {
                if (InsideBottomCabinetSubButtons[i] != null)
                    InsideBottomCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null)
                    ComputerDeskSubButtons[i].enabled = false;
            }
            //

        }
        //Sound Table
        else if (gs.GetCurrentCam() == "Room1_ButtonTable")
        {
            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                if (ButtonTableSubButtons[i] != null)
                    ButtonTableSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                if (BrokenCoreTableSubButtons[i] != null)
                    BrokenCoreTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i] != null)
                    SedimentTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < CabinetSubButtons.Length; i++)
            {
                if (CabinetSubButtons[i] != null)
                    CabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
            {
                if (InsideTopCabinetSubButtons[i] != null)
                    InsideTopCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
            {
                if (InsideBottomCabinetSubButtons[i] != null)
                    InsideBottomCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null)
                    ComputerDeskSubButtons[i].enabled = false;
            }
            //
        }
        //Sediment Table
        else if (gs.GetCurrentCam() == "Room1_SedimentDesk")
        {
            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i] == null)
                    i++;
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
            // Set others to false
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                if (BrokenCoreTableSubButtons[i] != null)
                    BrokenCoreTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                if (ButtonTableSubButtons[i] != null)
                    ButtonTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < CabinetSubButtons.Length; i++)
            {
                if (CabinetSubButtons[i] != null)
                    CabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
            {
                if (InsideTopCabinetSubButtons[i] != null)
                    InsideTopCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
            {
                if (InsideBottomCabinetSubButtons[i] != null)
                    InsideBottomCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null)
                    ComputerDeskSubButtons[i].enabled = false;
            }
            //
        }

        //Puzzle Cabinet
        else if (gs.GetCurrentCam() == "Room1_Cabinet" || gs.GetCurrentCam() == "Room1_CabinetLock")
        {
            for (int i = 0; i < CabinetSubButtons.Length; i++)
            {
                if (CabinetSubButtons[i] != null)
                {
                    CabinetSubButtons[i].enabled = true;
                    
                }
                SubItemsEnabled = true;
            }
            //Setting inside top of cabinet sub items to true
            if (gs.GetJigSawDone() == true)
            {

                for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
                {
                    if (InsideTopCabinetSubButtons[i] != null)
                        InsideTopCabinetSubButtons[i].enabled = true;
                }
            }

            if (gs.GetHasUnlockedCabinetLock() == true)
            {
                for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
                {
                    if (InsideBottomCabinetSubButtons[i] != null)
                        InsideBottomCabinetSubButtons[i].enabled = true;
                }
            }

            // Set others to false
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                if (BrokenCoreTableSubButtons[i] != null)
                    BrokenCoreTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                if (ButtonTableSubButtons[i] != null)
                    ButtonTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i] != null)
                    SedimentTableSubButtons[i].enabled = false;
            }
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null)
                    ComputerDeskSubButtons[i].enabled = false;
            }
            //
        }

        //Computer Desk
        else if (gs.GetCurrentCam() == "Room1_Computer")
        {
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null && !gs.GetRoom1PasswordPuzzle())
                {
                    ComputerDeskSubButtons[i].enabled = true;
                }

                if(ComputerDeskSubButtons[i].name == "EmailRead")
                {
                    ComputerDeskSubButtons[i].enabled = false;
                }

                if(ComputerDeskSubButtons[i].name == "EmailRead" && gs.GetRoom1PasswordPuzzle())
                {
                    ComputerDeskSubButtons[i].enabled = true;
                }
                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            {
                if (BrokenCoreTableSubButtons[i] != null)
                    BrokenCoreTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            {
                if (SedimentTableSubButtons[i] != null)
                    SedimentTableSubButtons[i].enabled = false;
            }

            for (int i = 0; i < CabinetSubButtons.Length; i++)
            {
                if (CabinetSubButtons[i] != null)
                    CabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
            {
                if (InsideTopCabinetSubButtons[i] != null)
                    InsideTopCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
            {
                if (InsideBottomCabinetSubButtons[i] != null)
                    InsideBottomCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            {
                if (ButtonTableSubButtons[i] != null)
                    ButtonTableSubButtons[i].enabled = false;
            }
            //
        }

        //Watch Switch
        if (gs.GetCurrentCam() == "Room2_WaterSwitch")
        {
            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < RockScaleSubButtons.Length; i++)
            {
                if (RockScaleSubButtons[i] != null)
                    RockScaleSubButtons[i].enabled = false;
            }
            for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            {
                if (FilingCabinetSubButtons[i] != null)
                    FilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
            {
                if (InsideFilingCabinetSubButtons[i] != null)
                    InsideFilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            {
                if (PowerCircuitSubButtons[i] != null)
                    PowerCircuitSubButtons[i].enabled = false;
            }
            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = false;
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
        // Rock Scale
        if (gs.GetCurrentCam() == "Room2_RockSampleDesk")
        {
            for (int i = 0; i < RockScaleSubButtons.Length; i++)
            {
                if (RockScaleSubButtons[i] != null)
                    RockScaleSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = false;
            }
            for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            {
                if (FilingCabinetSubButtons[i] != null)
                    FilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
            {
                if (InsideFilingCabinetSubButtons[i] != null)
                    InsideFilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            {
                if (PowerCircuitSubButtons[i] != null)
                    PowerCircuitSubButtons[i].enabled = false;
            }
            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = false;
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
        // Filing Cabinet
        if (gs.GetCurrentCam() == "Room2_FilingCabinet" || gs.GetCurrentCam() == "Room2_FilingCabinetLock")
        {
            for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            {
                if (FilingCabinetSubButtons[i] != null)
                    FilingCabinetSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }

            //Setting inside cabinet sub items to true
            if (gs.GetHasUnlockedFilingCabinetLock() == true)
            {
                Debug.Log("FilingCabinetUnlocked");
                for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
                {
                    if (InsideFilingCabinetSubButtons[i] != null)
                    {
                        InsideFilingCabinetSubButtons[i].enabled = true;
                        
                    }
                        
                }
            }

            // Set others to false
            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = false;
            }
            for (int i = 0; i < RockScaleSubButtons.Length; i++)
            {
                if (RockScaleSubButtons[i] != null)
                    RockScaleSubButtons[i].enabled = false;
            }
            for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            {
                if (PowerCircuitSubButtons[i] != null)
                    PowerCircuitSubButtons[i].enabled = false;
            }
            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = false;
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }

        // Power Puzzle
        if (gs.GetCurrentCam() == "Room2_PowerCord")
        {
            for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            {
                if (PowerCircuitSubButtons[i] != null)
                    PowerCircuitSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = false;
            }
            for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            {
                if (FilingCabinetSubButtons[i] != null)
                    FilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
            {
                if (InsideFilingCabinetSubButtons[i] != null)
                    InsideFilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < RockScaleSubButtons.Length; i++)
            {
                if (RockScaleSubButtons[i] != null)
                    RockScaleSubButtons[i].enabled = false;
            }
            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = false;
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }

        if (gs.GetCurrentCam() == "Room2_BoxTable")
        {
            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = false;
            }
            for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            {
                if (FilingCabinetSubButtons[i] != null)
                    FilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
            {
                if (InsideFilingCabinetSubButtons[i] != null)
                    InsideFilingCabinetSubButtons[i].enabled = false;
            }
            for (int i = 0; i < RockScaleSubButtons.Length; i++)
            {
                if (RockScaleSubButtons[i] != null)
                    RockScaleSubButtons[i].enabled = false;
            }
            for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            {
                if (PowerCircuitSubButtons[i] != null)
                    PowerCircuitSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            } 
            //

        }
    }






}
