using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    public GameObject endingMenu;
    public TextMeshProUGUI completionTime;
    public TextMeshProUGUI timerText;
    public GameState gs;
    // Start is called before the first frame update
    void Start()
    {
        endingMenu.gameObject.SetActive(false);
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
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void takeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("CoreShackCompletion.png");
    }
    
}
