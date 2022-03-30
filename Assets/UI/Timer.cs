using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerLabel;

    private float time;
    new private bool enabled;
    private float blink_time;
    private bool displayed;

    // Start is called before the first frame update
    void Start()
    {
        time = config.LEVEL_TIME;
        enabled = true;
        displayed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                LevelManager.Instance.TimeUp();
            }

            if (time <= config.TIMER_BLINK_TIME)
            {
                timerLabel.color = Color.red;
                blink_time -= Time.deltaTime;
                if (blink_time <= 0)
                {
                    blink_time = config.TIMER_BLINK_SWITCH_INTERVAL;
                    displayed = !displayed;
                    timerLabel.gameObject.SetActive(displayed);
                }
            }
            else
            {
                timerLabel.color = Color.white;
            }

            int minutes = (int)Mathf.Floor(time / 60f); //Divide the guiTime by sixty to get the minutes.
            int seconds = (int)time % 60; //Use the euclidean division for the seconds.

            //update the label value
            timerLabel.text = string.Format("{0:0} : {1:00}", minutes, seconds);
        }
    }

    public void enable(bool enabled)
    {
        this.enabled = enabled;
        if (enabled)
        {
            time = config.LEVEL_TIME;
        }
    }
}