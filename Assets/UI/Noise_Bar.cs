using UnityEngine;
using System.Collections.Generic;

public class Noise_Bar : MonoBehaviour
{
    public float barDisplay = 0; //current progress
    float updateDelta = 0;
    public GameObject right_ball;
    public GameObject bar;

    new bool enabled;
    Queue<float> recent_noises_timestamps; //list of timestamps of recent noises

    void Awake()
    {
        enabled = true;
        recent_noises_timestamps = new Queue<float>();
    }


    void Update()
    {
        if (enabled)
        {
            barDisplay += updateDelta;
            barDisplay += config.NOISE_CHANGE_PER_SECOND * Time.deltaTime;
            updateDelta = 0;

            while(recent_noises_timestamps.Count > 0)
            {
                float most_recent = recent_noises_timestamps.Dequeue();
                if (most_recent >= Time.time - config.NOISE_FORGET_TIME)
                {
                    break;
                }
            }

            if (barDisplay >= 1)
            {
                barDisplay = 1;
                LevelManager.Instance.TooLoud();
            }
            else if (barDisplay < 0)
            {
                barDisplay = 0;
            }

            // right ball
            float pos = 3.88f * barDisplay -1.94f;
            right_ball.transform.localPosition = new Vector3(pos, 0, 0);

            // brown
            bar.transform.localScale = new Vector3(barDisplay, 1, 1);
            pos = 1.94f * barDisplay - 1.94f;
            bar.transform.localPosition = new Vector3(pos, 0, 0);
        }
    }

    public void change(float amount)
    {
        if (recent_noises_timestamps == null)
        {
            updateDelta += amount;
            Debug.Log("queue in Noise_Bar is null.");
            return;
        }
        recent_noises_timestamps.Enqueue(Time.time);
        updateDelta += amount * (1 + config.RECENT_NOISE_FACTOR * recent_noises_timestamps.Count);
    }

    public void enable(bool enabled)
    {
        this.enabled = enabled;
    }

    public void reset()
    {
        recent_noises_timestamps.Clear();
        barDisplay = 0;
        updateDelta = 0;
    }
}
