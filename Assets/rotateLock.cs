using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class rotateLock : MonoBehaviour
{
    public Camera mainCam;
    public bool hasClicked = false;
    public int number1 = 0;
    public int number2 = 0;
    public int number3 = 0;
    public int number4 = 0;
    public int number5 = 0;
    public int number6 = 0;
    public GameState gs;

    public GameObject Lock;
    public TextMeshProUGUI topText;
    public SoundManager soundManager;



    // Start is called before the first frame update
    void Start()
    {
        
    }

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

        //checks if code is correct
        if (number1.ToString() + number2.ToString() + number3.ToString() + number4.ToString() + number5.ToString() + number6.ToString() == "421243" && gs.GetIsSprayerUnlocked() == false)
        {
            Debug.Log("Password Correct");
            Lock.gameObject.GetComponent<Animation>().Play(animation: "Unlock");
            topText.text = "You have unlocked the sprayer. Click on it to add it to your inventory";
            gs.SetIsSprayerUnlocked(true);
            soundManager.PlayUnlockSound();

        }


    }

    


    //Checks if you click on lock number

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you clicked on the Room1 Computer. If you did, switch camera views
            if (hit.transform.gameObject.name == "Number1")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
                soundManager.PlayLockSpinSound();
                //hit.transform.localRotation = initialRot * Quaternion.Euler(hit.transform.localRotation.x, hit.transform.localRotation.y, hit.transform.localRotation.z - 45.0f);
                //Debug.Log(hit.transform.localRotation.z.ToString());
                number1++;
                if (number1 > 7)
                {
                    number1 = 0;
                }
            }

            else if (hit.transform.gameObject.name == "Number2")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
                soundManager.PlayLockSpinSound();
                //hit.transform.localRotation = initialRot * Quaternion.Euler(hit.transform.localRotation.x, hit.transform.localRotation.y, hit.transform.localRotation.z - 45.0f);
                //Debug.Log(hit.transform.localRotation.z.ToString());
                number2++;
                if (number2 > 7)
                {
                    number2 = 0;
                }
            }

            else if (hit.transform.gameObject.name == "Number3")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
                soundManager.PlayLockSpinSound();
                //hit.transform.localRotation = initialRot * Quaternion.Euler(hit.transform.localRotation.x, hit.transform.localRotation.y, hit.transform.localRotation.z - 45.0f);
                //Debug.Log(hit.transform.localRotation.z.ToString());
                number3++;
                if (number3 > 7)
                {
                    number3 = 0;
                }
            }

            else if (hit.transform.gameObject.name == "Number4")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
                soundManager.PlayLockSpinSound();
                //hit.transform.localRotation = initialRot * Quaternion.Euler(hit.transform.localRotation.x, hit.transform.localRotation.y, hit.transform.localRotation.z - 45.0f);
                //Debug.Log(hit.transform.localRotation.z.ToString());
                number4++;
                if (number4 > 7)
                {
                    number4 = 0;
                }
            }

            else if (hit.transform.gameObject.name == "Number5")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
                soundManager.PlayLockSpinSound();
                //hit.transform.localRotation = initialRot * Quaternion.Euler(hit.transform.localRotation.x, hit.transform.localRotation.y, hit.transform.localRotation.z - 45.0f);
                //Debug.Log(hit.transform.localRotation.z.ToString());
                number5++;
                if (number5 > 7)
                {
                    number5 = 0;
                }
            }

            else if (hit.transform.gameObject.name == "Number6")
            {
                Quaternion initialRot = hit.transform.localRotation;
                hit.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
                soundManager.PlayLockSpinSound();
                //hit.transform.localRotation = initialRot * Quaternion.Euler(hit.transform.localRotation.x, hit.transform.localRotation.y, hit.transform.localRotation.z - 45.0f);
                //Debug.Log(hit.transform.localRotation.z.ToString());
                number6++;
                if (number6 > 7)
                {
                    number6 = 0;
                }
            }


        }

    }


}
