using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CabinetPuzzlePlacement : MonoBehaviour
{
    public GameObject[] Pieces;
    public GameObject[] PieceLocations;
    public GameState gs;
    private bool checkedPieces = false;
    public int correctPieces = 0;
    private bool puzzleComplete = false;

    public GameObject Cabinet;
    
    private bool wrongbool = false;

    public CinemachineVirtualCamera Cabinet_VC;
    public CinemachineVirtualCamera CabinetPuzzle_VC;

    // Update is called once per frame
    void Update()
    {
        if (gs.GetPlacedAllPieces() == true)
        {
            if (checkedPieces == false)
            {
                for(int i = 0; i < 49; i++)
                {
                    if (Pieces[i].transform.position == PieceLocations[i].transform.position && Pieces[i].activeInHierarchy == true)
                    {
                        correctPieces++;
                    }
                    else
                    {
                        if (wrongbool == false && correctPieces != 0)
                        {
                            Debug.Log("Pieces are not in correct order");
                            correctPieces = 0;
                            
                            break;
                        }
                        
                    }
                }
            }

            if (puzzleComplete == false)
            {
                if (correctPieces == 49)
                {
                    checkedPieces = true;
                    Debug.Log("All pieces are in correct spot");
                    gs.SetJigSawDone(true);
                    puzzleComplete = true;
                    StartCoroutine(WaitTime());
                }
            }
            
            
        }

        
    }


    IEnumerator WaitTime()
    {
        Cabinet.GetComponent<Animation>().Play(animation: "Cube.029|LDoorOpen");
        yield return new WaitForSeconds(0.4f);
        Cabinet.GetComponent<Animation>().Play(animation: "Cube.025|R_DoorOpen");
        Cabinet_VC.Priority = 1;
        CabinetPuzzle_VC.Priority = 0;
        Cabinet.GetComponent<BoxCollider>().enabled = false;
        StopCoroutine(WaitTime());

    }
}
