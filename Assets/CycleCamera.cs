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
    public CinemachineVirtualCamera Room3_Volcano;
    public CinemachineVirtualCamera Room3_GateCode;
    public CinemachineVirtualCamera Room3_Bonus;
    public BoxCollider CabinetCollider;

    public GameState gs;
    public TextMeshProUGUI topText;
    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchCamera()
    {
        if(gs.GetCurrentRoom() == 1)
        {

        }
    }
}
