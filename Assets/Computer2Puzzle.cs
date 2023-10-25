using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;
using UnityEngine.EventSystems;

public class Computer2Puzzle : MonoBehaviour
{
    public Camera mainCam;
    //public CinemachineVirtualCamera Computer2Table;
    public GameState gs;


    public Text PasswordLetter1;
    public Text PasswordLetter2;
    public Text PasswordLetter3;
    public Text PasswordLetter4;

    public Canvas room1ComputerScreen;

    public GameObject room1Computer;
    public Material room1SolvedBackground;

    public Material[] computerMats;

    public bool correctPassword = false;

    public string password = "MINE";

    public string Guessedpassword;


    public GameObject[] brokenCores;
    public Material[] solvedMaterials;

    private bool puzzleSolved = false;

    public AccessibleButton_3D sodaliteSecondMessage;

    //34 78 12 45

    private void Awake()
    {
        computerMats = room1Computer.GetComponent<Renderer>().sharedMaterials;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        PasswordLetter1.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };

        PasswordLetter2.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };

        PasswordLetter3.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };

        PasswordLetter4.GetComponentInParent<InputField>().onValidateInput +=
         delegate (string s, int i, char c) { return char.ToUpper(c); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SetPasswordGuess()
    {

        Guessedpassword = PasswordLetter1.text + PasswordLetter2.text + PasswordLetter3.text + PasswordLetter4.text;
    }


    public void CheckPasswordRoom2()
    {
        if (correctPassword == false)
        {
            if (Guessedpassword == password)
            {
                // The correct password was entered on room1 computer.
                Debug.Log("Correct Password");
                correctPassword = true;

                room1ComputerScreen.gameObject.SetActive(false);
                computerMats[2] = room1SolvedBackground;
                room1Computer.GetComponent<Renderer>().sharedMaterials = computerMats;

                gs.SetRoom3PasswordPuzzle(true);

                sodaliteSecondMessage.enabled = true;
                sodaliteSecondMessage.SelectItem();
            }
            else
            {
                gs.SetTopText("Incorrect Password. Try again.");
                gs.GetTopText().GetComponent<AccessibleLabel>().SelectItem();
                Debug.Log("Incorrect Password");
                Debug.Log(Guessedpassword);
            }
        }
    }

    public void GetButtonObjectComputer(AccessibleButton_3D button)
    {
        gs.SetHighlightedObject(button);
        gs.SetTopText("You have entered a number.");
    }

    public void AccessibleSelectPasswordInput()
    {
        if (UAP_AccessibilityManager.IsEnabled())
        {
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<InputField>().ActivateInputField();
            UAP_AccessibilityManager.EnableAccessibility(false);
        }
    }

    public void ReadAccessibilityMessage(string text)
    {

        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().m_Text = text.ToString();

    }

    public void ReadAccessibilityMessage()
    {
        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>().SelectItem(true);
    }

    public void DeselectInputField()
    {
        if (UAP_AccessibilityManager.IsEnabled())
        {
            EventSystem.current.SetSelectedGameObject(null);
            UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleTextEdit>().SelectItem(true);
        }
    }


    public void AccessibleReEnable(string num)
    {
        //if (gs.GetIsAccessibleMain())
        //{
        //    UAP_AccessibilityManager.EnableAccessibility(true);
        //    ReadAccessibilityMessage(gs.GetHighlightedObject().GetComponent<InputField>().text.ToString() + " is entered in Password Letter" + num);
        //    ReadAccessibilityMessage();
        //}

        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleTextEdit>().m_Prefix = "is entered in Password Input" + num;

        //ReadAccessibilityMessage("Password Letter " + num + " Equals " + gs.GetHighlightedObject().GetComponent<InputField>().text);


    }

    


    
}
