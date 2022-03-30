using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    float time_till_next_quack;
    Vector3 destination;
    bool disabled;
    public Animator animator;
    float quack_animation_time;

    public AudioSource quack;

    // Start is called before the first frame update
    void Awake()
    {
        disabled = false;
        quack_animation_time = 0;
        quack = GetComponent<AudioSource>();
        time_till_next_quack = config.QUACK_START_DELAY + Random.Range(config.DUCK_QUACK_TIME_MIN_seconds, config.DUCK_QUACK_TIME_MAX_seconds); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            time_till_next_quack -= Time.deltaTime;
            if (time_till_next_quack <= 0)
            {
                LevelManager.Instance.noise_bar.change(config.DUCK_QUACK_NOISE);
                animator.SetTrigger("quack");
                quack.PlayDelayed(.35f);
                time_till_next_quack = Random.Range(config.DUCK_QUACK_TIME_MIN_seconds, config.DUCK_QUACK_TIME_MAX_seconds);
                quack_animation_time = config.QUACK_ANIMATION_TIME_seconds;
            }

            quack_animation_time -= Time.deltaTime;

            if (quack_animation_time <= 0) //only move when not quacking
            {
                Vector3 direction = destination - gameObject.transform.position;
                direction.z = 0f;
                direction.Normalize();
                gameObject.transform.position += direction * Time.deltaTime;
            }
        }
    }

    void OnMouseDown()
    {
        animator.SetTrigger("boom");
        disabled = true;
    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    public void disable()
    {
        disabled = true;
    }

    public void setAudioClip(AudioClip audioClip)
    {
        quack.clip = audioClip;
    }
}
