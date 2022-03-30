using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage_Bar_Poop : MonoBehaviour
{
    public float barDisplay = 0; //current progress
    float updateDelta = 0;
    new bool enabled;
    public Sprite[] poops;
    public GameObject poop;
    public GameObject brown;
    public GameObject blue;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    void Update()
    {
        if (enabled)
        {
            barDisplay += updateDelta;
            barDisplay += config.TOILET_PLUNGE_PROGRESS_PER_SECOND * Time.deltaTime;
            updateDelta = 0;

            if (barDisplay >= 1)
            {
                LevelManager.Instance.BlockageCleared();
            }
            else if (barDisplay < 0)
            {
                barDisplay = 0;
            }

            // blue
            blue.transform.localScale = new Vector3(barDisplay, 1, 1);
            float pos = -8.8f * barDisplay + 8.8f;
            blue.transform.localPosition = new Vector3(pos, 0, 0);

            // brown
            brown.transform.localScale = new Vector3(1 - barDisplay, 1, 1);
            pos = 8.8f * (1 - barDisplay) - 8.8f;
            brown.transform.localPosition = new Vector3(pos, 0, 0);

            // poop
            pos = -17.6f * barDisplay + 8.8f;
            poop.transform.localPosition = new Vector3(pos, 0, 0);
        }
    }

    public void change(float amount)
    {
        updateDelta += amount;
    }

    public void enable(bool enabled)
    {
        this.enabled = enabled;
    }

    public void reset()
    {
        barDisplay = 0;
        updateDelta = 0;
    }

    public void changeLevel(int level)
    {
        poop.GetComponent<SpriteRenderer>().sprite = poops[level];
    }
}
