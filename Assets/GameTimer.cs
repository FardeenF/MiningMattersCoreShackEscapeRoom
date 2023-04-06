using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public int TimeSec = 00;
    public int TimeMin = 00;

    public TextMeshProUGUI timerText;

    public float timer;
    public GameState gs;

    // Update is called once per frame
    public void Update()
    {
        if (gs.GetEndGame() == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0)
            {
                TimeSec++;
                timer = 0.0f;
            }

            if (TimeSec > 59)
            {
                TimeMin++;
                TimeSec = 0;
            }

            timerText.text = (TimeMin.ToString() + "m:" + TimeSec.ToString() + "s");
        }
    }
}
