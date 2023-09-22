using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonPuzzleInteraction : MonoBehaviour
{
    public Camera mainCam;

    public AudioSource source;
    public AudioSource SoundSeries;
    public AudioClip beep;
    public AudioClip drill;
    public AudioClip honk;
    public AudioClip clang;
    public TextMeshProUGUI topText;

    private List<AudioClip> solution = new List<AudioClip>();

    public GameState gs;

    // Start is called before the first frame update
    void Start()
    {
        solution.Add(drill);
        solution.Add(clang);
        solution.Add(beep);
        solution.Add(clang);
        solution.Add(drill);
        solution.Add(honk);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }
    }

    public void AccessibleClickButton(AudioClip audio)
    {
        source.PlayOneShot(audio, 1.0f);
    }

    public void AccessibleSequenceButton()
    {
        //StartCoroutine(playAudioSequentially());
        SoundSeries.Play();
    }

    

    public void ShootRaycast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //Checks if you click on the button
            if (hit.transform.gameObject.tag == "Button")
            {
                //play button click animation
                hit.transform.gameObject.GetComponent<Animation>().Play(animation: "ButtonPress");
                topText.text = ("You hear a series of sounds");
                topText.GetComponent<UAP_BaseElement>().SelectItem();


                //StartCoroutine(playAudioSequentially());
                SoundSeries.Play();
            }
            else if(hit.transform.gameObject.tag == "Button1")
            {
                //play button click animation
                hit.transform.gameObject.GetComponent<Animation>().Play(animation: "ButtonPress");
                topText.text = ("You hear a drill sound");
                topText.GetComponent<UAP_BaseElement>().SelectItem();

                source.PlayOneShot(drill, 1.0f);
            }
            else if (hit.transform.gameObject.tag == "Button2")
            {
                //play button click animation
                hit.transform.gameObject.GetComponent<Animation>().Play(animation: "ButtonPress");
                topText.text = ("You hear a beep sound");
                topText.GetComponent<UAP_BaseElement>().SelectItem();

                source.PlayOneShot(beep, 1.0f);
            }
            else if (hit.transform.gameObject.tag == "Button3")
            {
                //play button click animation
                hit.transform.gameObject.GetComponent<Animation>().Play(animation: "ButtonPress");
                topText.text = ("You hear a honk sound");
                topText.GetComponent<UAP_BaseElement>().SelectItem();

                source.PlayOneShot(honk, 1.0f);
            }
            else if (hit.transform.gameObject.tag == "Button4")
            {
                //play button click animation
                hit.transform.gameObject.GetComponent<Animation>().Play(animation: "ButtonPress");
                topText.text = ("You hear a clang sound");
                topText.GetComponent<UAP_BaseElement>().SelectItem();

                source.PlayOneShot(clang, 1.0f);
            }

        }

    }


    IEnumerator playAudioSequentially()
    {
        
        yield return null;

        

        //1.Loop through each AudioClip
            for (int i = 0; i < solution.Count; i++)
            {
                //2.Assign current AudioClip to audiosource
                source.clip = solution[i];

                //3.Play Audio
                source.Play();

                //4.Wait for it to finish playing
                while (source.isPlaying)
                {
                    yield return new WaitForSeconds(1.0f);
                    //yield return null;
                }

                //5. Go back to #2 and play the next audio in the adClips array
            }
        

    }
}
