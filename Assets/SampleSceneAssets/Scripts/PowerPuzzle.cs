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

    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;

    public GameState gs;

    public AudioSource source;
    public AudioClip wrong;
    public AudioClip correct;

    private bool h1Active = false;
    private bool h2Active = false;
    private bool h3Active = false;
    private bool h4Active = false;

    // Start is called before the first frame update
    void Start()
    {
        solutionList.Add(p1.transform.position);
        solutionList.Add(p2.transform.position);
        solutionList.Add(p2.transform.position);
        solutionList.Add(p3.transform.position);
        solutionList.Add(p3.transform.position);
        solutionList.Add(p4.transform.position);

        h1.gameObject.SetActive(false);
        h2.gameObject.SetActive(false);
        h3.gameObject.SetActive(false);
        h4.gameObject.SetActive(false);

        h1Active = false;
        h2Active = false;
        h3Active = false;
        h4Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootRaycastHover();

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
                gs.SetSawPower(true);
            }
        }
    }


    public void ShootRaycastHover()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;




        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if(hit.transform.gameObject.tag == "P1")
            {
                h1.gameObject.SetActive(true);
            }
            else
            {
                if(!h1Active)
                    h1.gameObject.SetActive(false);
            }

            if (hit.transform.gameObject.tag == "P2")
            {
                h4.gameObject.SetActive(true);
            }
            else
            {
                if(!h4Active)
                    h4.gameObject.SetActive(false);
            }

            if (hit.transform.gameObject.tag == "P3")
            {
                h2.gameObject.SetActive(true);
            }
            else
            {
                if(!h2Active)
                    h2.gameObject.SetActive(false);
            }

            if (hit.transform.gameObject.tag == "P4")
            {
                h3.gameObject.SetActive(true);
            }
            else
            {
                if(!h3Active)
                    h3.gameObject.SetActive(false);
            }
        }
    }
    

    public void AccessibleSelectPower()
    {
        //Can only interact with puzzle if user is on the right camera looking at the circuit
        if (PowerCordVC.Priority > 0)
        {
            if (changeNow == 0)
            {
                if (goodCount == 0)
                {
                    //Check if you clicked on a wire
                    if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                    {
                        pos1 = UAP_AccessibilityManager.GetCurrentFocusObject().transform.position;
                        posList.Add(pos1);
                        if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1")
                        {
                            h1Active = true;
                            h1.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2")
                        {
                            h4Active = true;
                            h4.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3")
                        {
                            h2Active = true;
                            h2.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                        {
                            h3Active = true;
                            h3.gameObject.SetActive(true);
                        }
                        goodCount++;
                    }
                }
                else
                {
                    //Check if you clicked on a wire
                    if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                    {
                        pos2 = UAP_AccessibilityManager.GetCurrentFocusObject().transform.position;
                        posList.Add(pos2);

                        //points.Add(hit.transform);

                        //line.SetUpLine(points);
                        line.positionCount = 2;
                        line.SetPosition(0, pos1);
                        line.SetPosition(1, pos2);

                        h1.gameObject.SetActive(false);
                        h2.gameObject.SetActive(false);
                        h3.gameObject.SetActive(false);
                        h4.gameObject.SetActive(false);

                        h1Active = false;
                        h2Active = false;
                        h3Active = false;
                        h4Active = false;

                        goodCount = 0;
                        changeNow = 1;
                    }
                }
            }
            else if (changeNow == 1)
            {
                if (goodCount == 0)
                {
                    //Check if you clicked on a wire
                    if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                    {
                        pos1 = UAP_AccessibilityManager.GetCurrentFocusObject().transform.position;
                        posList.Add(pos1);

                        if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1")
                        {
                            h1Active = true;
                            h1.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2")
                        {
                            h4Active = true;
                            h4.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3")
                        {
                            h2Active = true;
                            h2.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                        {
                            h3Active = true;
                            h3.gameObject.SetActive(true);
                        }

                        goodCount++;
                    }
                }
                else
                {
                    //Check if you clicked on a wire
                    if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                    {
                        pos2 = UAP_AccessibilityManager.GetCurrentFocusObject().transform.position;
                        posList.Add(pos2);

                        line2.positionCount = 2;
                        line2.SetPosition(0, pos1);
                        line2.SetPosition(1, pos2);

                        h1.gameObject.SetActive(false);
                        h2.gameObject.SetActive(false);
                        h3.gameObject.SetActive(false);
                        h4.gameObject.SetActive(false);

                        h1Active = false;
                        h2Active = false;
                        h3Active = false;
                        h4Active = false;

                        goodCount = 0;
                        changeNow = 2;
                    }
                }
            }
            else if (changeNow == 2)
            {
                if (goodCount == 0)
                {
                    //Check if you clicked on a wire
                    if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                    {
                        pos1 = UAP_AccessibilityManager.GetCurrentFocusObject().transform.position;
                        posList.Add(pos1);

                        if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1")
                        {
                            h1Active = true;
                            h1.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2")
                        {
                            h4Active = true;
                            h4.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3")
                        {
                            h2Active = true;
                            h2.gameObject.SetActive(true);
                        }
                        else if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                        {
                            h3Active = true;
                            h3.gameObject.SetActive(true);
                        }

                        goodCount++;
                    }
                }
                else
                {
                    //Check if you clicked on a wire
                    if (UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P1" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P2" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P3" || UAP_AccessibilityManager.GetCurrentFocusObject().transform.gameObject.tag == "P4")
                    {
                        pos2 = UAP_AccessibilityManager.GetCurrentFocusObject().transform.position;
                        posList.Add(pos2);

                        line3.positionCount = 2;
                        line3.SetPosition(0, pos1);
                        line3.SetPosition(1, pos2);
                        Debug.Log("There");

                        h1.gameObject.SetActive(false);
                        h2.gameObject.SetActive(false);
                        h3.gameObject.SetActive(false);
                        h4.gameObject.SetActive(false);

                        h1Active = false;
                        h2Active = false;
                        h3Active = false;
                        h4Active = false;

                        StartCoroutine(checkSolution());

                        goodCount = 0;
                        changeNow = 0;
                    }
                }
            }
        }
    }


    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Can only interact with puzzle if user is on the right camera looking at the circuit
            if (PowerCordVC.Priority > 0)
            {
                if (changeNow == 0)
                {
                    if (goodCount == 0)
                    {
                        //Check if you clicked on a wire
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos1 = hit.transform.position;
                            posList.Add(pos1);
                            if(hit.transform.gameObject.tag == "P1")
                            {
                                h1Active = true;
                                h1.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P2")
                            {
                                h4Active = true;
                                h4.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P3")
                            {
                                h2Active = true;
                                h2.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P4")
                            {
                                h3Active = true;
                                h3.gameObject.SetActive(true);
                            }
                            goodCount++;
                        }
                    }
                    else
                    {
                        //Check if you clicked on a wire
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos2 = hit.transform.position;
                            posList.Add(pos2);

                            //points.Add(hit.transform);

                            //line.SetUpLine(points);
                            line.positionCount = 2;
                            line.SetPosition(0, pos1);
                            line.SetPosition(1, pos2);

                            h1.gameObject.SetActive(false);
                            h2.gameObject.SetActive(false);
                            h3.gameObject.SetActive(false);
                            h4.gameObject.SetActive(false);

                            h1Active = false;
                            h2Active = false;
                            h3Active = false;
                            h4Active = false;

                            goodCount = 0;
                            changeNow = 1;
                        }
                    }
                }
                else if(changeNow == 1)
                {
                    if (goodCount == 0)
                    {
                        //Check if you clicked on a wire
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos1 = hit.transform.position;
                            posList.Add(pos1);

                            if (hit.transform.gameObject.tag == "P1")
                            {
                                h1Active = true;
                                h1.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P2")
                            {
                                h4Active = true;
                                h4.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P3")
                            {
                                h2Active = true;
                                h2.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P4")
                            {
                                h3Active = true;
                                h3.gameObject.SetActive(true);
                            }

                            goodCount++;
                        }
                    }
                    else
                    {
                        //Check if you clicked on a wire
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos2 = hit.transform.position;
                            posList.Add(pos2);

                            line2.positionCount = 2;
                            line2.SetPosition(0, pos1);
                            line2.SetPosition(1, pos2);

                            h1.gameObject.SetActive(false);
                            h2.gameObject.SetActive(false);
                            h3.gameObject.SetActive(false);
                            h4.gameObject.SetActive(false);

                            h1Active = false;
                            h2Active = false;
                            h3Active = false;
                            h4Active = false;

                            goodCount = 0;
                            changeNow = 2;
                        }
                    }
                }
                else if (changeNow == 2)
                {
                    if (goodCount == 0)
                    {
                        //Check if you clicked on a wire
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos1 = hit.transform.position;
                            posList.Add(pos1);

                            if (hit.transform.gameObject.tag == "P1")
                            {
                                h1Active = true;
                                h1.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P2")
                            {
                                h4Active = true;
                                h4.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P3")
                            {
                                h2Active = true;
                                h2.gameObject.SetActive(true);
                            }
                            else if (hit.transform.gameObject.tag == "P4")
                            {
                                h3Active = true;
                                h3.gameObject.SetActive(true);
                            }

                            goodCount++;
                        }
                    }
                    else
                    {
                        //Check if you clicked on a wire
                        if (hit.transform.gameObject.tag == "P1" || hit.transform.gameObject.tag == "P2" || hit.transform.gameObject.tag == "P3" || hit.transform.gameObject.tag == "P4")
                        {
                            pos2 = hit.transform.position;
                            posList.Add(pos2);

                            line3.positionCount = 2;
                            line3.SetPosition(0, pos1);
                            line3.SetPosition(1, pos2);
                            Debug.Log("There");

                            h1.gameObject.SetActive(false);
                            h2.gameObject.SetActive(false);
                            h3.gameObject.SetActive(false);
                            h4.gameObject.SetActive(false);

                            h1Active = false;
                            h2Active = false;
                            h3Active = false;
                            h4Active = false;

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
