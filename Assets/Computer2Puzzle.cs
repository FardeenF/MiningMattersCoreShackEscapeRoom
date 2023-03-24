using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

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

                gs.SetRoom1PasswordPuzzle(true);
            }
            else
            {
                Debug.Log("Incorrect Password");
                Debug.Log(Guessedpassword);
            }
        }
    }
}
