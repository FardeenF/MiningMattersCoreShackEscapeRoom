using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SieveShake : MonoBehaviour
{
    public Camera mainCam;
    public GameState gs;
    public GameObject SieveInMachine;
    public Image[] Inventory;
    private bool isHoldingSediment = false;
    public GameObject JarOfSediment;
    private bool doneShaking = false;
    private bool readyToSort = false;
    public GameObject sieve1;
    public GameObject sieve2;
    public GameObject sieve3;
    private bool[] moved = {false, false, false, false, false};
    public GameObject[] Filling;

    public GameObject[] OriginalBeakerLocations;
    public GameObject[] NewBeakerLocations;
    
    //private string[] isSpotFilledBack = {"Beaker (1)", "Beaker (3)", "Beaker", "Beaker (2)"};
    private string[] isSpotFilledBack = { "Sand Beaker", "Mud/Clay Beaker", "Gravel Beaker", "Silt Beaker" };
    private string[] isSpotFilledFront = { "Empty", "Empty", "Empty", "Empty" };

    public GameObject SedimentDesk;

    public SoundManager soundManager;

    private bool DrawerOpened = false;

    public AccessibleButton_3D AccessibleSafetyGlassesButton;
    public GameObject beaker1;
    public GameObject beaker2;
    public GameObject beaker3;
    public GameObject beaker4;

    private string beakerLocation;

    public void Update()
    {
        if ((gs.GetIsHoldingSieve() == true || gs.GetHasPlacedSieve() == true) && Input.GetMouseButtonDown(0))
            ShootRaycast();

        else if (Input.GetMouseButtonDown(0) && readyToSort == true)
        {
            
            ShootRaycast();
            
        }
        //
        if (DrawerOpened == false && readyToSort == true)
        {
            if (isSpotFilledFront[0] == ("Gravel Beaker") &&
                isSpotFilledFront[1] == ("Sand Beaker") &&
                isSpotFilledFront[2] == ("Silt Beaker") &&
                isSpotFilledFront[3] == ("Mud/Clay Beaker"))
            {
                Debug.Log("Drawer Opened!");
                SedimentDesk.GetComponent<Animation>().Play();
                readyToSort = false;
                DrawerOpened = true;

                AccessibleSafetyGlassesButton.enabled = true;
                UAP_AccessibilityManager.StopSpeaking();
                gs.SetTopText("The drawer has opened to reveal safety glassses to collect!");
                gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
            }
        }
        
        //
        if (isHoldingSediment)
        {
            ItemFollowCam(isHoldingSediment, JarOfSediment, -50);
        }

        if (readyToSort)
        {
            beaker1.gameObject.GetComponent<AccessibleButton_3D>().name = "Sand Beaker";
            beaker1.GetComponent<AccessibleButton_3D>().m_NameLabel = this.gameObject;
            beaker1.gameObject.GetComponent<AccessibleButton_3D>().m_NameLabel.name = "Sand Beaker";
            beaker1.GetComponent<AccessibleButton_3D>().m_Text = "Sand Beaker";

            beaker2.gameObject.GetComponent<AccessibleButton_3D>().name = "Mud/Clay Beaker";
            beaker2.GetComponent<AccessibleButton_3D>().m_NameLabel = this.gameObject;
            beaker2.gameObject.GetComponent<AccessibleButton_3D>().m_NameLabel.name = "Mud/Clay Beaker";
            beaker2.GetComponent<AccessibleButton_3D>().m_Text = "Mud/Clay Beaker";

            beaker3.gameObject.GetComponent<AccessibleButton_3D>().name = "Gravel Beaker";
            beaker3.GetComponent<AccessibleButton_3D>().m_NameLabel = this.gameObject;
            beaker3.gameObject.GetComponent<AccessibleButton_3D>().m_NameLabel.name = "Gravel Beaker";
            beaker3.GetComponent<AccessibleButton_3D>().m_Text = "Gravel Beaker";

            beaker4.gameObject.GetComponent<AccessibleButton_3D>().name = "Silt Beaker";
            beaker4.GetComponent<AccessibleButton_3D>().m_NameLabel = this.gameObject;
            beaker4.gameObject.GetComponent<AccessibleButton_3D>().m_NameLabel.name = "Silt Beaker";
            beaker4.GetComponent<AccessibleButton_3D>().m_Text = "Silt Beaker";
        }

    }

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you collected the Sieve Shaker
            if (hit.transform.gameObject.tag == "SieveShaker" && gs.GetIsHoldingSieve() == true)
            {
                SieveInMachine.gameObject.SetActive(true);
                
                gs.SetIsHoldingSieve(false);
                gs.SetHasSieve(false);

                foreach (Image item in Inventory)
                {
                    if (item.sprite.name == "SievesImage")
                    {
                        item.sprite = null;
                        break;
                    }
                }

            }
            else if (hit.transform.gameObject.tag == "SedimentJar" && gs.GetHasPlacedSieve() == true)
            {
                isHoldingSediment = true;
                Debug.Log("ClickingOnSediment");
                

            }

            if (isHoldingSediment == true && (hit.transform.gameObject.tag == "SieveShaker" || hit.transform.gameObject.tag == "Sieve") && gs.GetHasPlacedSieve() == true)
            {
                this.gameObject.GetComponent<Animation>().Play();
                soundManager.PlayMachineWorkingSound();
                JarOfSediment.gameObject.SetActive(false);
                Debug.Log("JarOfSediment Placed");
                
                //Sediment to Jar Logic Here
                doneShaking = true;
                StartCoroutine(moveSediment());
            }

            ///Beakers
            if (hit.transform.gameObject.tag == "Beaker" && readyToSort == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (isSpotFilledFront[i] == "Empty")
                    {
                        hit.transform.position = NewBeakerLocations[i].transform.position;
                        hit.transform.gameObject.tag = ("BeakerMoved");
                        isSpotFilledFront[i] = hit.transform.gameObject.name;                     
                        break;
                    }

                }

                for (int i = 0; i < 4; i++)
                {
                    if (isSpotFilledBack[i] == hit.transform.gameObject.name)
                    {
                        isSpotFilledBack[i] = "Empty";
                        break;
                    }
                }

                Debug.Log(isSpotFilledFront[0] + " " +
                isSpotFilledFront[1] + " " +
                isSpotFilledFront[2] + " " +
                isSpotFilledFront[3]);
            }
            ///Beakers 2
            else if (hit.transform.gameObject.tag == "BeakerMoved" && readyToSort == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (isSpotFilledBack[i] == "Empty")
                    {
                        hit.transform.position = OriginalBeakerLocations[i].transform.position;
                        hit.transform.gameObject.tag = ("Beaker");
                        isSpotFilledBack[i] = hit.transform.gameObject.name;

                        break;

                    }
                    
                }

                for (int i = 0; i < 4; i++)
                {
                    if (isSpotFilledFront[i] == hit.transform.gameObject.name)
                    {
                        isSpotFilledFront[i] = "Empty";
                        break;
                    }
                }
            }

            



        }
    }

    IEnumerator moveSediment()
    {
        if (moved[0] == false)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("MovingShakenSediment");
            SieveInMachine.gameObject.transform.localPosition = new Vector3(-0.24598f, -0.06801f, 0.00964f);
            moved[0] = true;
            StopCoroutine(moveSediment());
        }
        if (moved[1] == false)
        {
            yield return new WaitForSeconds(1);
            SieveInMachine.gameObject.transform.localPosition = new Vector3(-0.25089f, -0.06801f, 0.00964f);
            sieve1.SetActive(false);
            Filling[0].SetActive(true);
            moved[1] = true;
            StopCoroutine(moveSediment());
        }
        if (moved[2] == false)
        {
            yield return new WaitForSeconds(1);
            SieveInMachine.gameObject.transform.localPosition = new Vector3(-0.25575f, -0.06801f, 0.00964f);
            sieve2.SetActive(false);
            Filling[1].SetActive(true);
            moved[2] = true;
            StopCoroutine(moveSediment());
        }
        if (moved[3] == false)
        {
            yield return new WaitForSeconds(1);
            SieveInMachine.gameObject.transform.localPosition = new Vector3(-0.26068f, -0.06801f, 0.00964f);
            sieve3.SetActive(false);
            Filling[2].SetActive(true);
            moved[3] = true;
            
            StopCoroutine(moveSediment());
        }
        if (moved[4] == false)
        {
            yield return new WaitForSeconds(1);          
            SieveInMachine.SetActive(false);
            moved[4] = true;
            Filling[3].SetActive(true);
            readyToSort = true;
            doneShaking = false;
            StopCoroutine(moveSediment());
        }


    }

    public void ItemFollowCam(bool isItemActive, GameObject activeItem, int yoffset)
    {
        if (isItemActive == true)
        {
            var mousePos = Input.mousePosition - new Vector3(0, yoffset, 0);
            var camRot = mainCam.transform.localRotation;
            activeItem.transform.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 2.0f));
            activeItem.transform.localRotation = mainCam.transform.localRotation;
        }
    }




    public void PlaceSieveInMachine()
    {
        if (gs.GetHasSieve())
        {
            SieveInMachine.gameObject.SetActive(true);

            gs.SetIsHoldingSieve(false);
            gs.SetHasSieve(false);

            foreach (Image item in Inventory)
            {
                if (item.sprite.name == "SievesImage")
                {
                    item.sprite = null;
                    break;
                }
            }
        }
    }

    public void SedimentJarPlacement()
    {
        isHoldingSediment = true;
        Debug.Log("ClickingOnSediment");
    }


    public void PlaceSedimentInMachine()
    {
        if (isHoldingSediment == true)
        {
            this.gameObject.GetComponent<Animation>().Play();
            soundManager.PlayMachineWorkingSound();
            JarOfSediment.gameObject.SetActive(false);
            Debug.Log("JarOfSediment Placed");

            //Sediment to Jar Logic Here
            doneShaking = true;
            gs.SetTopText("The sediments have been filtered into different beakers.");
            gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
            StartCoroutine(moveSediment());
        }
    }

    public void RenameSedimentBeaker(string sediment)
    {
        //if (readyToSort)
        //{
        //    gs.GetHighlightedObject().gameObject.GetComponent<AccessibleButton_3D>().name = sediment;
        //    gs.GetHighlightedObject().GetComponent<AccessibleButton_3D>().m_NameLabel = this.gameObject;
        //    gs.GetHighlightedObject().gameObject.GetComponent<AccessibleButton_3D>().m_NameLabel.name = sediment;
        //    gs.GetHighlightedObject().GetComponent<AccessibleButton_3D>().m_Text = sediment;
        //}
    }

    public void GetButtonObject(AccessibleButton_3D button)
    {
        gs.SetHighlightedObject(button);
        //gs.SetTopText("You have moved " + button.gameObject.name + " to position " + beakerLocation);
        //gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
        //Debug.Log( + ". You have moved " + button.gameObject.name + " to position " + beakerLocation);
    }



    public void MoveBeaker()
    {
        ///Beakers
        if (gs.GetHighlightedObject().transform.gameObject.tag == "Beaker" && readyToSort == true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (isSpotFilledFront[i] == "Empty")
                {
                    gs.GetHighlightedObject().transform.position = NewBeakerLocations[i].transform.position;
                    gs.GetHighlightedObject().transform.gameObject.tag = ("BeakerMoved");
                    isSpotFilledFront[i] = gs.GetHighlightedObject().transform.gameObject.name;
                    gs.SetTopText("You have moved " + gs.GetHighlightedObject().gameObject.name + " to position " + (i + 1).ToString() + " of the puzzle order.");
                    gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
                    //beakerLocation = i.ToString() + " of the puzzle order.";
                    break;
                }

            }

            for (int i = 0; i < 4; i++)
            {
                if (isSpotFilledBack[i] == gs.GetHighlightedObject().transform.gameObject.name)
                {
                    isSpotFilledBack[i] = "Empty";
                    break;
                }
            }

            Debug.Log(isSpotFilledFront[0] + " " +
            isSpotFilledFront[1] + " " +
            isSpotFilledFront[2] + " " +
            isSpotFilledFront[3]);
        }
        ///Beakers 2
        else if (gs.GetHighlightedObject().transform.gameObject.tag == "BeakerMoved" && readyToSort == true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (isSpotFilledBack[i] == "Empty")
                {
                    gs.GetHighlightedObject().transform.position = OriginalBeakerLocations[i].transform.position;
                    gs.GetHighlightedObject().transform.gameObject.tag = ("Beaker");
                    isSpotFilledBack[i] = gs.GetHighlightedObject().transform.gameObject.name;
                    gs.SetTopText("You have moved " + gs.GetHighlightedObject().gameObject.name + " to position " + (i + 1).ToString() + " of the original order.");
                    gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();
                    //beakerLocation = i.ToString() + " of the original order.";
                    break;

                }

            }

            for (int i = 0; i < 4; i++)
            {
                if (isSpotFilledFront[i] == gs.GetHighlightedObject().transform.gameObject.name)
                {
                    isSpotFilledFront[i] = "Empty";
                    break;
                }
            }
        }
    }

}