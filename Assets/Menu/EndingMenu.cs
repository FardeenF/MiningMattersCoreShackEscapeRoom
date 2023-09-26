using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;



public class EndingMenu : MonoBehaviour
{
    public GameObject endingMenu;
    public TextMeshProUGUI completionTime;
    public TextMeshProUGUI timerText;
    public GameState gs;
    public GameObject codeOfEthics;

    public GameObject Crown;
    public GameObject IncompleteCrown;
    public GameObject AccessibilityManager;


    public GameObject isGameOverObject;
    


    // Start is called before the first frame update
    void Start()
    {
        codeOfEthics.SetActive(false);
        endingMenu.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (gs.GetHasFoundSodaLite() == true)
        {
            Crown.SetActive(true);
            IncompleteCrown.SetActive(false);
            GameObject.Find("/Ending Menu/Main/Title/Ending Content").GetComponent<AccessibleLabel>().SelectItem(true);
        }
        else
        {
            Crown.SetActive(false);
            IncompleteCrown.SetActive(true);
            GameObject.Find("/Ending Menu/Main/Title/Ending Content").GetComponent<AccessibleLabel>().SelectItem(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gs.GetEndGame())
        {
            completionTime.text = ("Completion Time: " + timerText.text);
        }

    }

    public void launchWebsite()
    {
        Application.OpenURL("https://miningmatters.ca/about-us");
        Debug.Log("ENDING CLICK!");
    }

    public void restartGame()
    {
        Application.ExternalEval("document.location.reload(true)");
    }


    public void takeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("CoreShackCompletion.png");
    }

    public void GoToCodeOfEthics()
    {
        codeOfEthics.SetActive(true);
        endingMenu.SetActive(false);
    }

    public void ReturnToEndScreen()
    {
        codeOfEthics.SetActive(false);
        endingMenu.SetActive(true);
    }

}
