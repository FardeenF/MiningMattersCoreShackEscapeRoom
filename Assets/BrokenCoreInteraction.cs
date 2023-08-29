using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class BrokenCoreInteraction : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineVirtualCamera CoreTableCam;
    public GameState gs;
    public SoundManager soundManager;


    public GameObject[] CorePieceLocations;
    public GameObject[] OriginalCorePieceLocations;
    //public bool[] CurrentTableLocations = { false, false, false, false };
    //public bool[] CurrentGroundLocations = { true, true, true, true };
    private string[] CurrentTableLocations = { "Empty", "Empty", "Empty", "Empty" };
    private string[] CurrentGroundLocations = { "Orange Core Piece", "Red Core Piece", "Yellow Core Piece", "Blue Core Piece" };
    public int index = 0;
    public int index2 = 0;

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

    public AccessibleButton_3D corePiecePasswordMessage;
    public AccessibleButton_3D sodaliteMessage;
    public ToggleAccessibleUIGroups toggle;

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
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }

        if (puzzleSolved == false)
        {
            if (CurrentTableLocations[0] == "Yellow Core Piece" && CurrentTableLocations[1] == "Orange Core Piece" && CurrentTableLocations[2] == "Blue Core Piece" && CurrentTableLocations[3] == "Red Core Piece")
            {
                Debug.Log("Correct Broken Core Order is on Table!");
                for (int i = 0; i < brokenCores.Length; i++)
                {
                    brokenCores[i].GetComponent<Renderer>().material = solvedMaterials[i];
                }
                gs.SetCorePasswordSolved(true);
                toggle.Enable3DButtons();

                gs.SetTopText("The Cores have revealed a password as followed: M, I, N, E");
                gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem(true);

                corePiecePasswordMessage.enabled = true;

                puzzleSolved = true;
                soundManager.PlaySuccessSound();
            }
        }
        
    }

    

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Can only interact with core pieces if user is on the right camera looking at the table
            if (CoreTableCam.Priority > 0 && puzzleSolved == false)
            {
                //Check if you clicked on a core piece
                if (hit.transform.gameObject.tag == "BrokenCore")
                {
                    Debug.Log("Grab Core");
                    for(int i = 0; i < 4; i++)
                    {
                        if(CurrentTableLocations[i] == "Empty")
                        {
                            hit.transform.position = CorePieceLocations[i].transform.position;
                            hit.transform.gameObject.tag = "BrokenCoreOnTable";
                            CurrentTableLocations[i] = hit.transform.gameObject.name;
                            Debug.Log("ACTIVATED!");
                            break;
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (CurrentGroundLocations[i] == hit.transform.gameObject.name)
                        {
                            CurrentGroundLocations[i] = "Empty";
                            break;
                        }
                    }
                }

                //Check if you clicked on a core piece
                else if (hit.transform.gameObject.tag == "BrokenCoreOnTable")
                {
                    Debug.Log("Drop Core");
                    for (int i = 0; i < 4; i++)
                    {
                        if (CurrentGroundLocations[i] == "Empty")
                        {
                            hit.transform.position = OriginalCorePieceLocations[i].transform.position;
                            hit.transform.gameObject.tag = "BrokenCore";
                            CurrentGroundLocations[i] = hit.transform.gameObject.name;
                            break;
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (CurrentTableLocations[i] == hit.transform.gameObject.name)
                        {
                            CurrentTableLocations[i] = "Empty";
                            break;
                        }
                    }

                }
                else
                {
                    Debug.Log(hit.transform.gameObject.tag);
                }
            }
            




        }

    }


    public void GetButtonObject(AccessibleButton_3D button)
    {
        gs.SetHighlightedObject(button);
        //gs.SetTopText("You have moved the " + button.gameObject.name);
        //gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();

    }

    public void MoveCore()
    {
        Debug.Log(gs.GetHighlightedObject().name);
        if (gs.GetHighlightedObject().transform.gameObject.tag == "BrokenCore" && puzzleSolved == false && CoreTableCam.Priority > 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (CurrentTableLocations[i] == "Empty")
                {
                    gs.GetHighlightedObject().transform.position = CorePieceLocations[i].transform.position;
                    gs.GetHighlightedObject().transform.gameObject.tag = "BrokenCoreOnTable";
                    CurrentTableLocations[i] = gs.GetHighlightedObject().transform.gameObject.name;
                    gs.SetTopText("You have moved " + gs.GetHighlightedObject().gameObject.name + " to position " + (i + 1).ToString() + " of the puzzle order.");
                    gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
                    Debug.Log("ACTIVATED!");
                    break;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (CurrentGroundLocations[i] == gs.GetHighlightedObject().transform.gameObject.name)
                {
                    CurrentGroundLocations[i] = "Empty";
                    break;
                }
            }
        }
         //Check if you clicked on a core piece
        else if (gs.GetHighlightedObject().transform.gameObject.tag == "BrokenCoreOnTable" && puzzleSolved == false && CoreTableCam.Priority > 0)
        {
            Debug.Log("Drop Core");
            for (int i = 0; i < 4; i++)
            {
                if (CurrentGroundLocations[i] == "Empty")
                {
                    gs.GetHighlightedObject().transform.position = OriginalCorePieceLocations[i].transform.position;
                    gs.GetHighlightedObject().transform.gameObject.tag = "BrokenCore";
                    CurrentGroundLocations[i] = gs.GetHighlightedObject().transform.gameObject.name;
                    gs.SetTopText("You have moved " + gs.GetHighlightedObject().gameObject.name + " to position " + (i + 1).ToString() + " of the original order.");
                    gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
                    break;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (CurrentTableLocations[i] == gs.GetHighlightedObject().transform.gameObject.name)
                {
                    CurrentTableLocations[i] = "Empty";
                    break;
                }
            }

        }
    }

    public void GetButtonObjectComputer(AccessibleButton_3D button)
    {
        gs.SetHighlightedObject(button);
        gs.SetTopText("You have entered a letter.");
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


    public void AccessibleSelectPasswordInput()
    {
        UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<InputField>().ActivateInputField();
        UAP_AccessibilityManager.EnableAccessibility(false);
    }

    public void AccessibleReEnable(string num)
    {
        if (gs.GetIsAccessibleMain())
        {
            Debug.Log("TRUE!!!");
            UAP_AccessibilityManager.EnableAccessibility(true);
            ReadAccessibilityMessage(gs.GetHighlightedObject().GetComponent<InputField>().text + " is entered in Password Letter" + num);
            ReadAccessibilityMessage();
        }
    }

    public void ReadLetter(string letterNum)
    {
        if (this.gameObject.GetComponent<InputField>().text == "M")
        {
            //ReadAccessibilityMessage("Password Letter " + letterNum + " Equals " + this.gameObject.GetComponent<InputField>().text);
            ReadAccessibilityMessage(gs.GetHighlightedObject().GetComponent<InputField>().text + " is entered in Password Letter" + letterNum);
            ReadAccessibilityMessage();
        }

    }


    public void SetPasswordGuess()
    {

        Guessedpassword = PasswordLetter1.text + PasswordLetter2.text + PasswordLetter3.text + PasswordLetter4.text;
    }


    // Attached to button on computer screen. On Click Event.
    public void CheckPasswordRoom1()
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

                gs.SetRoom1PasswordPuzzle(true);

                soundManager.PlaySuccessSound();

                sodaliteMessage.enabled = true;
                sodaliteMessage.SelectItem();
            }
            else
            {
                Debug.Log("Incorrect Password");
                Debug.Log(Guessedpassword);

                soundManager.PlayIncorrectSound();
            }
        }
    }



   


}
