using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PowerPuzzle : MonoBehaviour
{
    public Transform[] points;
    //public LineController line;
    public LineRenderer line;
    public LineRenderer line2;
    public LineRenderer line3;
    public Camera mainCam;
    public CinemachineVirtualCamera PowerCordVC;
    private Vector3 pos1;
    private Vector3 pos2;
    private int goodCount = 0;
    private int changeNow = 0;
    private List<Vector3> posList = new List<Vector3>();
    private List<Vector3> solutionList = new List<Vector3>();

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public GameState gs;

    public AudioSource source;
    public AudioClip wrong;
    public AudioClip correct;

    // Start is called before the first frame update
    void Start()
    {
        solutionList.Add(p1.transform.position);
        solutionList.Add(p2.transform.position);
        solutionList.Add(p2.transform.position);
        solutionList.Add(p3.transform.position);
        solutionList.Add(p3.transform.position);
        solutionList.Add(p4.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }
    }

    IEnumerator checkSolution()
    {
        for (int i = 0; i < posList.Count; i++)
        {
            if (posList[i] != solutionList[i])
            {
                source.PlayOneShot(wrong, 1.0f);
                yield return new WaitForSeconds(1);

                line.positionCount = 0;
                line2.positionCount = 0;
                line3.positionCount = 0;
                posList.Clear();

                goodCount = 0;
                changeNow = 0;

                break;
            }

            if (i == 5)
            {
                //You've won!
                Debug.Log("YOU WIN!!!");
                source.PlayOneShot(correct, 1.0f);
                gs.SetSawPower(true);
            }
        }
    }

    


    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Can only interact with puzzle if user is on the right camera looking at the table
            if (PowerCordVC.Priority > 0)
            {
                if (changeNow == 0)
                {
                    if (goodCount == 0)
                    {
                        //Check if you clicked on a core piece
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos1 = hit.transform.position;
                            posList.Add(pos1);
                            //points.Add(hit.transform);
                            //line.SetUpLine(points);
                            goodCount++;
                        }
                    }
                    else
                    {
                        //Check if you clicked on a core piece
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos2 = hit.transform.position;
                            posList.Add(pos2);

                            //points.Add(hit.transform);

                            //line.SetUpLine(points);
                            line.positionCount = 2;
                            line.SetPosition(0, pos1);
                            line.SetPosition(1, pos2);

                            goodCount = 0;
                            changeNow = 1;
                        }
                    }
                }
                else if(changeNow == 1)
                {
                    if (goodCount == 0)
                    {
                        //Check if you clicked on a core piece
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos1 = hit.transform.position;
                            posList.Add(pos1);
                            //points.Add(hit.transform);
                            //line.SetUpLine(points);
                            Debug.Log("Here");
                            goodCount++;
                        }
                    }
                    else
                    {
                        //Check if you clicked on a core piece
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos2 = hit.transform.position;
                            posList.Add(pos2);

                            //points.Add(hit.transform);

                            //line.SetUpLine(points);
                            line2.positionCount = 2;
                            line2.SetPosition(0, pos1);
                            line2.SetPosition(1, pos2);
                            Debug.Log("There");
                            goodCount = 0;
                            changeNow = 2;
                        }
                    }
                }
                else if (changeNow == 2)
                {
                    if (goodCount == 0)
                    {
                        //Check if you clicked on a core piece
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos1 = hit.transform.position;
                            posList.Add(pos1);
                            //points.Add(hit.transform);
                            //line.SetUpLine(points);
                            Debug.Log("Here");
                            goodCount++;
                        }
                    }
                    else
                    {
                        //Check if you clicked on a core piece
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos2 = hit.transform.position;
                            posList.Add(pos2);

                            //points.Add(hit.transform);

                            //line.SetUpLine(points);
                            line3.positionCount = 2;
                            line3.SetPosition(0, pos1);
                            line3.SetPosition(1, pos2);
                            Debug.Log("There");

                            StartCoroutine(checkSolution());

                            goodCount = 0;
                            changeNow = 0;
                        }
                    }
                }
            }





        }

    }
}
