using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class RotateCabinetLock : MonoBehaviour
{
    public Camera mainCam;
    public SoundManager soundManager;

    public int number1 = 1;
    public int number2 = 1;
    public int number3 = 1;
    public int number4 = 1;
    public int number5 = 1;


    private bool isLocked = true;

    public GameState gs;
    public GameObject Lock;

    private bool hasClicked = false;
    public TextMeshProUGUI toptext;

    public GameObject Cabinet;

    public CinemachineVirtualCamera Cabinet_VC;
    public CinemachineVirtualCamera CabinetLock_VC;

    public AudioSource DrawerOpen;

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
            if (number1 == 1 &&
            number2 == 2 &&
            number3 == 5 &&
            number4 == 3 &&
            number5 == 4)
            {             
                gs.SetHasUnlockedCabinetLock(true);
                
                isLocked = false;
                toptext.text = ("You unlocked the bottom drawers!");
                Cabinet.GetComponent<Animation>().Play(animation: "Cube.032|BottomDrawerOpen");
                DrawerOpen.Play();

                Cabinet_VC.Priority = 1;
                CabinetLock_VC.Priority = 0;

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
            

            if (hit.transform.gameObject.name == "Spinner1")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 72), Space.Self);
                number1++;
                if (number1 > 5)
                    number1 = 1;
                soundManager.PlayLockSpinSound();

            }
            else if (hit.transform.gameObject.name == "Spinner2")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 72), Space.Self);
                number2++;
                if (number2 > 5)
                    number2 = 1;
                soundManager.PlayLockSpinSound();

            }
            else if (hit.transform.gameObject.name == "Spinner3")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 72), Space.Self);
                number3++;
                if (number3 > 5)
                    number3 = 1;
                soundManager.PlayLockSpinSound();

            }
            else if (hit.transform.gameObject.name == "Spinner4")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 72), Space.Self);
                number4++;
                if (number4 > 5)
                    number4 = 1;
                soundManager.PlayLockSpinSound();

            }
            else if (hit.transform.gameObject.name == "Spinner5")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, 72), Space.Self);
                number5++;
                if (number5 > 5)
                    number5 = 1;
                soundManager.PlayLockSpinSound();

            }


        }

    }
}
