using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public GameState gs;

    public Light room1Main1;
    public Light room1Main2;
    public Light room1CoreTable;
    public Light room2Main;
    public Light room3Main1;
    public Light room3Main2;

    // Start is called before the first frame update
    void Start()
    {
        room1Main1.enabled = true;
        room1Main2.enabled = true;
        room1CoreTable.enabled = true;
        room2Main.enabled = true;
        room3Main1.enabled = false;
        room3Main2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gs.GetCurrentCam() == "Room1_Main")
        {
            room1Main1.enabled = true;
            room1Main2.enabled = true;
            room1CoreTable.enabled = true;
            room2Main.enabled = true;
            room3Main1.enabled = false;
            room3Main2.enabled = false;
        }
        else if(gs.GetCurrentCam() == "Room2_Main")
        {
            room1Main1.enabled = true;
            room1Main2.enabled = true;
            room1CoreTable.enabled = true;
            room2Main.enabled = true;
            room3Main1.enabled = false;
            room3Main2.enabled = false;
        }
        else if (gs.GetCurrentCam() == "Room3_Main")
        {
            room1Main1.enabled = true;
            room1Main2.enabled = true;
            room1CoreTable.enabled = false;
            room2Main.enabled = false;
            room3Main1.enabled = true;
            room3Main2.enabled = true;
        }
    }
}
