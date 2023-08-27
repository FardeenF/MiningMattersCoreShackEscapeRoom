using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    //Main text at top of screen
    public TextMeshProUGUI TopText;
    public GameState gs;
    public string Message;
    public Camera mainCam;

    public Image[] Inventory;
   

    public Sprite itemImage;

    public SoundManager soundManager;

    public GameObject DoorToRoom3;

    //Adding the audio source and a toggle to avoid playback
    //AudioSource audioSource;
    //private bool checkSoundToggle = true;
    


    //If Mouse is over this gameobject
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
            
           
        }
    }

    //Start Method simply for audio init 
    public void Start()
    {
        //Init audio source 
        //audioSource = GetComponent<AudioSource>();
    }

    

    public void AccessibleCollectSprayBottle()
    {
        gs.SetSprayer(true);
        soundManager.PlayPickupSound();
        for (int i = 0; i <= Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null)
            {
                Inventory[i].sprite = itemImage;
                Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                TopText.text = ("You have collected the spray bottle");
                this.gameObject.SetActive(false);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Sprayer";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Sprayer";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Sprayer";
                break;
            }
        }
    }

    public void AccessibleCollectPuzzlePieces()
    {
        gs.SetHasPuzzleBox(true);
        soundManager.PlayPickupSound();
        for (int i = 0; i <= Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null)
            {
                Inventory[i].sprite = itemImage;
                Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                TopText.text = (Message);
                Destroy(this.gameObject);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Box of Puzzle Pieces";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Box of Puzzle Pieces";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Box of Puzzle Pieces";
                break;
            }

        }
    }

    public void AccessibleCollectSieves()
    {
        gs.SetHasSieve(true);
        soundManager.PlayPickupSound();
        for (int i = 0; i <= Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null)
            {
                Inventory[i].sprite = itemImage;
                Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                TopText.text = (Message);
                this.gameObject.SetActive(false);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Sieve";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Sieve";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Sieve";
                break;
            }

        }
    }

    public void AccessibleCollectDustMask()
    {
        gs.SetHasDustMask(true);
        soundManager.PlayPickupSound();
        for (int i = 0; i <= Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null)
            {
                Inventory[i].sprite = itemImage;
                Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                TopText.text = (Message);
                this.gameObject.SetActive(false);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "Dust Mask";
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "Dust Mask";
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "Dust Mask";
                break;
            }
        }
    }


    public void AccessibleCollectPPEBoots()
    {
        gs.SetPPEState(true);
        soundManager.PlayPPESound();
        for (int i = 0; i <= Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null)
            {
                Inventory[i].sprite = itemImage;
                Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                TopText.text = (Message);
                this.gameObject.SetActive(false);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "PPE Boots";
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "PPE Boots";
                Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "PPE Boots";
                break;
            }
        }
    }

    public void AccessibleCollectHandLens()
    {
        gs.SetIsLensUnlocked(true);
        soundManager.PlayPickupSound();
        for (int i = 0; i <= Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null)
            {
                Inventory[i].sprite = itemImage;
                Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                TopText.text = (Message);
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Hand Lens";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Hand Lens";
                Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Hand Lens";
                break;
            }
        }
    }

    public void AccessibleCollectWetCore()
    {
        gs.SetHighlightedObject(this.gameObject.GetComponent<AccessibleButton_3D>());
        Debug.Log(gs.GetHighlightedObject().GetComponent<Renderer>().material.name);
        if (gs.GetHighlightedObject().GetComponent<Renderer>().material.name == ("Sprayed (Instance)") ||
            gs.GetHighlightedObject().GetComponent<Renderer>().material.name == ("Sprayed 1 (Instance)") ||
            gs.GetHighlightedObject().GetComponent<Renderer>().material.name == ("Sprayed 2 (Instance)") ||
            gs.GetHighlightedObject().GetComponent<Renderer>().material.name == ("Sprayed 3 (Instance)"))
        {
            if (gs.GetHighlightedObject().name == "CorePieceToInspect1")
                gs.SetSelectedCore2(1);
            else if (gs.GetHighlightedObject().name == "CorePieceToInspect2")
                gs.SetSelectedCore2(2);
            else if (gs.GetHighlightedObject().name == "CorePieceToInspect3")
                gs.SetSelectedCore2(3);
            else if (gs.GetHighlightedObject().name == "CorePieceToInspect4")
                gs.SetSelectedCore2(4);

            

            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null && gs.GetIsHoldingWetCore() == false)
                {
                    gs.SetIsHoldingWetCore(true);
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Wet Core Piece";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Wet Core Piece";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Wet Core Piece";
                    gs.SetAreCoresWet(true);
                    break;
                }
            }
        }
        else
        {
            TopText.text = ("These cores are too dry. It is hard to tell if its gold or not");
            TopText.GetComponent<UAP_BaseElement>().SelectItem();
        }
    }

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Check if you collect the PPE Boots
            if (hit.transform.gameObject.tag == "PPE_Boots")
            {
                gs.SetPPEState(true);
                soundManager.PlayPPESound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "PPE Boots";
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "PPE Boots";
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "PPE Boots";
                        break;
                    }
                }

                //Plays audio for putting on the PPE Boots
                //if(gs.GetPPEState() == true && checkSoundToggle == true)
                //{
                    //audioSource.Play();
                    //checkSoundToggle = false; //ensures the sound doesn't repeat

                //}
            }

            //Check if you collect the sprayer
            else if (hit.transform.gameObject.tag == "Sprayer" && gs.GetIsSprayerUnlocked() == true)
            {
                gs.SetSprayer(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        this.gameObject.SetActive(false);
                        Debug.Log("Spray Bottle Deactivated in Hierarchy");
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Sprayer";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Sprayer";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Sprayer";
                        break;
                    }
                }
            }

            //Check if you collect the Hand Lens
            else if (hit.transform.gameObject.tag == "HandLens")
            {
                gs.SetIsLensUnlocked(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        //Destroy(this.gameObject);
                        this.gameObject.SetActive(false);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Hand Lens";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Hand Lens";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Hand Lens";
                        break;
                    }
                }
            }


            //Check if you collect the Hand Lens
            else if (hit.transform.gameObject.tag == "InspectCore" && gs.GetIsHoldingWetCore() == false)
            {
                Debug.Log(hit.transform.gameObject.GetComponent<Renderer>().material.name);
                if (hit.transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed (Instance)") || 
                    hit.transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed 1 (Instance)") ||
                    hit.transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed 2 (Instance)") ||
                    hit.transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed 3 (Instance)"))
                {
                    if (hit.transform.gameObject.name == "CorePieceToInspect1")
                        gs.SetSelectedCore2(1);
                    else if (hit.transform.gameObject.name == "CorePieceToInspect2")
                        gs.SetSelectedCore2(2);
                    else if (hit.transform.gameObject.name == "CorePieceToInspect3")
                        gs.SetSelectedCore2(3);
                    else if (hit.transform.gameObject.name == "CorePieceToInspect4")
                        gs.SetSelectedCore2(4);

                    
                    for (int i = 0; i <= Inventory.Length; i++)
                    {
                        if (Inventory[i].sprite == null && gs.GetIsHoldingWetCore() == false)
                        {
                            gs.SetIsHoldingWetCore(true);
                            Inventory[i].sprite = itemImage;
                            Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            TopText.text = (Message);
                            this.gameObject.SetActive(false);
                            TopText.GetComponent<UAP_BaseElement>().SelectItem();
                            Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Wet Core Piece";
                            Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                            Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Wet Core Piece";
                            Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Wet Core Piece";
                            break;
                        }
                    }
                }
                else
                {
                    TopText.text = ("These cores are too dry. It is hard to tell if its gold or not");
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                
            }

            //Inspect Core
            //else if (hit.transform.gameObject.tag == "InspectCore")
            //{
                

            //    for (int i = 0; i <= Inventory.Length; i++)
            //    {
            //        if (Inventory[i].sprite == null)
            //        {
            //            Inventory[i].sprite = itemImage;
            //            Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //            TopText.text = (Message);
            //            Destroy(this.gameObject);
            //            TopText.GetComponent<UAP_BaseElement>().SelectItem();
            //            Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "Dry Core Piece";
            //            break;
            //        }
            //    }
            //}


            //Check if you collect the Sieve
            else if (hit.transform.gameObject.tag == "Sieve" && gs.GetHasPlacedSieve() == false)
            {
                gs.SetHasSieve(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Sieve";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Sieve";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Sieve";
                        break;
                    }
                    
                }
            }


            //Check if you collect the Safety Goggles
            else if (hit.transform.gameObject.tag == "Safety Glasses")
            {
                gs.SetHasSafetyGlasses(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "Safety Glasses";
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "Safety Glasses";
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "Safety Glasses";
                        break;
                    }

                }
            }
            //Switch to room 1 from room 2
            if (hit.transform.gameObject.tag == "Door1" && gs.GetCurrentRoom() == 1)
            {
                if (gs.GetHasDustMask() == true && gs.GetHasSafetyGlasses() == true && gs.GetPPEState() == true)
                {
                    TopText.text = "You have the necessary items to enter this room.";
                    hit.transform.gameObject.GetComponent<Animation>()["Cube|Open"].time = 0.3f;
                    hit.transform.gameObject.GetComponent<Animation>()["Cube|Open"].speed = 0.3f;
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    gs.SetCurrentRoom(2);
                    Debug.Log("Current Room: " + gs.GetCurrentRoom());
                }
                else
                {
                    TopText.text = (Message);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                }
                
            }
            //Switch from room 2 to room 1
            else if (hit.transform.gameObject.tag == "Door1" && gs.GetCurrentRoom() == 2)
            {
                TopText.text = ("Heading back to room 1");
                TopText.GetComponent<UAP_BaseElement>().SelectItem(true);
                gs.SetCurrentRoom(1);
                Debug.Log("Current Room: " + gs.GetCurrentRoom());

            }


            //Check if you collect the Puzzle Box
            else if (hit.transform.gameObject.tag == "PuzzleBox" && gs.GetHasPuzzleBox() == false)
            {
                gs.SetHasPuzzleBox(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Box of Puzzle Pieces";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Box of Puzzle Pieces";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Box of Puzzle Pieces";
                        break;
                    }

                }
            }


            //Check if you collect the Dust Mask
            if (hit.transform.gameObject.tag == "DustMask")
            {
                gs.SetHasDustMask(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "Dust Mask";
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "Dust Mask";
                        Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "Dust Mask";
                        break;
                    }
                }

                
            }

            //Check if you collect the Saw Blade
            if (hit.transform.gameObject.tag == "NewSawBlade")
            {
                gs.SetHasSawBlade(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Saw Blade";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Saw Blade";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Saw Blade";
                        break;
                    }
                }


            }

            //Check if you collect the click on the cut core piece in saw
            if (hit.transform.gameObject.name == "InspectedCutCore")
            {
                gs.SetholdingCutCore(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        this.gameObject.SetActive(false);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Cut Core Piece";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Cut Core Piece";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Cut Core Piece";
                        break;
                    }
                }


            }


            if (hit.transform.gameObject.name == "ResultsCutCore" && gs.GetfoundGoldCore() == true)
            {
                gs.SetholdingCutCore(true);
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = "Core has been collected.";
                        this.gameObject.SetActive(false);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Cut Core Piece";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Cut Core Piece";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Cut Core Piece";
                        break;
                    }
                }


            }


            if (hit.transform.gameObject.name == "sodaLiteRock_textured" && gs.GetHasFoundSodaLite() == false)
            {

                Debug.Log("Display Dragon Code of Ethics now");
                TopText.text = ("You Have Found the Code of Ethics Easter egg!");
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                gs.SetHasFoundSodaLite(true);
                

            }


            //Switch to room 1 and 3
            if (hit.transform.gameObject.tag == "Door2" && gs.GetCurrentRoom() == 1)
            {
                if (gs.GetfoundGoldCore() == true && gs.GetIsRoom3Unlocked() == false)
                {
                    TopText.text = "You have the necessary items to enter this room.";
                    
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();

                }
                else if (gs.GetfoundGoldCore() == true && gs.GetIsRoom3Unlocked() == true)
                {
                    TopText.text = "You Can Now Enter This Room!";
                    hit.transform.gameObject.GetComponent<Animation>()["Cube|Open"].time = 0.3f;
                    hit.transform.gameObject.GetComponent<Animation>()["Cube|Open"].speed = 0.3f;
                    hit.transform.gameObject.GetComponent<Animation>().Play();
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();

                    gs.SetCurrentRoom(3);
                    Debug.Log("Current Room: " + gs.GetCurrentRoom());
                }
                else
                {
                    TopText.text = (Message);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                }

            }
            //Switch from room 2 to room 1
            else if (hit.transform.gameObject.tag == "Door2" && gs.GetCurrentRoom() == 3)
            {
                TopText.text = ("Heading back to room 1");
                TopText.GetComponent<UAP_BaseElement>().SelectItem(true);
                gs.SetCurrentRoom(1);
                Debug.Log("Current Room: " + gs.GetCurrentRoom());

            }

            //Check if you collect the Magnet Pen
            if (hit.transform.gameObject.name == "MagnetPen")
            {
                gs.SetHasMagnetPen(true);
                soundManager.PlayPickupSound();
                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null)
                    {
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        Destroy(this.gameObject);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Magnet Pen";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Magnet Pen";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Magnet Pen";
                        break;
                    }
                }


            }


        }

        //Check if you collect the Magnet Pen
        //if (hit.transform.gameObject.name == "MagnetPen")
        //{
        //    gs.SetHasMagnetPen(true);
        //    soundManager.PlayPickupSound();
        //    for (int i = 0; i <= Inventory.Length; i++)
        //    {
        //        if (Inventory[i].sprite == null)
        //        {
        //            Inventory[i].sprite = itemImage;
        //            Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //            TopText.text = (Message);
        //            Destroy(this.gameObject);
        //            TopText.GetComponent<UAP_BaseElement>().SelectItem();
        //            Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Magnet Pen";
        //            Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
        //            Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Magnet Pen";
        //            Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Magnet Pen";
        //            break;
        //        }
        //    }


        //}

    }


    public void GetButtonObject(AccessibleButton_3D button)
    {
        gs.SetHighlightedObject(button);
        gs.SetTopText("Interacted with " + button.gameObject.name);
        gs.GetTopText().GetComponent<UAP_BaseElement>().SelectItem();

    }

    public void AccessibleCollectItem(string item)
    {
        //Check if you collect the PPE Boots
        if (item == "PPE_Boots")
        {
            gs.SetPPEState(true);
            soundManager.PlayPPESound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    Destroy(this.gameObject);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "PPE Boots";
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "PPE Boots";
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "PPE Boots";
                    break;
                }
            }
        }

        //Check if you collect the sprayer
        else if (item == "Sprayer" && gs.GetIsSprayerUnlocked() == true)
        {
            gs.SetSprayer(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    Destroy(this.gameObject);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Sprayer";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Sprayer";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Sprayer";
                    break;
                }
            }
        }

        //Check if you collect the Hand Lens
        else if (item == "HandLens")
        {
            gs.SetIsLensUnlocked(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Hand Lens";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Hand Lens";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Hand Lens";
                    break;
                }
            }
        }


        //Check if you collect the Hand Lens
        else if (item == "InspectCore" && gs.GetIsHoldingWetCore() == false)
        {
            Debug.Log(gs.GetHighlightedObject().transform.gameObject.GetComponent<Renderer>().material.name);
            if (gs.GetHighlightedObject().transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed (Instance)") ||
                gs.GetHighlightedObject().transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed 1 (Instance)") ||
                gs.GetHighlightedObject().transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed 2 (Instance)") ||
                gs.GetHighlightedObject().transform.gameObject.GetComponent<Renderer>().material.name == ("Sprayed 3 (Instance)"))
            {
                if (gs.GetHighlightedObject().transform.gameObject.name == "CorePieceToInspect1")
                    gs.SetSelectedCore2(1);
                else if (gs.GetHighlightedObject().transform.gameObject.name == "CorePieceToInspect2")
                    gs.SetSelectedCore2(2);
                else if (gs.GetHighlightedObject().transform.gameObject.name == "CorePieceToInspect3")
                    gs.SetSelectedCore2(3);
                else if (gs.GetHighlightedObject().transform.gameObject.name == "CorePieceToInspect4")
                    gs.SetSelectedCore2(4);


                for (int i = 0; i <= Inventory.Length; i++)
                {
                    if (Inventory[i].sprite == null && gs.GetIsHoldingWetCore() == false)
                    {
                        gs.SetIsHoldingWetCore(true);
                        Inventory[i].sprite = itemImage;
                        Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        TopText.text = (Message);
                        this.gameObject.SetActive(false);
                        TopText.GetComponent<UAP_BaseElement>().SelectItem();
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Wet Core Piece";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Wet Core Piece";
                        Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Wet Core Piece";
                        break;
                    }
                }
            }
            else
            {
                TopText.text = ("These cores are too dry. It is hard to tell if its gold or not");
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
            }

        }


        //Check if you collect the Sieve
        else if (item == "Sieve" && gs.GetHasPlacedSieve() == false)
        {
            gs.SetHasSieve(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Sieve";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Sieve";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Sieve";
                    break;
                }

            }
        }


        //Check if you collect the Safety Goggles
        else if (item == "Safety Glasses")
        {
            gs.SetHasSafetyGlasses(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "Safety Glasses";
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "Safety Glasses";
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "Safety Glasses";
                    break;
                }

            }
        }
        //Switch to room 1 from room 2
        if (item == "Door1" && gs.GetCurrentCam() == "Room1_Main")
        {
            if (gs.GetHasDustMask() == true && gs.GetHasSafetyGlasses() == true && gs.GetPPEState() == true)
            {
                gs.SetHighlightedObject(UAP_AccessibilityManager.GetCurrentFocusObject().GetComponent<AccessibleButton_3D>());
                Debug.Log("Highlighted: " + gs.GetHighlightedObject().name);
                TopText.text = "You have the necessary items to enter this room.";
                gs.GetHighlightedObject().transform.gameObject.GetComponent<Animation>()["Cube|Open"].time = 0.3f;
                gs.GetHighlightedObject().transform.gameObject.GetComponent<Animation>()["Cube|Open"].speed = 0.3f;
                gs.GetHighlightedObject().transform.gameObject.GetComponent<Animation>().Play();
                gs.GetHighlightedObject().transform.gameObject.GetComponent<AudioSource>().Play();
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
                if (gs.GetCurrentRoom() == 1)
                {
                    gs.SetCurrentRoom(2);
                    gs.SetCurrentCam("Room2_Main");
                    Debug.Log("Current Room: " + gs.GetCurrentRoom());
                }
                else if (gs.GetCurrentRoom() == 2)
                {
                    gs.SetCurrentRoom(1);
                    gs.SetCurrentCam("Room1_Main");
                    Debug.Log("Current Room: " + gs.GetCurrentRoom());
                }

            }
            else
            {
                TopText.text = (Message);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
            }

        }
        //Switch from room 2 to room 1
        else if (item == "Door1" && gs.GetCurrentCam() == "Room2_Main")
        {
            TopText.text = ("Heading back to room 1");
            TopText.GetComponent<UAP_BaseElement>().SelectItem(true);
            gs.SetCurrentRoom(1);
            gs.SetCurrentCam("Room1_Main");
            Debug.Log("Current Room: " + gs.GetCurrentRoom());

        }


        //Check if you collect the Puzzle Box
        else if (item == "PuzzleBox" && gs.GetHasPuzzleBox() == false)
        {
            gs.SetHasPuzzleBox(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false); 
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Box of Puzzle Pieces";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Box of Puzzle Pieces";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Box of Puzzle Pieces";
                    break;
                }

            }
        }


        //Check if you collect the Dust Mask
        if (item == "DustMask")
        {
            gs.SetHasDustMask(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().name = "Dust Mask";
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_NameLabel.name = "Dust Mask";
                    Inventory[i].gameObject.GetComponent<AccessibleLabel>().m_Text = "Dust Mask";
                    break;
                }
            }


        }

        //Check if you collect the Saw Blade
        if (item == "NewSawBlade")
        {
            gs.SetHasSawBlade(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    this.gameObject.SetActive(false);
                    //Destroy(this.gameObject);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Saw Blade";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Saw Blade";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Saw Blade";
                    break;
                }
            }


        }

        //Check if you collect the click on the cut core piece in saw
        if (item == "InspectedCutCore")
        {
            gs.SetholdingCutCore(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Cut Core Piece";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Cut Core Piece";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Cut Core Piece";
                    break;
                }
            }


        }


        if (item == "ResultsCutCore" && gs.GetfoundGoldCore() == true)
        {
            gs.SetholdingCutCore(true);
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = "Core has been collected.";
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem(true);
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Cut Core Piece";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Cut Core Piece";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Cut Core Piece";
                    break;
                }
            }


        }


        if (item == "sodaLiteRock_textured" && gs.GetHasFoundSodaLite() == true)
        {

            Debug.Log("Display Dragon Code of Ethics now");
            TopText.text = ("You Have Found the Code of Ethics Easter egg! You can now review the code of ethics after beating the game");
            TopText.GetComponent<UAP_BaseElement>().SelectItem();
            //gs.SetHasFoundSodaLite(true);


        }


        //Switch to room 1 and 3
        if (item == "Door2" && gs.GetCurrentRoom() == 1)
        {
            if (gs.GetfoundGoldCore() == true && gs.GetIsRoom3Unlocked() == false)
            {
                TopText.text = "You have the necessary items this room but first it must be unlocked.";

                TopText.GetComponent<UAP_BaseElement>().SelectItem();

            }
            else if (gs.GetfoundGoldCore() == true && gs.GetIsRoom3Unlocked() == true)
            {
                TopText.text = "You Can Now Enter This Room! Room 3";
                DoorToRoom3.GetComponent<Animation>()["Cube|Open"].time = 0.3f;
                DoorToRoom3.transform.gameObject.GetComponent<Animation>()["Cube|Open"].speed = 0.3f;
                DoorToRoom3.transform.gameObject.GetComponent<Animation>().Play();
                DoorToRoom3.transform.gameObject.GetComponent<AudioSource>().Play();
                TopText.GetComponent<UAP_BaseElement>().SelectItem();

                
                Debug.Log("Current Room: " + gs.GetCurrentRoom());
            }
            else
            {
                TopText.text = (Message);
                TopText.GetComponent<UAP_BaseElement>().SelectItem();
            }

        }
        //Switch from room 2 to room 1
        else if (item == "Door2" && gs.GetCurrentRoom() == 3)
        {
            TopText.text = ("Heading back to room 1");
            TopText.GetComponent<UAP_BaseElement>().SelectItem(true);
            gs.SetCurrentRoom(1);
            Debug.Log("Current Room: " + gs.GetCurrentRoom());

        }


        //Check if you collect the Magnet Pen
        if (item == "MagnetPen")
        {
            gs.SetHasMagnetPen(true);
            soundManager.PlayPickupSound();
            for (int i = 0; i <= Inventory.Length; i++)
            {
                if (Inventory[i].sprite == null)
                {
                    Inventory[i].sprite = itemImage;
                    Inventory[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    TopText.text = (Message);
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    TopText.GetComponent<UAP_BaseElement>().SelectItem();
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().name = "Magnet Pen";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel = this.gameObject;
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_NameLabel.name = "Magnet Pen";
                    Inventory[i].gameObject.GetComponent<AccessibleButton>().m_Text = "Magnet Pen";
                    break;
                }
            }


        }


    }

}
