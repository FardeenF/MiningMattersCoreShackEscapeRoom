using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public Camera mainCam;
    public AudioSource source;
    public AudioClip pickUpSound;
    public AudioClip successSound;
    public AudioClip typingSound;
    public AudioClip incorrectSound;
    public AudioClip unlockSound;
    public AudioClip lockSpinSound;
    public AudioClip placePieceSound;
    public AudioClip cabinetOpeningSound;
    public AudioClip machineWorkingSound;
    public AudioClip bootsPPESound;
    public AudioClip waterSprayerSound;
    public GameState gs;

    private bool isPlaying = false;
    private bool soundChecker = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }
    }

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Puzzle 1 - Core Puzzle, pick up sound 
            if (hit.transform.gameObject.tag == "BrokenCore" || hit.transform.gameObject.tag == "BrokenCoreOnTable")
            {
                //Play the pick up sound 
                source.PlayOneShot(pickUpSound, 0.4f);
            }
        }
    }

    public void PlaySuccessSound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(successSound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(1.0f));
            soundChecker = false;
        }    
    }

    public void PlayIncorrectSound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(incorrectSound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(1.0f));
            soundChecker = false;
        }
    }

    public void PlayUnlockSound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(unlockSound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(1.0f));
            soundChecker = false;
        }
    }

    public void PlayPickupSound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(pickUpSound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(1.0f));
            soundChecker = false;
        }
    }

    public void PlayLockSpinSound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(lockSpinSound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(0.1f));
            soundChecker = false;
        }
    }

    public void PlayPPESound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(bootsPPESound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(1.0f));
            soundChecker = false;
        }
    }

    public void PlayMachineWorkingSound()
    {
        soundChecker = true;

        if (!isPlaying && soundChecker == true)
        {
            source.PlayOneShot(machineWorkingSound, 0.4f);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(1.0f));
            soundChecker = false;
        }
    }

    IEnumerator WaitForSoundToEnd(float length)
    {
        yield return new WaitForSeconds(length);
        isPlaying = false;
    }
}
