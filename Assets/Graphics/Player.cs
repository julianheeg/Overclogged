using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    float time_plunging;
    public AudioClip[] plunges;
    //float time_since_last_sound;
    public AudioSource plunge;


    void Awake()
    {
        time_plunging = 0;
        //time_since_last_sound = 0f;
        plunge = GetComponent<AudioSource>();
    }

    void Update()
    {
        time_plunging -= Time.deltaTime;
        if (time_plunging <= 0)
        {
            animator.SetBool("plunging", false);
        }

    }

    public void plungeAnimation()
    {
        time_plunging = config.PLUNGE_ANIMATION_TIME_seconds;
        animator.SetBool("plunging", true);
    }

    public void plungeSound()
    {
        plunge.clip = plunges[Random.Range(0, plunges.Length)];
        plunge.Play();
    }
}
