using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class InteractObject : MonoBehaviour
{
    public CinemachineVirtualCamera WaterHose_VC;
    public Camera mainCam;
    private bool isOn = false;
    public GameState gs;
    public TextMeshProUGUI topText;



    // Update is called once per frame
    void Update()
    {
        if (WaterHose_VC.Priority == 1 && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if you collect the PPE Boots
                if (hit.transform.gameObject.tag == "WaterHoseSwitch")
                {
                    if (isOn == false)
                    {
                        this.gameObject.GetComponent<Animation>().Play(animation: "Toggle");
                        topText.text = "Water for Saw has been turned on!";
                        isOn = true;
                        gs.SetIsWaterOn(true);
                    }
                    else if (isOn == true)
                    {
                        this.gameObject.GetComponent<Animation>().Play(animation: "ToggleBack");
                        topText.text = "Water for Saw has been turned back off!";
                        isOn = false;
                        gs.SetIsWaterOn(false);
                    }

                }
            }
        }
    }
}
