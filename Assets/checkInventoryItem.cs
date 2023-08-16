using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;
using TMPro;

public class checkInventoryItem : MonoBehaviour
{
    public Camera mainCam;
    public GameObject buttonPressed;
    public bool holdingSomething = false;
    public GameState gs;
    public TextMeshProUGUI topText;

    //Hand Lens Variables
    public GameObject HandLens;
    public bool isHandLensActive = false;
    private GameObject activeHandLens;

    //Spray Bottle Variables
    public GameObject SprayBottle;
    public bool isSprayBottleActive = false;
    private GameObject activeSprayBottle;

    //Sieve Variables
    public GameObject Sieve;
    public bool isSieveActive = false;
    private GameObject activeSieve;
    public GameObject SieveInShaker;

    //CorePieces2 Variables
    public GameObject[] core2_pieces;

    public CinemachineVirtualCamera VC_brokenCoreTable;

    //Mining Cycle Puzzle Variables
    public List<GameObject> puzzlePieces = new List<GameObject>();
    private bool isHoldingPiece = false;
    private int PieceIndex = 0;
    public CinemachineVirtualCamera VC_MiningCycle_VC;
    public int piecesPlaced = 0;

    //Saw Blade Variables
    public GameObject SawBlade;
    public bool isSawBladeActive = false;
    private GameObject activeSawBlade;
    public GameObject BrokenSawBlade;
    public GameObject NewSawBlade;
    public CinemachineVirtualCamera VC_SawTable;

    //Saw Cores
    public GameObject SawCoreUncut1;
    public GameObject SawCoreUncut2;
    public GameObject SawCoreUncut3;
    public GameObject SawCoreUncut4;

    public GameObject CutCore;
    public GameObject CutCorePiece;

    public CinemachineVirtualCamera VC_SendTable;
    public CinemachineVirtualCamera VC_StorageRack;

    public GameObject CoreInSendBox;
    public GameObject CoreInResultsBox;

    //Magnet Pen Variables
    public GameObject MagnetPen;
    public bool isMagnetPenActive = false;
    private GameObject activeMagnetPen;

    //Core Piece Placement (Room 3)
    public bool isCorePieceActive = false;
    private GameObject activeCorePiece;

    private bool setCorePieceDown = false;
    public GameObject corePieceSpace1;
    public GameObject corePieceSpace2;
    public GameObject corePieceSpace3;
    public GameObject corePieceSpace4;

    public GameObject CoreResults;

    public Material CorrectResult;
    public Material WrongResult1;
    public Material WrongResult2;
    public Material WrongResult3;

    public SoundManager soundManager;

    public GameObject endingScreen;

    public CinemachineBrain cinemachineBrain;

    private bool isZoomed = false;
    private bool isUVLight = false;

    private Vector3 targetPosition = new Vector3();

    public SelectButton sb;

    public CabinetPuzzlePlacement cabinetPuzzleScript;
    

    public void OnInventoryClick()
    {

        buttonPressed = sb.GetSelectButton();
        //buttonPressed = EventSystem.current.currentSelectedGameObject;
        Debug.Log(buttonPressed.name.ToString());

        

        if (buttonPressed.GetComponent<Image>().sprite != null)
        {
            
            if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "HandLens")
            {

                if (isHandLensActive == false && holdingSomething == false)
                {
                    activeHandLens = Instantiate(HandLens, Input.mousePosition, Quaternion.identity);
                    isHandLensActive = true;

                    holdingSomething = true;
                    topText.text = ("Can be used to get a closer look at items");
                    
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }


                else
                {
                    PutAwayButton();
                    if (isHandLensActive == true)
                        Destroy(activeHandLens.gameObject);
                    isHandLensActive = false;
                    holdingSomething = false;
                    topText.text = ("Hand Lens is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }


            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "spraybottle")
            {
                if (isSprayBottleActive == false && holdingSomething == false)
                {
                    activeSprayBottle = Instantiate(SprayBottle, Input.mousePosition, Quaternion.identity);
                    isSprayBottleActive = true;
                    holdingSomething = true;
                    topText.text = ("Click to Spray Water");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                    soundManager.PlayWaterSprayerSound();
                    Debug.Log("PullOutSprayBottle");
                }
                else
                {
                    PutAwayButton();
                    Destroy(activeSprayBottle.gameObject);
                    isSprayBottleActive = false;
                    holdingSomething = false;
                    topText.text = ("Spray Bottle is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                    Debug.Log("PutAwaySprayBottle");
                }
            }

            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "InspectedCore")
            {
                if (VC_brokenCoreTable.Priority > 0)
                {
                    foreach (GameObject core in core2_pieces)
                    {
                        core.SetActive(true);
                        gs.SetSelectedCore2(0);
                        gs.SetIsHoldingWetCore(false);

                    }
                    buttonPressed.GetComponent<Image>().sprite = null;
                    buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                    
                }

                else if (VC_SawTable.Priority > 0 && gs.GetHasPlacedInspectCore() == false)
                {
                    if (gs.GetisSawBladeFixed() == true && gs.GetSawPower() == true && gs.GetIsWaterOn() == true)
                    {
                        // Spawn Core on Saw Blade Location
                        if (gs.GetSelectedCore2() == 1)
                        {
                            SawCoreUncut1.SetActive(true);
                            SawCoreUncut2.SetActive(false);
                            SawCoreUncut3.SetActive(false);
                            SawCoreUncut4.SetActive(false);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }
                        else if (gs.GetSelectedCore2() == 2)
                        {
                            SawCoreUncut1.SetActive(false);
                            SawCoreUncut2.SetActive(true);
                            SawCoreUncut3.SetActive(false);
                            SawCoreUncut4.SetActive(false);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }
                        else if (gs.GetSelectedCore2() == 3)
                        {
                            SawCoreUncut1.SetActive(false);
                            SawCoreUncut2.SetActive(false);
                            SawCoreUncut3.SetActive(true);
                            SawCoreUncut4.SetActive(false);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }
                        else if (gs.GetSelectedCore2() == 4)
                        {
                            SawCoreUncut1.SetActive(false);
                            SawCoreUncut2.SetActive(false);
                            SawCoreUncut3.SetActive(false);
                            SawCoreUncut4.SetActive(true);
                            gs.SetHasPlacedInspectCore(true);
                            gs.SetIsHoldingWetCore(false);
                            buttonPressed.GetComponent<Image>().sprite = null;
                            buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                        }

                        else
                        {
                            Debug.Log("Not holding core");
                        }

                        Debug.Log(gs.GetSawPower() + " " + gs.GetisSawBladeFixed() + " " + gs.GetHasPlacedInspectCore());

                        if (gs.GetSawPower() == true && gs.GetisSawBladeFixed() == true && gs.GetHasPlacedInspectCore() == true && gs.GetIsWaterOn() == true)
                        {
                            //*Play Saw Sound And Cut the Core Here*
                            if (SawCoreUncut1.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                CutCore.GetComponent<AudioSource>().Play();
                                Debug.Log("The core has been cut!");
                                SawCoreUncut1.SetActive(false);
                            }
                            else if (SawCoreUncut2.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                CutCore.GetComponent<AudioSource>().Play();
                                Debug.Log("The core has been cut!");
                                SawCoreUncut2.SetActive(false);
                            }
                            else if (SawCoreUncut3.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                CutCore.GetComponent<AudioSource>().Play();
                                Debug.Log("The core has been cut!");
                                SawCoreUncut3.SetActive(false);
                            }
                            else if (SawCoreUncut4.activeInHierarchy == true)
                            {
                                CutCore.SetActive(true);
                                CutCore.GetComponent<AudioSource>().Play();
                                Debug.Log("The core has been cut!");
                                SawCoreUncut4.SetActive(false);
                            }

                            
                           
                            Debug.Log("Selected Core Reset to 0");
                        }
                    }
                    else
                    {
                        topText.text = ("The water must be on, the saw blade must be fixed, and the power must be turned on.");
                    }
                    
                }

                else
                {
                    topText.text = ("You can't use this item here");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                
            }

            //Sieve
            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "SievesImage")
            {

                if (isSieveActive == false && holdingSomething == false)
                {
                    gs.SetIsHoldingSieve(true);
                    activeSieve = Instantiate(Sieve, Input.mousePosition, Quaternion.identity);
                    isSieveActive = true;
                    holdingSomething = true;
                    topText.text = ("Sieve can be used to sift and seperate sediment");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    PutAwayButton();
                    gs.SetIsHoldingSieve(false);
                    Destroy(activeSieve.gameObject);
                    isSieveActive = false;
                    holdingSomething = false;
                    topText.text = ("Sieve is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }

            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "PuzzleBox")
            {
                if (gs.GetScreenReader() == false)
                {
                    if (isHoldingPiece == false && holdingSomething == false)
                    {
                        if (puzzlePieces.Count > 0 && puzzlePieces != null)
                            PuzzlePiece();
                    }
                    else
                    {
                        PutAwayButton();
                        puzzlePieces[PieceIndex].SetActive(false);
                        holdingSomething = false;
                        isHoldingPiece = false;
                        topText.text = ("Puzzle Piece back in box");
                        topText.GetComponent<UAP_BaseElement>().SelectItem();
                    }
                }

                //If screen reader is enabled do this instead
                else
                {
                    cabinetPuzzleScript.AccessiblePuzzlePlacement();
                    
                }
                
                
            }


            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "SawBlade")
            {
                if (isSawBladeActive == false && holdingSomething == false)
                {
                    gs.SetIsHoldingSawBlade(true);
                    activeSawBlade = Instantiate(SawBlade, Input.mousePosition, Quaternion.identity);
                    isSawBladeActive = true;
                    holdingSomething = true;
                    topText.text = ("Fix the Diamond Cutter");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    PutAwayButton();
                    gs.SetIsHoldingSawBlade(false);
                    Destroy(activeSawBlade.gameObject);
                    isSawBladeActive = false;
                    holdingSomething = false;
                    topText.text = ("Saw Blade back in inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }

            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "InspectCoreCut")
            {
                if (VC_SendTable.Priority == 1)
                {
                    CoreInSendBox.SetActive(true);
                    buttonPressed.GetComponent<Image>().sprite = null;
                    buttonPressed.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 116.0f);
                    gs.SetholdingCutCore(false);
                    StartCoroutine(RecieveCoreResults());
                    holdingSomething = false;
                }
                else if(VC_StorageRack.Priority == 1)
                {
                    if (isCorePieceActive == false && holdingSomething == false)
                    {
                        gs.SetIsHoldingCorePiece(true);
                        activeCorePiece = Instantiate(CutCorePiece, Input.mousePosition, Quaternion.identity);
                        isCorePieceActive = true;
                        holdingSomething = true;
                        topText.text = ("Where should I store this core?");
                        topText.GetComponent<UAP_BaseElement>().SelectItem();
                    }
                    else
                    {
                        PutAwayButton();
                        gs.SetIsHoldingCorePiece(false);
                        Destroy(activeCorePiece.gameObject);
                        isCorePieceActive = false;
                        holdingSomething = false;
                        topText.text = ("Core Piece back in inventory");
                        topText.GetComponent<UAP_BaseElement>().SelectItem();
                    }
                }
                else
                {
                    topText.text = "Be careful with this, it needs to be sent off and examined for gold.";
                }
            }


            else if (buttonPressed.GetComponent<Image>().sprite.name.ToString() == "MagnetPen")
            {
                if (isMagnetPenActive == false && holdingSomething == false)
                {
                    gs.SetHoldingMagnetPen(true);
                    activeMagnetPen = Instantiate(MagnetPen, Input.mousePosition, Quaternion.identity);
                    isMagnetPenActive = true;
                    holdingSomething = true;
                    topText.text = ("Click on mineral to see if its magnetic");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                else
                {
                    PutAwayButton();
                    gs.SetHoldingMagnetPen(false);
                    Destroy(activeMagnetPen.gameObject);
                    isMagnetPenActive = false;
                    holdingSomething = false;
                    topText.text = ("Magnet Pen is Back in Inventory");
                    topText.GetComponent<UAP_BaseElement>().SelectItem();
                }
            }


        }


        



        else
        {
            topText.text = ("You have nothing in this inventory slot.");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }




    }

    public void PuzzlePiece()
    {
        int piece = (int)Random.Range(0, puzzlePieces.Count - 1);
        if (puzzlePieces[piece].activeInHierarchy == false)
        {
            puzzlePieces[piece].SetActive(true);
            Debug.Log("The piece # is: " + piece);
            //puzzlePieces.RemoveAt(piece);
            isHoldingPiece = true;
            holdingSomething = true;
            PieceIndex = piece;
        }
        else
        {
            //PuzzlePiece();
            Debug.Log("Not acceptable piece location in list");
        }
        //Debug.Log(puzzlePieces.Count);
        
    }

    //Put item away using the put away button
    public void PutAwayButton()
    {      
        //Hand Lens       
        if (isHandLensActive == true && holdingSomething)
        {
            Destroy(activeHandLens.gameObject);
            isHandLensActive = false;
            holdingSomething = false;
            topText.text = ("Hand Lens is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        //SprayBottle
        if (isSprayBottleActive == true && holdingSomething)
        {
            Destroy(activeSprayBottle.gameObject);
            isSprayBottleActive = false;
            holdingSomething = false;
            topText.text = ("Spray Bottle is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isSieveActive == true && holdingSomething)
        {
            Destroy(activeSieve.gameObject);
            isSieveActive = false;
            holdingSomething = false;
            topText.text = ("Sieve is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isHoldingPiece == true && holdingSomething)
        {
            puzzlePieces[PieceIndex].SetActive(false);
            for (int i = 0; i < puzzlePieces.Count; i++)
            {
                if (puzzlePieces[i].gameObject.activeInHierarchy)
                {
                    puzzlePieces[i].gameObject.SetActive(false);
                }
            }
            
            holdingSomething = false;
            isHoldingPiece = false;
            topText.text = ("Puzzle Piece back in box");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isSawBladeActive == true && holdingSomething)
        {
            Destroy(activeSawBlade.gameObject);
            isSawBladeActive = false;
            holdingSomething = false;
            topText.text = ("Saw Blade is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }

        if (isMagnetPenActive == true && holdingSomething)
        {
            gs.SetHoldingMagnetPen(false);
            Destroy(activeMagnetPen.gameObject);
            isMagnetPenActive = false;
            holdingSomething = false;
            topText.text = ("Magnet is Back in Inventory");
            topText.GetComponent<UAP_BaseElement>().SelectItem();
        }
    }


    private CinemachineVirtualCamera GetHighestPriorityCamera()
    {
        // Get all virtual cameras in the scene
        CinemachineVirtualCamera[] allCameras = FindObjectsOfType<CinemachineVirtualCamera>();

        if (allCameras.Length == 0)
            return null;

        // Find the virtual camera with the highest priority
        CinemachineVirtualCamera highestPriorityCamera = allCameras[0];
        for (int i = 1; i < allCameras.Length; i++)
        {
            if (allCameras[i].Priority > highestPriorityCamera.Priority)
            {
                highestPriorityCamera = allCameras[i];
            }
        }

        return highestPriorityCamera;
    }


    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
            || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            OnInventoryClick();
        }



        ItemFollowCam(isHandLensActive, activeHandLens, 0, true, 1.0f);
        ItemFollowCam(isSprayBottleActive, activeSprayBottle, 100, true, 2.0f);
        ItemFollowCam(isSieveActive, activeSieve, 0, true, 2.0f);
        if (puzzlePieces.Count > 0)
            ItemFollowCam(isHoldingPiece, puzzlePieces[PieceIndex], 0, false, 0.7f);

        if (BrokenSawBlade.activeInHierarchy == true)
            ItemFollowCam(isSawBladeActive, activeSawBlade, 0, true, 2.0f);
        
        ItemFollowCam(isMagnetPenActive, activeMagnetPen, 0, true, 0.5f);

        ItemFollowCam(isCorePieceActive, activeCorePiece, 0, true, 0.5f);


        if (isHandLensActive)
        {
            if (Input.GetMouseButton(0))
            {
                cinemachineBrain = FindObjectOfType<CinemachineBrain>();

                // Get the highest priority virtual camera
                CinemachineVirtualCamera highestPriorityCamera = GetHighestPriorityCamera();


                // Get the mouse position in screen coordinates
                Vector3 mousePosition = Input.mousePosition;

                // Convert the mouse position to a ray in world space
                Ray ray = mainCam.ScreenPointToRay(mousePosition);

                // Declare a variable to store information about the raycast hit
                RaycastHit hit;

                // Perform the raycast and check if it hit any objects
                if (Physics.Raycast(ray, out hit))
                {
                    // Calculate the distance from the camera to the hit point
                    float distance = Vector3.Distance(highestPriorityCamera.transform.position, hit.point);

                    // Calculate the new field of view based on the distance
                    float targetFOV = Mathf.Clamp(57 - distance * 20, 20, 52);
                    highestPriorityCamera.m_Lens.FieldOfView = Mathf.Lerp(highestPriorityCamera.m_Lens.FieldOfView, targetFOV, Time.deltaTime * 5);

                    // Calculate the new position based on the distance
                    if (isZoomed == false)
                    {
                        targetPosition = highestPriorityCamera.transform.position + ray.direction * 5;
                    }

                    //highestPriorityCamera.transform.position = Vector3.Lerp(highestPriorityCamera.transform.position, targetPosition, Time.deltaTime * 5);
                }
                else
                {
                    // Reset the camera's field of view and position to its default values
                    highestPriorityCamera.m_Lens.FieldOfView = Mathf.Lerp(highestPriorityCamera.m_Lens.FieldOfView, 52, Time.deltaTime * 5);
                    //highestPriorityCamera.transform.position = Vector3.Lerp(highestPriorityCamera.transform.position, Vector3.zero, Time.deltaTime * 5);
                }

                isZoomed = true;

            }
            if (Input.GetMouseButtonUp(0))
            {
                cinemachineBrain = FindObjectOfType<CinemachineBrain>();

                // Get the highest priority virtual camera
                CinemachineVirtualCamera highestPriorityCamera = GetHighestPriorityCamera();

                highestPriorityCamera.m_Lens.FieldOfView = 52.47f;

                isZoomed = false;



            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                //UV Light Toggled
                if (isUVLight == false)
                {
                    activeHandLens.gameObject.GetComponentInChildren<Light>().enabled = true;
                    activeHandLens.gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
                    isUVLight = true;
                }
                    
                else if (isUVLight == true)
                {
                    activeHandLens.gameObject.GetComponentInChildren<Light>().enabled = false;
                    activeHandLens.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
                    isUVLight = false;
                }
                    
            }


            
        }

        


        if (isSieveActive == true)
        {
            if (gs.GetIsHoldingSieve() == false)
            {
                Destroy(activeSieve.gameObject);
                isSieveActive = false;
                topText.text = ("Sieve is in place and ready to sift");
                topText.GetComponent<UAP_BaseElement>().SelectItem();
                gs.SetHasPlacedSieve(true);
                holdingSomething = false;
            }
        }

        //Spray the spray bottle when left click mouse
        if (Input.GetMouseButton(0) && isSprayBottleActive)
        {
            activeSprayBottle.GetComponentInChildren<ParticleSystem>().Play();
        }
        if (Input.GetMouseButtonUp(0) && isSprayBottleActive)
        {
            activeSprayBottle.GetComponentInChildren<ParticleSystem>().Stop();
        }


        //Check if holding saw blade and click broken one
        if (Input.GetMouseButtonDown(0) && isSawBladeActive)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.tag == "BrokenSawBlade")
                {
                    BrokenSawBlade.SetActive(false);
                    NewSawBlade.SetActive(true);
                    gs.SetisSawBladeFixed(true);
                    gs.SetIsHoldingSawBlade(false);
                    gs.SetHasSawBlade(false);
                    Destroy(activeSawBlade);
                    topText.text = "The Blade has been fixed!";
                }
            }
        }


        //Check if holding core piece and clicking storage slot
        if (Input.GetMouseButtonDown(0) && isCorePieceActive)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.tag == "Storage1" && !setCorePieceDown)
                {
                    corePieceSpace1.SetActive(true);
                    gs.SetIsHoldingCorePiece(false);
                    activeCorePiece.SetActive(false);

                    isCorePieceActive = false;
                    holdingSomething = false;
                    setCorePieceDown = true;
                    Debug.Log("Storage 2 Activate.");

                    topText.text = "You've stored the core correctly! YOU WIN!!!";
                    gs.SetEndGame(true);
                    endingScreen.gameObject.SetActive(true);

                }
                else if (hit.transform.gameObject.tag == "Storage2" && !setCorePieceDown)
                {
                    corePieceSpace2.SetActive(true);
                    gs.SetIsHoldingCorePiece(false);
                    activeCorePiece.SetActive(false);

                    isCorePieceActive = false;
                    holdingSomething = false;
                    setCorePieceDown = true;
                    Debug.Log("Storage 2 Activate.");

                    topText.text = "I should probably try a core different slot";
                }
                else if (hit.transform.gameObject.tag == "Storage3" && !setCorePieceDown)
                {
                    corePieceSpace3.SetActive(true);
                    gs.SetIsHoldingCorePiece(false);
                    activeCorePiece.SetActive(false);

                    isCorePieceActive = false;
                    holdingSomething = false;
                    setCorePieceDown = true;

                    topText.text = "I should probably try a core different slot";
                }
                else if (hit.transform.gameObject.tag == "Storage4" && !setCorePieceDown)
                {
                    corePieceSpace4.SetActive(true);
                    gs.SetIsHoldingCorePiece(false);
                    activeCorePiece.SetActive(false);

                    isCorePieceActive = false;
                    holdingSomething = false;
                    setCorePieceDown = true;

                    topText.text = "I should probably try a core different slot";
                }
            }
        }
        else if(Input.GetMouseButtonDown(0) && !isCorePieceActive)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.tag == "Storage2")
                {
                    corePieceSpace2.SetActive(false);
                    activeCorePiece.SetActive(true);
                    gs.SetIsHoldingCorePiece(true);

                    isCorePieceActive = true;
                    holdingSomething = true;
                    setCorePieceDown = false;
                    Debug.Log("Storage 2 Deactivate.");
                    topText.text = "Core Piece back in inventory";
                }
            }
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.tag == "Storage3")
                {
                    corePieceSpace3.SetActive(false);
                    activeCorePiece.SetActive(true);
                    gs.SetIsHoldingCorePiece(true);

                    isCorePieceActive = true;
                    holdingSomething = true;
                    setCorePieceDown = false;
                    topText.text = "Core Piece back in inventory";
                }
            }
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.tag == "Storage4")
                {
                    corePieceSpace4.SetActive(false);
                    activeCorePiece.SetActive(true);
                    gs.SetIsHoldingCorePiece(true);

                    isCorePieceActive = true;
                    holdingSomething = true;
                    setCorePieceDown = false;
                    topText.text = "Core Piece back in inventory";
                }
            }
        }


        //Check if holding saw blade and click broken one
        if (Input.GetMouseButtonDown(0) && gs.GetHoldingMagnetPen() == true)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                //Check if object is magnetic
                if (hit.transform.gameObject.name == "Magnemite")
                {
                    
                    topText.text = "Magnemite is magnetic!";
                }
                else if (hit.transform.gameObject.name == "Hematite")
                {
                    topText.text = "Hematite is weakly magnetic";
                }
                else if (hit.transform.gameObject.name == "Pyrite")
                {
                    topText.text = "Pyrite is weakly magnetic";
                }
                else
                {
                    topText.text = "This is not magnetic! Try something else.";
                }
            }
        }


        //Check if clicking on jigsaw puzzle
        if (Input.GetMouseButtonDown(0) && VC_MiningCycle_VC.Priority == 1 && gs.GetJigSawDone() == false)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.tag == "PuzzleLocation" && isHoldingPiece == true)
                {
                    puzzlePieces[PieceIndex].transform.position = hit.transform.position + new Vector3(0.0f, 0.0f, 0.0f);
                    puzzlePieces[PieceIndex].GetComponent<BoxCollider>().enabled = true;

                    soundManager.PlayPlacePieceSound();

                    puzzlePieces.RemoveAt(PieceIndex);
                    isHoldingPiece = false;
                    holdingSomething = false;
                    Debug.Log("Piece Index: " + PieceIndex);
                    piecesPlaced++;

                    if (piecesPlaced == 49)
                    {
                        gs.SetPlacedAllPieces(true);
                    }
                }

                else if (hit.transform.gameObject.tag == "PuzzlePiece" && isHoldingPiece == false)
                {
                    puzzlePieces.Add(hit.transform.gameObject);
                    hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.transform.gameObject.SetActive(false);
                    isHoldingPiece = false;
                    holdingSomething = false;
                    piecesPlaced--;

                    //pick up picec sound
                    soundManager.PlayPickupSound();

                    if (piecesPlaced < 49)
                    {
                        gs.SetPlacedAllPieces(false);
                    }
                }
            }
        }

        


    }


    public void ItemFollowCam(bool isItemActive, GameObject activeItem, int yoffset, bool followRot, float distance)
    {
        if (isItemActive == true)
        {
            var mousePos = Input.mousePosition - new Vector3(0, yoffset, 0);
            var camRot = mainCam.transform.localRotation;
            activeItem.transform.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
            if (followRot == true)
                activeItem.transform.localRotation = mainCam.transform.localRotation;
        }
    }





    IEnumerator RecieveCoreResults()
    {
        CoreInResultsBox.SetActive(false);
        CoreInSendBox.SetActive(true);
        topText.text = "Core Analysis Sending!";
        yield return new WaitForSeconds(2);
        topText.text = "Core Analysis Recieved!";
        CoreInSendBox.SetActive(false);
        CoreInResultsBox.SetActive(true);

        CoreResults.SetActive(true);
        if (gs.GetSelectedCore2() == 1)
        {
            CoreResults.GetComponent<MeshRenderer>().material = WrongResult1;
        }
        else if (gs.GetSelectedCore2() == 2)
        {
            CoreResults.GetComponent<MeshRenderer>().material = WrongResult2;
        }
        else if (gs.GetSelectedCore2() == 3)
        {
            CoreResults.GetComponent<MeshRenderer>().material = WrongResult3;
        }
        else if (gs.GetSelectedCore2() == 4)
        {
            CoreResults.GetComponent<MeshRenderer>().material = CorrectResult;
        }


        if (gs.GetSelectedCore2() == 4)
        {
            Debug.Log("This core contained the correct amount of gold!");
            gs.SetfoundGoldCore(true);
        }
        else
        {
            Debug.Log("This is fools gold. Check another sample.");
        }
        gs.SetHasPlacedInspectCore(false);
        gs.SetSelectedCore2(0);
        StopCoroutine(RecieveCoreResults());
        
        


    }

}

