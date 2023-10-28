using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadButtons : MonoBehaviour
{
    public ToggleAccessibleUIGroups toggle;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && UAP_AccessibilityManager.IsEnabled())
        {
            toggle.Enable3DButtons();
            Debug.Log("Enabled 3D Buttons");
        }
    }
}
