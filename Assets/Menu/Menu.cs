using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Scroll;
    public GameObject Controls;
    public GameObject Background;
    public GameObject HighContrast;
    public GameObject ScreenReader;
    public GameState state;
    public GameObject UI;

    private void Awake()
    {
        UAP_AccessibilityManager.EnableAccessibility(false);
    }
    void Start()
    {
        UI.gameObject.SetActive(false);

        if(UAP_AccessibilityManager.IsEnabled())
        {
            ScreenReader.SetActive(true);
            state.SetIsAccessibleMain(true);
        }
        else
        {
            ScreenReader.SetActive(false);
            state.SetIsAccessibleMain(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            state.SetHighContrast(!state.GetHighContrast());
            HighContrast.SetActive(!HighContrast.activeInHierarchy);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //state.SetScreenReader(!state.GetScreenReader());
            ScreenReader.SetActive(!ScreenReader.activeInHierarchy);
            state.SetIsAccessibleMain(!state.GetIsAccessibleMain());
            UAP_AccessibilityManager.EnableAccessibility(!UAP_AccessibilityManager.IsEnabled());
        }

        
    }

    public void Play()
    {
        Main.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(true);
    }
    public void GoBack()
    {
        Main.gameObject.SetActive(true);
        Scroll.gameObject.SetActive(false);
    }
    public void Begin()
    {
        Controls.gameObject.SetActive(true);
        Scroll.gameObject.SetActive(false);
    }
    public void Resume()
    {
        Controls.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        UI.gameObject.SetActive(true);
    }
}
