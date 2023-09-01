using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keycodeNumbers : MonoBehaviour
{
    public GameState gs;
    public int number = 0;
    public TextMeshPro passwordText;
    public GameObject gatedoor;
    public AudioSource button;
    public AudioSource unlocked;
    public AudioSource wrong;
    

    public void AccessibleKeyPad()
    {
        if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "ENTER")
        {

            if (passwordText.text == "0923010021")
            {
                Debug.Log("That is correct! You May Enter");
                gatedoor.GetComponent<Animation>().Play();
                gs.SetHasUnlockedStorageRoom(true);
                unlocked.Play();

                gs.GetTopText().text = "You have entered the correct passcode! The storage rack is now available. Place the gold core to store it.";
                gs.GetTopText().gameObject.GetComponent<AccessibleLabel>().SelectItem(true);
            }
            else
            {
                gs.GetTopText().text = passwordText.text + " was the incorrect passcode. Please enter a different passcode.";
                gs.GetTopText().gameObject.GetComponent<AccessibleLabel>().SelectItem(true);

                Debug.Log("Wrong Code, Try Again.");
                wrong.Play();
                passwordText.text = "";
            }
        }
        else if (UAP_AccessibilityManager.GetCurrentFocusObject().name == "CLEAR")
        {
            gs.GetTopText().text = "Current entered numbers have been cleared.";
            gs.GetTopText().gameObject.GetComponent<AccessibleLabel>().SelectItem(true);

            wrong.Play();
            passwordText.text = "";
        }
        else
        {
            passwordText.text += number;
        }
        this.gameObject.GetComponent<Animation>().Play();
        button.Play();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (this.gameObject.name == "ENTER")
            {
                
                if (passwordText.text == "0923010021")
                {
                    Debug.Log("That is correct! You May Enter");
                    gatedoor.GetComponent<Animation>().Play();
                    gs.SetHasUnlockedStorageRoom(true);
                    unlocked.Play();
                }
                else
                {
                    Debug.Log("Wrong Code, Try Again.");
                    wrong.Play();
                    passwordText.text = "";
                }
            }
            else if (this.gameObject.name == "CLEAR")
            {
                wrong.Play();
                passwordText.text = "";
            }
            else
            {
                
                passwordText.text += number;
            }
            this.gameObject.GetComponent<Animation>().Play();
            button.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
