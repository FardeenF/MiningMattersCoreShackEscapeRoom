using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerTab : MonoBehaviour
{
    public InputField[] letters;
    private int counter = 0;

    public GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && (gs.GetCurrentCam() == "Room1_Computer" || gs.GetCurrentCam() == "Room3_Computer") && UAP_AccessibilityManager.IsEnabled())
        {
            letters[counter].Select();
        }
    }

    public void ChangeLetter()
    {
        if (UAP_AccessibilityManager.IsEnabled())
        {
            counter++;

            if (counter > 3)
            {
                counter = 0;
            }

            if (counter != 0)
                letters[counter].Select();

        }
    }
}
