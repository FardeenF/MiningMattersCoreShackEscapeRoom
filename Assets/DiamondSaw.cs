using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondSaw : MonoBehaviour
{
    public GameState gs;
    public Image[] Inventory;
    private bool RemovedSaw = false;

    public void Update()
    {
        if (gs.GetisSawBladeFixed() == true && RemovedSaw == false)
        {
            foreach (Image img in Inventory)
            {
                if (img.sprite.name == "SawBlade")
                {
                    img.sprite = null;
                    gs.SetHasSawBlade(false);
                    RemovedSaw = true;
                    break;
                }
            }
        }
    }
}
