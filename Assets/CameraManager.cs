using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineVirtualCamera Room1_Main;
    public CinemachineVirtualCamera Room1_Computer;
    public CinemachineVirtualCamera Room1_BrokenCoreShackTable;
    public CinemachineVirtualCamera Room1_Geo_Poster;
    public CinemachineVirtualCamera Room1_CrossSectionPoster;
    public CinemachineVirtualCamera Room1_ButtonTable;
    public CinemachineVirtualCamera Room1_SedimentDesk;
    public CinemachineVirtualCamera Room1_Cabinet;
    public CinemachineVirtualCamera Room1_CabinetLock;
    public CinemachineVirtualCamera Room1_MiningCycle;
    public CinemachineVirtualCamera Room1_DoorToRoom3;

    public CinemachineVirtualCamera Room2_Main;
    public CinemachineVirtualCamera Room2_DiamondSaw;
    public CinemachineVirtualCamera Room2_FilingCabinet;
    public CinemachineVirtualCamera Room2_FilingCabinetLock;
    public CinemachineVirtualCamera Room2_RockSampleDesk;
    public CinemachineVirtualCamera Room2_WaterSwitch;
    public CinemachineVirtualCamera Room2_BoxTable;
    public CinemachineVirtualCamera Room2_PowerCord;

    public CinemachineVirtualCamera Room3_Main;
    public CinemachineVirtualCamera Room3_Computer;
    public CinemachineVirtualCamera Room3_MineralIdentification;
    public CinemachineVirtualCamera Room3_Cabinet;
    public BoxCollider CabinetCollider;

    public GameState gs;
    public TextMeshProUGUI topText;

    // Update is called once per frame
    void Update()
    {
        SwitchCameraPriority();
    }



    


    //This function controls which camera view is currently active
    public void SwitchCameraPriority()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Room1_Computer.Priority == 1)
            {
                Room1_Main.Priority = 1;
                Room1_Computer.Priority = 0;
            }

            else if(Room1_Geo_Poster.Priority == 1)
            {
                Room1_Geo_Poster.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 1;
            }

            else if (Room1_CrossSectionPoster.Priority == 1)
            {
                Room1_CrossSectionPoster.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 1;
            }

            else if (Room1_BrokenCoreShackTable.Priority == 1)
            {
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Main.Priority = 1;
            }

            else if (Room1_ButtonTable.Priority == 1)
            {
                Room1_ButtonTable.Priority = 0;
                Room1_Main.Priority = 1;
            }

            else if (Room1_SedimentDesk.Priority == 1)
            {
                Room1_SedimentDesk.Priority = 0;
                Room1_Main.Priority = 1;
            }

            else if (Room1_Cabinet.Priority == 1)
            {
                Room1_Cabinet.Priority = 0;
                Room1_Main.Priority = 1;
            }

            else if (Room1_CabinetLock.Priority == 1)
            {
                Room1_CabinetLock.Priority = 0;
                Room1_Cabinet.Priority = 1;
            }

            else if (Room1_MiningCycle.Priority == 1)
            {
                Room1_MiningCycle.Priority = 0;
                Room1_Cabinet.Priority = 1;
            }

            else if (Room2_Main.Priority == 1)
            {
                Room2_Main.Priority = 0;
                Room1_Main.Priority = 1;
                topText.text = ("Heading back to room 1");
            }

            else if (Room2_DiamondSaw.Priority == 1)
            {
                Room2_DiamondSaw.Priority = 0;
                Room2_Main.Priority = 1;
            }

            else if (Room2_FilingCabinet.Priority == 1)
            {
                Room2_FilingCabinet.Priority = 0;
                Room2_Main.Priority = 1;
            }

            else if (Room2_FilingCabinetLock.Priority == 1)
            {
                Room2_FilingCabinetLock.Priority = 0;
                Room2_FilingCabinet.Priority = 1;
            }

            else if (Room2_RockSampleDesk.Priority == 1)
            {
                Room2_Main.Priority = 1;
                Room2_RockSampleDesk.Priority = 0;
            }

            else if (Room2_WaterSwitch.Priority == 1)
            {
                Room2_Main.Priority = 1;
                Room2_WaterSwitch.Priority = 0;
            }

            else if (Room2_BoxTable.Priority == 1)
            {
                Room2_Main.Priority = 1;
                Room2_BoxTable.Priority = 0;
            }

            else if(Room2_PowerCord.Priority == 1)
            {
                Room2_Main.Priority = 1;
                Room2_PowerCord.Priority = 0;
            }

            else if (Room1_DoorToRoom3.Priority == 1)
            {
                Room1_Main.Priority = 1;
                Room1_DoorToRoom3.Priority = 0;
            }

            else if (Room3_Main.Priority == 1)
            {
                Room1_Main.Priority = 1;
                Room3_Main.Priority = 0;
            }

            else if (Room3_Computer.Priority == 1)
            {
                Room3_Main.Priority = 1;
                Room3_Computer.Priority = 0;
            }

            else if (Room3_MineralIdentification.Priority == 1)
            {
                Room3_Main.Priority = 1;
                Room3_MineralIdentification.Priority = 0;
            }

            else if (Room3_Cabinet.Priority == 1)
            {
                Room3_Main.Priority = 1;
                Room3_Cabinet.Priority = 0;
                CabinetCollider.enabled = true;
            }
        }

        //Gets reference to gameObject that is clicken on
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }



    }

    //Shoots Raycast to look at object and change the camera
    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you clicked on the Room1 Computer. If you did, switch camera views
            if (hit.transform.gameObject.tag == "Room1_Computer")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 1;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if (hit.transform.gameObject.tag == "Room1_BrokenCoreTable")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 1;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if(Room1_BrokenCoreShackTable.Priority == 1 && hit.transform.gameObject.tag == "Room1_Geo_Poster")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 1;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if (Room1_BrokenCoreShackTable.Priority == 1 && hit.transform.gameObject.tag == "Room1_CrossSectionPoster")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 1;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if (Room1_Main.Priority == 1 && hit.transform.gameObject.tag == "CoreBoxDeskSpace")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 1;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if (Room1_Main.Priority == 1 && hit.transform.gameObject.tag == "SedimentDesk")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 1;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if (Room1_Main.Priority == 1 && hit.transform.gameObject.tag == "Cabinet")
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 1;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
            }

            else if (hit.transform.gameObject.tag == "CabinetLock" && Room1_Cabinet.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 1;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if ((hit.transform.gameObject.tag == "PuzzleLocation" || hit.transform.gameObject.tag == "PuzzlePiece") && Room1_Cabinet.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 1;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if (hit.transform.gameObject.tag == "Door1" && gs.GetHasDustMask() == true && gs.GetHasSafetyGlasses() == true && gs.GetPPEState() == true)
            {
                if (Room1_Main.Priority == 1)
                {
                    Room1_Main.Priority = 0;
                    Room1_BrokenCoreShackTable.Priority = 0;
                    Room1_Computer.Priority = 0;
                    Room1_Geo_Poster.Priority = 0;
                    Room1_CrossSectionPoster.Priority = 0;
                    Room1_ButtonTable.Priority = 0;
                    Room1_SedimentDesk.Priority = 0;
                    Room1_Cabinet.Priority = 0;
                    Room1_CabinetLock.Priority = 0;
                    Room1_MiningCycle.Priority = 0;
                    Room2_Main.Priority = 1;
                    Room2_DiamondSaw.Priority = 0;
                    Room2_FilingCabinet.Priority = 0;
                    Room2_FilingCabinetLock.Priority = 0;
                    Room2_RockSampleDesk.Priority = 0;
                    Room2_WaterSwitch.Priority = 0;
                    Room2_BoxTable.Priority = 0;
                    Room1_DoorToRoom3.Priority = 0;
                    Room3_Main.Priority = 0;
                    Room3_Computer.Priority = 0;
                    Room3_MineralIdentification.Priority = 0;
                    Room3_Cabinet.Priority = 0;
                }
                else if (Room2_Main.Priority == 1)
                {
                    Room1_Main.Priority = 1;
                    Room1_BrokenCoreShackTable.Priority = 0;
                    Room1_Computer.Priority = 0;
                    Room1_Geo_Poster.Priority = 0;
                    Room1_CrossSectionPoster.Priority = 0;
                    Room1_ButtonTable.Priority = 0;
                    Room1_SedimentDesk.Priority = 0;
                    Room1_Cabinet.Priority = 0;
                    Room1_CabinetLock.Priority = 0;
                    Room1_MiningCycle.Priority = 0;
                    Room2_Main.Priority = 0;
                    Room2_DiamondSaw.Priority = 0;
                    Room2_FilingCabinet.Priority = 0;
                    Room2_FilingCabinetLock.Priority = 0;
                    Room2_RockSampleDesk.Priority = 0;
                    Room2_WaterSwitch.Priority = 0;
                    Room2_BoxTable.Priority = 0;
                    Room1_DoorToRoom3.Priority = 0;
                    Room3_Main.Priority = 0;
                    Room3_Computer.Priority = 0;
                    Room3_MineralIdentification.Priority = 0;
                    Room3_Cabinet.Priority = 0;
                }
                
            }

            else if (hit.transform.gameObject.tag == "DiamondSaw" && Room2_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 1;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
                if (gs.GetFixedSawBlade() == false)
                {
                    topText.text = "The diamond saw can be used to cut & inspect cores.";
                }
                else
                {
                    topText.text = "The saw can now be used to examine the contents of cores!";
                }
                
            }

            else if (hit.transform.gameObject.tag == "FilingCabinet" && Room2_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 1;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
                topText.text = "The filing cabinet probably holds something important";
            }

            else if (hit.transform.gameObject.tag == "FilingCabinetLock" && Room2_FilingCabinet.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 1;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if (hit.transform.gameObject.tag == "RockSampleDesk" && Room2_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 1;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if (hit.transform.gameObject.tag == "WaterPipe" && Room2_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 1;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if (hit.transform.gameObject.tag == "BoxTable" && Room2_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 1;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if (hit.transform.gameObject.tag == "PowerCord" && Room2_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room2_PowerCord.Priority = 1;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;

            }

            else if (hit.transform.gameObject.tag == "Door2" && (Room1_Main.Priority == 1 || Room1_DoorToRoom3.Priority == 1))
            {
                if (gs.GetfoundGoldCore() == true && gs.GetIsRoom3Unlocked() == false)
                {
                    Room1_Main.Priority = 0;
                    Room1_BrokenCoreShackTable.Priority = 0;
                    Room1_Computer.Priority = 0;
                    Room1_Geo_Poster.Priority = 0;
                    Room1_CrossSectionPoster.Priority = 0;
                    Room1_ButtonTable.Priority = 0;
                    Room1_SedimentDesk.Priority = 0;
                    Room1_Cabinet.Priority = 0;
                    Room1_CabinetLock.Priority = 0;
                    Room1_MiningCycle.Priority = 0;
                    Room2_Main.Priority = 0;
                    Room2_DiamondSaw.Priority = 0;
                    Room2_FilingCabinet.Priority = 0;
                    Room2_FilingCabinetLock.Priority = 0;
                    Room2_RockSampleDesk.Priority = 0;
                    Room2_WaterSwitch.Priority = 0;
                    Room2_BoxTable.Priority = 0;
                    Room1_DoorToRoom3.Priority = 1;
                    Room3_Main.Priority = 0;
                    Room3_Computer.Priority = 0;
                    Room3_MineralIdentification.Priority = 0;
                    Room3_Cabinet.Priority = 0;
                    topText.text = ("You Have The Necessary Items to Go to This Door!");
                }
                else if (gs.GetIsRoom3Unlocked() == true && gs.GetfoundGoldCore() == true)
                {
                    Room1_Main.Priority = 0;
                    Room1_BrokenCoreShackTable.Priority = 0;
                    Room1_Computer.Priority = 0;
                    Room1_Geo_Poster.Priority = 0;
                    Room1_CrossSectionPoster.Priority = 0;
                    Room1_ButtonTable.Priority = 0;
                    Room1_SedimentDesk.Priority = 0;
                    Room1_Cabinet.Priority = 0;
                    Room1_CabinetLock.Priority = 0;
                    Room1_MiningCycle.Priority = 0;
                    Room2_Main.Priority = 0;
                    Room2_DiamondSaw.Priority = 0;
                    Room2_FilingCabinet.Priority = 0;
                    Room2_FilingCabinetLock.Priority = 0;
                    Room2_RockSampleDesk.Priority = 0;
                    Room2_WaterSwitch.Priority = 0;
                    Room2_BoxTable.Priority = 0;
                    Room1_DoorToRoom3.Priority = 0;
                    Room3_Main.Priority = 1;
                    Room3_Computer.Priority = 0;
                    Room3_MineralIdentification.Priority = 0;
                    Room3_Cabinet.Priority = 0;
                }
                else
                {
                    topText.text = ("You Do Not Have a Gold Core Piece. Send a Core For Examination First.");
                }

            }

            else if (hit.transform.gameObject.name == "Computer2Desk" && Room3_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room2_PowerCord.Priority = 0;
                Room3_Computer.Priority = 1;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 0;
                topText.text = "Enter the correct password to obtain a message from Sodalite";

            }

            else if (hit.transform.gameObject.name == "MineralIdentificationDesk" && Room3_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room2_PowerCord.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 1;
                Room3_Cabinet.Priority = 0;
                topText.text = "Streak Plate Testing Area";

            }

            else if (hit.transform.gameObject.name == "R3IndustrialCabinet_Textured" && Room3_Main.Priority == 1)
            {
                Room1_Main.Priority = 0;
                Room1_BrokenCoreShackTable.Priority = 0;
                Room1_Computer.Priority = 0;
                Room1_Geo_Poster.Priority = 0;
                Room1_CrossSectionPoster.Priority = 0;
                Room1_ButtonTable.Priority = 0;
                Room1_SedimentDesk.Priority = 0;
                Room1_Cabinet.Priority = 0;
                Room1_CabinetLock.Priority = 0;
                Room1_MiningCycle.Priority = 0;
                Room2_Main.Priority = 0;
                Room2_DiamondSaw.Priority = 0;
                Room2_FilingCabinet.Priority = 0;
                Room2_FilingCabinetLock.Priority = 0;
                Room2_RockSampleDesk.Priority = 0;
                Room2_WaterSwitch.Priority = 0;
                Room2_BoxTable.Priority = 0;
                Room1_DoorToRoom3.Priority = 0;
                Room3_Main.Priority = 0;
                Room2_PowerCord.Priority = 0;
                Room3_Computer.Priority = 0;
                Room3_MineralIdentification.Priority = 0;
                Room3_Cabinet.Priority = 1;
                CabinetCollider.enabled = false;
                topText.text = "Supplies Cabinet";

            }

        }

    }


}


