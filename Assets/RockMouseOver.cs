using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockMouseOver : MonoBehaviour
{
    public string message;
    public TextMeshProUGUI topText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        topText.text = message;
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(205, 205, 205, 255);
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
