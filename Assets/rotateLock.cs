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

    public GameObject Sprayer;
    public AccessibleButton_3D[] Spinners;

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
            topText.text = "You have unlocked the sprayer. Select it to add it to your inventory";
            topText.GetComponent<UAP_BaseElement>().SelectItem();
            gs.SetIsSprayerUnlocked(true);
            soundManager.PlayUnlockSound();

            for(int i = 0; i<Spinners.Length; i++)
            {
                Spinners[i].enabled = false;
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

    public void ReadAccessibilityMessage()
    {
        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().SelectItem(true);
    }

    public void AccessbileRotateLock(GameObject number)
    {
        Quaternion initialRot = number.transform.localRotation;
        number.transform.Rotate(new Vector3(0, 0, -45f), Space.Self);
        soundManager.PlayLockSpinSound();
        
    }

    public void AccessibleLockNumberTracker(int locknum)
    {
        if (locknum == 1)
        {
            number1++;
            if (number1 > 7)
            {
                number1 = 0;
            }
            //locknum = number1;
            ReadAccessibilityMessage(number1.ToString() + " on Spinner " + locknum.ToString() + " Music Lock");
        }
        else if (locknum == 2)
        {
            number2++;
            if (number2 > 7)
            {
                number2 = 0;
            }
            //locknum = number2;
            ReadAccessibilityMessage(number2.ToString() + " on Spinner " + locknum.ToString() + " Music Lock");
        }
        else if (locknum == 3)
        {
            number3++;
            if (number3 > 7)
            {
                number3 = 0;
            }
            //locknum = number3;
            ReadAccessibilityMessage(number3.ToString() + " on Spinner " + locknum.ToString() + " Music Lock");
        }
        else if (locknum == 4)
        {
            number4++;
            if (number4 > 7)
            {
                number4 = 0;
            }
            //locknum = number4;
            ReadAccessibilityMessage(number4.ToString() + " on Spinner " + locknum.ToString() + " Music Lock");
        }
        else if (locknum == 5)
        {
            number5++;
            if (number5 > 7)
            {
                number5 = 0;
            }
            //locknum = number5;
            ReadAccessibilityMessage(number5.ToString() + " on Spinner " + locknum.ToString() + " Music Lock");
        }
        else if (locknum == 6)
        {
            number6++;
            if (number6 > 7)
            {
                number6 = 0;
            }
            //locknum = number6;
            ReadAccessibilityMessage(number6.ToString() + " on Spinner " + locknum.ToString() + " Music Lock");
        }

        Debug.Log(number1.ToString() + number2.ToString() + number3.ToString() + number4.ToString() + number5.ToString() + number6.ToString());
        if (number1.ToString() + number2.ToString() + number3.ToString() + number4.ToString() + number5.ToString() + number6.ToString() == "421243")
        {
            Sprayer.GetComponent<AccessibleButton_3D>().enabled = true;
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
