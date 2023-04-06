using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highContrast : MonoBehaviour
{
    public GameObject highContrastEffect;
    public GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gs.GetHighContrast())
        {
            highContrastEffect.SetActive(true);
        }
        else
        {
            highContrastEffect.SetActive(false);
        }
    }
}
