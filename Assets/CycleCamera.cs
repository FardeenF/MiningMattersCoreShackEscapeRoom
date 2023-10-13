using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class CycleCamera : MonoBehaviour
{
    public Camera mainCam;
    
    public CinemachineVirtualCamera[] Room1_Cameras;
    public CinemachineVirtualCamera[] Room2_Cameras;
    public CinemachineVirtualCamera[] Room3_Cameras;

    public GameState gs;
    public TextMeshProUGUI topText;
    //public Button SwitchButton;

    private CinemachineVirtualCamera activeCam;
    private int selectedCam =0;

    public GameObject resultsCoreImage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            switchCamera();
        }

        if (gs.GetCurrentCam() != "Room2_BoxTable")
        {
            resultsCoreImage.SetActive(false);
        }
    }

    public void SetCurrentCameraName()
    {
        //Room 1
        if (Room1_Cameras[0].Priority == 1)
            gs.SetCurrentCam("Room1_Main");
        else if (Room1_Cameras[1].Priority == 1)
            gs.SetCurrentCam("Room1_Computer");
        else if (Room1_Cameras[2].Priority == 1)
            gs.SetCurrentCam("Room1_BrokenCoreShackTable");
        else if (Room1_Cameras[3].Priority == 1)
            gs.SetCurrentCam("Room1_Geo_Poster");
        else if (Room1_Cameras[4].Priority == 1)
            gs.SetCurrentCam("Room1_CrossSectionPoster");
        else if (Room1_Cameras[5].Priority == 1)
            gs.SetCurrentCam("Room1_ButtonTable");
        else if (Room1_Cameras[6].Priority == 1)
            gs.SetCurrentCam("Room1_SedimentDesk");
        else if (Room1_Cameras[7].Priority == 1)
            gs.SetCurrentCam("Room1_Cabinet");
        else if (Room1_Cameras[8].Priority == 1)
            gs.SetCurrentCam("Room1_CabinetLock");
        else if (Room1_Cameras[9].Priority == 1)
            gs.SetCurrentCam("Room1_MiningCycle");
        else if (Room1_Cameras[10].Priority == 1)
            gs.SetCurrentCam("Room1_DoorToRoom3");

        //Room 2
        else if (Room2_Cameras[0].Priority == 1)
            gs.SetCurrentCam("Room2_Main");
        else if (Room2_Cameras[1].Priority == 1)
            gs.SetCurrentCam("Room2_DiamondSaw");
        else if (Room2_Cameras[2].Priority == 1)
            gs.SetCurrentCam("Room2_FilingCabinet");
        else if (Room2_Cameras[3].Priority == 1)
            gs.SetCurrentCam("Room2_FilingCabinetLock");
        else if (Room2_Cameras[4].Priority == 1)
            gs.SetCurrentCam("Room2_RockSampleDesk");
        else if (Room2_Cameras[5].Priority == 1)
            gs.SetCurrentCam("Room2_WaterSwitch");
        else if (Room2_Cameras[6].Priority == 1)
            gs.SetCurrentCam("Room2_BoxTable");
        else if (Room2_Cameras[7].Priority == 1)
            gs.SetCurrentCam("Room2_PowerCord");

        //Room 3
        else if (Room3_Cameras[0].Priority == 1)
            gs.SetCurrentCam("Room3_Main");
        else if (Room3_Cameras[1].Priority == 1)
            gs.SetCurrentCam("Room3_Computer");
        else if (Room3_Cameras[2].Priority == 1)
            gs.SetCurrentCam("Room3_MineralIdentification");
        else if (Room3_Cameras[3].Priority == 1)
            gs.SetCurrentCam("Room3_Cabinet");
        else if (Room3_Cameras[4].Priority == 1)
            gs.SetCurrentCam("Room3_Volcano");
        else if (Room3_Cameras[5].Priority == 1)
            gs.SetCurrentCam("Room3_GateCode");
        else if (Room3_Cameras[6].Priority == 1)
            gs.SetCurrentCam("Room3_Bonus");
    }

    public void BackToMainCam()
    {
        if (gs.GetCurrentRoom() == 1)
        {
            for (int i = 0; i < Room1_Cameras.Length; i++)
            {
                Room1_Cameras[i].Priority = 0;
            }
            Room1_Cameras[0].Priority = 1;
            gs.SetCurrentCam("Room1_Main");
        }
        else if (gs.GetCurrentRoom() == 2)
        {
            for (int i = 0; i < Room2_Cameras.Length; i++)
            {
                Room2_Cameras[i].Priority = 0;
            }
            Room2_Cameras[0].Priority = 1;
            gs.SetCurrentCam("Room2_Main");
        }
        else if (gs.GetCurrentRoom() == 3)
        {
            for (int i = 0; i < Room3_Cameras.Length; i++)
            {
                Room3_Cameras[i].Priority = 0;
            }
            Room3_Cameras[0].Priority = 1;
            gs.SetCurrentCam("Room3_Main");
        }
    }

    public void switchCamera()
    {
        Debug.Log(selectedCam);
        //Room 1
        if (gs.GetCurrentRoom() == 1)
        {
            if (selectedCam >= 10)
            {

                Room1_Cameras[10].Priority = 0;
                Room1_Cameras[0].Priority = 1;
                selectedCam = 0;
            }

            else
            {
                Room1_Cameras[selectedCam].Priority = 0;
                Room1_Cameras[selectedCam + 1].Priority = 1;
                selectedCam++;
            }

            

            Debug.Log(selectedCam);
        }
        //Room 2
        else if (gs.GetCurrentRoom() == 2)
        {
            if (selectedCam >= 7)
            {

                Room2_Cameras[7].Priority = 0;
                Room2_Cameras[0].Priority = 1;
                selectedCam = 0;
            }
            else
            {
                Room2_Cameras[selectedCam].Priority = 0;
                Room2_Cameras[selectedCam + 1].Priority = 1;
                selectedCam++;
            }



            Debug.Log(selectedCam);
        }
        //Room 3
        else if (gs.GetCurrentRoom() == 3)
        {
            if (selectedCam >= 6)
            {

                Room3_Cameras[6].Priority = 0;
                Room3_Cameras[0].Priority = 1;
                selectedCam = 0;
            }
            else
            {
                Room3_Cameras[selectedCam].Priority = 0;
                Room3_Cameras[selectedCam + 1].Priority = 1;
                selectedCam++;
            }



            Debug.Log(selectedCam);
        }
    }
}
