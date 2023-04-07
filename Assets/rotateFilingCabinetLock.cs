using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class rotateFilingCabinetLock : MonoBehaviour
{
    public Camera mainCam;

    public int number1 = 1;
    public int number2 = 1;
    public int number3 = 1;



    private bool isLocked = true;

    public GameState gs;
    public GameObject Lock;

    private bool hasClicked = false;
    public TextMeshProUGUI toptext;

    public GameObject Cabinet;

    public CinemachineVirtualCamera FilingCabinet_VC;
    public CinemachineVirtualCamera FilingCabinetLock_VC;

    public SoundManager soundManager;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && hasClicked == false)
        {
            ShootRaycast();
            hasClicked = true;
        }
        if (Input.GetMouseButtonUp(0) && hasClicked == true)
        {
            hasClicked = false;
        }


        if (isLocked == true)
        {
            if (number1 == 6 &&
            number2 == 3 &&
            number3 == 4)

            {
                gs.SetHasUnlockedFilingCabinetLock(true);

                isLocked = false;
                toptext.text = ("You unlocked the bottom drawers!");
                Cabinet.GetComponent<Animation>().Play(animation: "BottomDrawer");
                soundManager.PlaySuccessSound();

                FilingCabinet_VC.Priority = 1;
                FilingCabinetLock_VC.Priority = 0;

                //Destroy(Lock);
                Debug.Log("CabinetUnLocked");

            }
        }

    }


    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {


            if (hit.transform.gameObject.name == "FC_Number1")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 40), Space.Self);
                number1++;
                if (number1 > 9)
                    number1 = 1;
                soundManager.PlayLockSpinSound();

            }
            else if (hit.transform.gameObject.name == "FC_Number2")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 40), Space.Self);
                number2++;
                if (number2 > 9)
                    number2 = 1;
                soundManager.PlayLockSpinSound();

            }
            else if (hit.transform.gameObject.name == "FC_Number3")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 40), Space.Self);
                number3++;
                if (number3 > 9)
                    number3 = 1;
                soundManager.PlayLockSpinSound();

            }
            


        }

    }
}
