using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralIdentification : MonoBehaviour
{
    public GameObject StreakPlate1;
    public GameObject originalLoc;

    public AudioSource streakTest;
    public Material SPMat;

    private bool hasMoved = false;

    public void AccessibleMoveRocksForStreaks()
    {
        if (hasMoved == false)
        {
            this.gameObject.transform.position = StreakPlate1.transform.position + new Vector3(0, 0.1f, 0);
            StartCoroutine(Streak());
        }
    }


    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && hasMoved == false)
        {
            hasMoved = true;
            this.gameObject.transform.position = StreakPlate1.transform.position + new Vector3(0, 0.1f, 0);
            StartCoroutine(Streak());
            

        }
        
    }


    IEnumerator Streak()
    {
        streakTest.Play();
        StreakPlate1.GetComponent<MeshRenderer>().material = SPMat;
        yield return new WaitForSeconds(2);
        this.gameObject.transform.position = originalLoc.transform.position;
        hasMoved = false;
        StopCoroutine(Streak());




    }
}
