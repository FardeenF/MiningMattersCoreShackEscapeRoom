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
    public AccessibleUIGroupRoot Room3;
    public AccessibleUIGroupRoot Doors;
    public GameObject mainMenu;
    public GameObject UIMenu;
    public GameObject Room1GO;
    public GameObject Room2GO;
    public GameObject Room3GO;
    public GameObject DoorsGO;

    public GameObject ControlsMenu;

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
    public AccessibleButton_3D[] DirectionalLockSubButtons;

    //Room 2
    public AccessibleButton_3D[] WaterShutOffSubButtons;
    public AccessibleButton_3D[] RockScaleSubButtons;
    public AccessibleButton_3D[] FilingCabinetSubButtons;
    public AccessibleButton_3D[] InsideFilingCabinetSubButtons;
    public AccessibleButton_3D[] DiamondSawSubButtons;
    public AccessibleButton_3D[] PowerCircuitSubButtons;
    public AccessibleButton_3D[] BoxDeskSubButtons;

    //Room 3
    public AccessibleButton_3D[] MineralIdentificationSubButtons;
    public AccessibleButton_3D[] Room3ComputerSubButtons;
    public AccessibleButton_3D[] VolcanoSubButtons;
    public AccessibleButton_3D[] IndustrialCabinetSubButtons;
    public AccessibleButton_3D[] MagnetPenSubButtons;
    public AccessibleButton_3D[] CoreGateSubButtons;
    public AccessibleButton_3D[] BonusSubButtons;

    //Main Locations
    public GameObject[] MainRoom1Locations;
    public GameObject[] MainRoom2Locations;
    public GameObject[] MainRoom3Locations;

    private List<AccessibleButton_3D[]> ButtonGroups = new List<AccessibleButton_3D[]>() {};
    private List<AccessibleButton_3D> AllButtons = new List<AccessibleButton_3D>() { };

    private bool SubItemsEnabled = false;

    public TextMeshProUGUI screenreader;

    public GameObject endScreen;
    public GameObject ethicsScreen;

    public void MoveToRoom3()
    {
        if (gs.GetCurrentRoom() == 1)
        {
            if (gs.GetIsRoom3Unlocked() == false)
            {
                for (int i = 0; i < cameras.Length; i++)
                {
                    cameras[i].Priority = 0;
                }
                cameras[10].Priority = 1;
                gs.SetCurrentCam("Room1_DoorToRoom3");

            }
            else if (gs.GetIsRoom3Unlocked() == true)
            {
                if (gs.GetfoundGoldCore() == true)
                {
                    for (int i = 0; i < cameras.Length; i++)
                    {
                        cameras[i].Priority = 0;
                    }
                    cameras[19].Priority = 1;
                    gs.SetCurrentCam("Room3_Main");
                    gs.SetCurrentRoom(3);
                }
                else
                {
                    TopText.text = ("You do not have a core containing gold");
                }


            }
        }
        else if (gs.GetCurrentRoom() == 3)
        {
            //Move back to room 1
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].Priority = 0;
            }
            cameras[0].Priority = 1;
            gs.SetCurrentCam("Room1_Main");
            gs.SetCurrentRoom(1);
        }
        Debug.Log("Current Room: " + gs.GetCurrentRoom());
    }

    public void MoveToOtherRoom(CinemachineVirtualCamera VC)
    {
        if (gs.GetCurrentRoom() == 1)
        {
            VC = cameras[0];
            //Room2.enabled = false;
            //Room1.enabled = true;
        }
        else if (gs.GetCurrentRoom() == 2)
        {
            VC = cameras[11];
            //Room2.enabled = true;
            //Room1.enabled = false;
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
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
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
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
        }
        else if (gs.GetCurrentRoom() == 3)
        {
            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

            }
            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
            }
        }
        Debug.Log("Current Room:" + gs.GetCurrentRoom());
    }

    private void Start()
    {
        ButtonGroups = new List<AccessibleButton_3D[]>() { BrokenCoreTableSubButtons, SedimentTableSubButtons, CabinetSubButtons, InsideTopCabinetSubButtons, InsideBottomCabinetSubButtons, 
                                                       ComputerDeskSubButtons, DirectionalLockSubButtons, WaterShutOffSubButtons, RockScaleSubButtons, FilingCabinetSubButtons,
                                                       InsideFilingCabinetSubButtons, DiamondSawSubButtons, PowerCircuitSubButtons, BoxDeskSubButtons, MineralIdentificationSubButtons, 
                                                       Room3ComputerSubButtons, VolcanoSubButtons, IndustrialCabinetSubButtons, MagnetPenSubButtons, CoreGateSubButtons, BonusSubButtons };

        foreach (AccessibleButton_3D[] buttons in ButtonGroups)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                AllButtons.Add(buttons[i]);
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            ControlsMenu.SetActive(!ControlsMenu.activeInHierarchy);

            if (ControlsMenu.activeInHierarchy == true)
            {

                GameUI.enabled = false;
                Room1.enabled = false;
                Room2.enabled = false;
                Room3.enabled = false;
                Doors.enabled = false;
            }
            else
            {
                GameUI.enabled = true;
                Room1.enabled = true;
                Room2.enabled = true;
                Room3.enabled = true;
                Doors.enabled = true;
            }
        }

        if (gs.GetEndGame() == true)
        {
            mainMenu.SetActive(false);
            UIMenu.SetActive(false);
            Room1GO.SetActive(false);
            Room2GO.SetActive(false);
            Room3GO.SetActive(false);
            DoorsGO.SetActive(false);
        }

        ToggleUIGroup();
        //CurrentCam(gs.GetCurrentCam());

        if(UAP_AccessibilityManager.IsEnabled())
        {
            gs.SetScreenReader(true);
        }
        else
        {
            gs.SetScreenReader(false);
        }

        if (gs.GetScreenReader())
        {
            screenreader.text = "on";
        }
        else
        {
            screenreader.text = "off";
        }

        if (cameras[0].Priority == 1)
        {
            gs.SetCurrentCam("Room1_Main");

            Room1.m_Priority = 4;
            Room2.m_Priority = 3;
            Room3.m_Priority = 2;

            Room1.enabled = true;
            Room2.enabled = false;
            Room3.enabled = false;
        }
        else if (cameras[11].Priority == 1)
        {
            gs.SetCurrentCam("Room2_Main");

            Room1.m_Priority = 3;
            Room2.m_Priority = 4;
            Room3.m_Priority = 2;

            Room1.enabled = false;
            Room2.enabled = true;
            Room3.enabled = false;
        }
        else if (cameras[19].Priority == 1)
        {
            gs.SetCurrentCam("Room3_Main");

            Room1.m_Priority = 3;
            Room2.m_Priority = 2;
            Room3.m_Priority = 4;

            Room1.enabled = false;
            Room2.enabled = false;
            Room3.enabled = true;
        }

        if(gs.GetCurrentCam() == "Room1_Main" || gs.GetCurrentCam() == "Room2_Main" || gs.GetCurrentCam() == "Room3_Main")
        {
            Doors.enabled = true;
        }
        else
        {
            Doors.enabled = false;
        }

        


        if (gs.GetCurrentCam() == "Room1_Main" && SubItemsEnabled == true) // Toggle off all of the subitems
        {
            foreach (AccessibleButton_3D button in AllButtons)
            {
                if (button != null)
                    button.enabled = false;
            }

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
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                if (MainRoom3Locations[i] != null)
                    MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

                SubItemsEnabled = false;
            }
            //for (int i = 0; i < BrokenCoreTableSubButtons.Length; i++)
            //{
            //    if (BrokenCoreTableSubButtons[i] != null)
            //        BrokenCoreTableSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < ButtonTableSubButtons.Length; i++)
            //{
            //    if (ButtonTableSubButtons[i] != null)
            //        ButtonTableSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < SedimentTableSubButtons.Length; i++)
            //{
            //    if (SedimentTableSubButtons[i] != null)
            //        SedimentTableSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < CabinetSubButtons.Length; i++)
            //{
            //    if (CabinetSubButtons[i] != null)
            //        CabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < InsideTopCabinetSubButtons.Length; i++)
            //{
            //    if (InsideTopCabinetSubButtons[i] != null)
            //        InsideTopCabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < InsideBottomCabinetSubButtons.Length; i++)
            //{
            //    if (InsideBottomCabinetSubButtons[i] != null)
            //        InsideBottomCabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            //{
            //    if (ComputerDeskSubButtons[i] != null)
            //        ComputerDeskSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            //{
            //    if (DirectionalLockSubButtons[i] != null)
            //        DirectionalLockSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < VolcanoSubButtons.Length; i++)
            //{
            //    if (VolcanoSubButtons[i] != null)
            //        VolcanoSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            //{
            //    if (IndustrialCabinetSubButtons[i] != null)
            //        IndustrialCabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < MagnetPenSubButtons.Length; i++)
            //{
            //    if (MagnetPenSubButtons[i] != null)
            //        MagnetPenSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < CoreGateSubButtons.Length; i++)
            //{
            //    if (CoreGateSubButtons[i] != null)
            //        CoreGateSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < BonusSubButtons.Length; i++)
            //{
            //    if (BonusSubButtons[i] != null)
            //        BonusSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            SubItemsEnabled = false;


        }
        //Room 2 disable sub buttons
        if (gs.GetCurrentCam() == "Room2_Main" && SubItemsEnabled == true)
        {
            foreach (AccessibleButton_3D button in AllButtons)
            {
                if (button != null)
                    button.enabled = false;
            }

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
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                if (MainRoom3Locations[i] != null)
                    MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

                SubItemsEnabled = false;
            }



            //for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            //{
            //    if (WaterShutOffSubButtons[i] != null)
            //        WaterShutOffSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < RockScaleSubButtons.Length; i++)
            //{
            //    if (RockScaleSubButtons[i] != null)
            //        RockScaleSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
            //{
            //    if (FilingCabinetSubButtons[i] != null)
            //        FilingCabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < InsideFilingCabinetSubButtons.Length; i++)
            //{
            //    if (InsideFilingCabinetSubButtons[i] != null)
            //        InsideFilingCabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < PowerCircuitSubButtons.Length; i++)
            //{
            //    if (PowerCircuitSubButtons[i] != null)
            //        PowerCircuitSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            //for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            //{
            //    if (BoxDeskSubButtons[i] != null)
            //        BoxDeskSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            //{
            //    if (DirectionalLockSubButtons[i] != null)
            //        DirectionalLockSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}

            SubItemsEnabled = false;
        }

        //Room 3 disable sub buttons
        if (gs.GetCurrentCam() == "Room3_Main" && SubItemsEnabled == true)
        {
            foreach(AccessibleButton_3D button in AllButtons)
            {
                if(button != null)
                    button.enabled = false;
            }

            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                if (MainRoom3Locations[i] != null)
                    MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                if (MainRoom1Locations[i] != null)
                    MainRoom1Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

                SubItemsEnabled = false;
            }

            for (int i = 0; i < MainRoom2Locations.Length; i++)
            {
                if (MainRoom2Locations[i] != null)
                    MainRoom2Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;

                SubItemsEnabled = false;
            }

            //for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            //{
            //    if (DirectionalLockSubButtons[i] != null)
            //        DirectionalLockSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            //{
            //    if (MineralIdentificationSubButtons[i] != null)
            //        MineralIdentificationSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < VolcanoSubButtons.Length; i++)
            //{
            //    if (VolcanoSubButtons[i] != null)
            //        VolcanoSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < CoreGateSubButtons.Length; i++)
            //{
            //    if (CoreGateSubButtons[i] != null)
            //        CoreGateSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < CabinetSubButtons.Length; i++)
            //{
            //    if (CabinetSubButtons[i] != null)
            //        CabinetSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
            //for (int i = 0; i < BonusSubButtons.Length; i++)
            //{
            //    if (BonusSubButtons[i] != null)
            //        BonusSubButtons[i].enabled = false;

            //    SubItemsEnabled = false;
            //}
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
        else if (gs.GetCurrentCam() == "Room3_Main")
        {
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = true;
            }

            for (int i = 0; i < MainRoom1Locations.Length; i++)
            {
                if (MainRoom1Locations[i].name == "Door 2")
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
            //Disable Main Room 3
            for (int i = 0; i < MainRoom3Locations.Length; i++)
            {
                MainRoom3Locations[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
        }


        //if (gs.GetEndGame() == true)
        //{
        //    foreach (AccessibleButton_3D button in AllButtons)
        //    {
        //        if (button != null)
        //            button.enabled = false;
        //    }
        //    Room1.enabled = false;
        //    Room2.enabled = false;
        //    Room3.enabled = false;
        //    Doors.enabled = false;
        //    GameUI.enabled = false;

        //}
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
            for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            {
                if (DirectionalLockSubButtons[i] != null)
                    DirectionalLockSubButtons[i].enabled = false;
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
            for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            {
                if (DirectionalLockSubButtons[i] != null)
                    DirectionalLockSubButtons[i].enabled = false;
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
                if (SedimentTableSubButtons[i].gameObject.name == "Safety Goggles")
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
            for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            {
                if (DirectionalLockSubButtons[i] != null)
                    DirectionalLockSubButtons[i].enabled = false;
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
            for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            {
                if (DirectionalLockSubButtons[i] != null)
                    DirectionalLockSubButtons[i].enabled = false;
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
            for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            {
                if (DirectionalLockSubButtons[i] != null)
                    DirectionalLockSubButtons[i].enabled = false;
            }
            //

        }

        //Door to room 3 directional lock
        else if (gs.GetCurrentCam() == "Room1_DoorToRoom3")
        {
            for (int i = 0; i < DirectionalLockSubButtons.Length; i++)
            {
                if (DirectionalLockSubButtons[i] != null && !gs.GetRoom1PasswordPuzzle())
                {
                    DirectionalLockSubButtons[i].enabled = true;
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
            for (int i = 0; i < ComputerDeskSubButtons.Length; i++)
            {
                if (ComputerDeskSubButtons[i] != null)
                    ComputerDeskSubButtons[i].enabled = false;
            }
            //

        }

        //Water Switch
        if (gs.GetCurrentCam() == "Room2_WaterSwitch")
        {
            for (int i = 0; i < WaterShutOffSubButtons.Length; i++)
            {
                if (WaterShutOffSubButtons[i] != null)
                    WaterShutOffSubButtons[i].enabled = true;

                if(gs.GetIsWaterOn())
                    WaterShutOffSubButtons[i].enabled = false;

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

                for (int i = 0; i < FilingCabinetSubButtons.Length; i++)
                {
                    if (FilingCabinetSubButtons[i] != null)
                        FilingCabinetSubButtons[i].enabled = false;
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

                if(gs.GetSawPower())
                    PowerCircuitSubButtons[i].enabled = false;

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

        //Send/Receive Core Table
        if (gs.GetCurrentCam() == "Room2_BoxTable")
        {
            for (int i = 0; i < BoxDeskSubButtons.Length; i++)
            {
                if (BoxDeskSubButtons[i] != null)
                    BoxDeskSubButtons[i].enabled = false;

                if(gs.GetAnalyzedCore())
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


        //MineralIdentification room3
        if (gs.GetCurrentCam() == "Room3_MineralIdentification")
        {
            for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            {
                if (MineralIdentificationSubButtons[i] != null)
                    MineralIdentificationSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < Room3ComputerSubButtons.Length; i++)
            {
                if (Room3ComputerSubButtons[i] != null)
                    Room3ComputerSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < VolcanoSubButtons.Length; i++)
            {
                if (VolcanoSubButtons[i] != null)
                    VolcanoSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            {
                if (IndustrialCabinetSubButtons[i] != null)
                    IndustrialCabinetSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MagnetPenSubButtons.Length; i++)
            {
                if (MagnetPenSubButtons[i] != null)
                    MagnetPenSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < CoreGateSubButtons.Length; i++)
            {
                if (CoreGateSubButtons[i] != null)
                    CoreGateSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < BonusSubButtons.Length; i++)
            {
                if (BonusSubButtons[i] != null)
                    BonusSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
        if (gs.GetCurrentCam() == "Room3_Computer")
        {
            for (int i = 0; i < Room3ComputerSubButtons.Length; i++)
            {
                if (Room3ComputerSubButtons[i] != null && !gs.GetRoom3PasswordPuzzle())
                    Room3ComputerSubButtons[i].enabled = true;

                if (Room3ComputerSubButtons[i].name == "EmailRead2")
                {
                    Room3ComputerSubButtons[i].enabled = false;
                }

                if (Room3ComputerSubButtons[i].name == "EmailRead2" && gs.GetRoom3PasswordPuzzle())
                {
                    Room3ComputerSubButtons[i].enabled = true;
                }

                SubItemsEnabled = true;

                
            }
            // Set others to false
            for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            {
                if (MineralIdentificationSubButtons[i] != null)
                    MineralIdentificationSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < VolcanoSubButtons.Length; i++)
            {
                if (VolcanoSubButtons[i] != null)
                    VolcanoSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            {
                if (IndustrialCabinetSubButtons[i] != null)
                    IndustrialCabinetSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MagnetPenSubButtons.Length; i++)
            {
                if (MagnetPenSubButtons[i] != null)
                    MagnetPenSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < CoreGateSubButtons.Length; i++)
            {
                if (CoreGateSubButtons[i] != null)
                    CoreGateSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < BonusSubButtons.Length; i++)
            {
                if (BonusSubButtons[i] != null)
                    BonusSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
        if (gs.GetCurrentCam() == "Room3_Volcano")
        {
            for (int i = 0; i < VolcanoSubButtons.Length; i++)
            {
                if (VolcanoSubButtons[i] != null && !gs.GetVolcanoPuzzleSolved())
                    VolcanoSubButtons[i].enabled = true;
                else
                    VolcanoSubButtons[i].enabled = false;

                if (VolcanoSubButtons[i].name == "Diamond")
                {
                    VolcanoSubButtons[i].enabled = false;
                }

                if (VolcanoSubButtons[i].name == "Diamond" && gs.GetVolcanoPuzzleSolved())
                {
                    VolcanoSubButtons[i].enabled = true;
                }

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            {
                if (MineralIdentificationSubButtons[i] != null)
                    MineralIdentificationSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < Room3ComputerSubButtons.Length; i++)
            {
                if (Room3ComputerSubButtons[i] != null)
                    Room3ComputerSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            {
                if (IndustrialCabinetSubButtons[i] != null)
                    IndustrialCabinetSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MagnetPenSubButtons.Length; i++)
            {
                if (MagnetPenSubButtons[i] != null)
                    MagnetPenSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < CoreGateSubButtons.Length; i++)
            {
                if (CoreGateSubButtons[i] != null)
                    CoreGateSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < BonusSubButtons.Length; i++)
            {
                if (BonusSubButtons[i] != null)
                    BonusSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }

        if (gs.GetCurrentCam() == "Room3_Cabinet")
        {
            for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            {
                if (IndustrialCabinetSubButtons[i] != null)
                    IndustrialCabinetSubButtons[i].enabled = true;

                SubItemsEnabled = true;

                if (IndustrialCabinetSubButtons[0].GetComponent<Room3Cabinet>().isOpen)
                {
                    if (MagnetPenSubButtons[0] != null)
                    {
                        MagnetPenSubButtons[0].GetComponent<AccessibleButton_3D>().enabled = true;
                        if (MagnetPenSubButtons[0].gameObject.activeInHierarchy)
                            MagnetPenSubButtons[0].GetComponent<AccessibleButton_3D>().SelectItem(true);
                    }
                        
                }
                else if (IndustrialCabinetSubButtons[0].GetComponent<Room3Cabinet>().isOpen == false)
                {
                    if (MagnetPenSubButtons[0] != null)
                        MagnetPenSubButtons[0].GetComponent<AccessibleButton_3D>().enabled = false;
                }
            }
            // Set others to false
            for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            {
                if (MineralIdentificationSubButtons[i] != null)
                    MineralIdentificationSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < Room3ComputerSubButtons.Length; i++)
            {
                if (Room3ComputerSubButtons[i] != null)
                    Room3ComputerSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < VolcanoSubButtons.Length; i++)
            {
                if (VolcanoSubButtons[i] != null)
                    VolcanoSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < CoreGateSubButtons.Length; i++)
            {
                if (CoreGateSubButtons[i] != null)
                    CoreGateSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < BonusSubButtons.Length; i++)
            {
                if (BonusSubButtons[i] != null)
                    BonusSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
        if (gs.GetCurrentCam() == "Room3_GateCode")
        {
            for (int i = 0; i < CoreGateSubButtons.Length; i++)
            {
                if (CoreGateSubButtons[i] != null)
                    CoreGateSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            {
                if (MineralIdentificationSubButtons[i] != null)
                    MineralIdentificationSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < Room3ComputerSubButtons.Length; i++)
            {
                if (Room3ComputerSubButtons[i] != null)
                    Room3ComputerSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            {
                if (IndustrialCabinetSubButtons[i] != null)
                    IndustrialCabinetSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MagnetPenSubButtons.Length; i++)
            {
                if (MagnetPenSubButtons[i] != null)
                    MagnetPenSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < VolcanoSubButtons.Length; i++)
            {
                if (VolcanoSubButtons[i] != null)
                    VolcanoSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < BonusSubButtons.Length; i++)
            {
                if (BonusSubButtons[i] != null)
                    BonusSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
        if (gs.GetCurrentCam() == "Room3_Bonus")
        {
            for (int i = 0; i < BonusSubButtons.Length; i++)
            {
                if (BonusSubButtons[i] != null)
                    BonusSubButtons[i].enabled = true;

                SubItemsEnabled = true;
            }
            // Set others to false
            for (int i = 0; i < MineralIdentificationSubButtons.Length; i++)
            {
                if (MineralIdentificationSubButtons[i] != null)
                    MineralIdentificationSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < Room3ComputerSubButtons.Length; i++)
            {
                if (Room3ComputerSubButtons[i] != null)
                    Room3ComputerSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < IndustrialCabinetSubButtons.Length; i++)
            {
                if (IndustrialCabinetSubButtons[i] != null)
                    IndustrialCabinetSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < MagnetPenSubButtons.Length; i++)
            {
                if (MagnetPenSubButtons[i] != null)
                    MagnetPenSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < VolcanoSubButtons.Length; i++)
            {
                if (VolcanoSubButtons[i] != null)
                    VolcanoSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            for (int i = 0; i < CoreGateSubButtons.Length; i++)
            {
                if (CoreGateSubButtons[i] != null)
                    CoreGateSubButtons[i].GetComponent<AccessibleButton_3D>().enabled = false;
            }
            //

        }
    }







}
