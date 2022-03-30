using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    new bool enabled;

    void Start()
    {
        enabled = true;
    }

    void OnMouseDown()
    {
        if (enabled)
        {
            LevelManager.Instance.blockage_bar.change(config.TOILET_PLUNGE_PROGRESS);
            LevelManager.Instance.noise_bar.change(config.TOILET_PLUNGE_NOISE);
            LevelManager.Instance.player.plungeAnimation();
        }
    }

    public void enable(bool enabled)
    {
        this.enabled = enabled;
    }
}
