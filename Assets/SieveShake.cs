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
    
    private string[] isSpotFilledBack = {"Beaker (1)", "Beaker (3)", "Beaker", "Beaker (2)"};
    private string[] isSpotFilledFront = { "Empty", "Empty", "Empty", "Empty" };

    public GameObject SedimentDesk;

    private bool DrawerOpened = false;

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
            if (isSpotFilledFront[0] == ("Beaker") &&
                isSpotFilledFront[1] == ("Beaker (1)") &&
                isSpotFilledFront[2] == ("Beaker (2)") &&
                isSpotFilledFront[3] == ("Beaker (3)"))
            {
                Debug.Log("Drawer Opened!");
                SedimentDesk.GetComponent<Animation>().Play();
                readyToSort = false;
                DrawerOpened = true;
            }
        }
        
        //
        if (isHoldingSediment)
        {
            ItemFollowCam(isHoldingSediment, JarOfSediment, -50);
        }

        

    }

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you collect the PPE Boots
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

    
}