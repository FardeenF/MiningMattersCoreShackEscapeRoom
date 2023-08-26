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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            switchCamera();
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
    }
}
