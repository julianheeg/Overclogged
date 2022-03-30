using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Over_Panel : MonoBehaviour
{
    public GameObject time_up_text;
    public GameObject too_loud_text;
    public GameObject quiz_failed_text;
    public GameObject quiz_timeout_text;
    public GameObject blockage_cleared_text;
    public Button try_again_button;
    public Button next_level_button;
    public AudioClip level_cleared_sound;
    public AudioClip level_failed_sound;
    public GameObject sad_businessguy;
    public GameObject sad_nerd;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Display_TimeUp()
    {
        if (LevelManager.Instance.level == 0)
        {
            sad_businessguy.SetActive(true);
        }
        else
        {
            sad_nerd.SetActive(true);
        }
        time_up_text.SetActive(true);
        next_level_button.interactable = false;
        audioSource.clip = level_failed_sound;
        audioSource.Play();
    }

    public void Display_TooLoud()
    {
        if (LevelManager.Instance.level == 0)
        {
            sad_businessguy.SetActive(true);
        }
        else
        {
            sad_nerd.SetActive(true);
        }
        too_loud_text.SetActive(true);
        next_level_button.interactable = false;
        audioSource.clip = level_failed_sound;
        audioSource.Play();
    }

    public void Display_QuizTimeout()
    {
        if (LevelManager.Instance.level == 0)
        {
            sad_businessguy.SetActive(true);
        }
        else
        {
            sad_nerd.SetActive(true);
        }
        quiz_timeout_text.SetActive(true);
        next_level_button.interactable = false;
        audioSource.clip = level_failed_sound;
        audioSource.Play();
    }

    public void Display_QuizFailed()
    {
        if (LevelManager.Instance.level == 0)
        {
            sad_businessguy.SetActive(true);
        }
        else
        {
            sad_nerd.SetActive(true);
        }
        quiz_failed_text.SetActive(true);
        next_level_button.interactable = false;
        audioSource.clip = level_failed_sound;
        audioSource.Play();
    }

    public void Display_BlockageCleared()
    {
        blockage_cleared_text.SetActive(true);
        next_level_button.interactable = true;
        audioSource.clip = level_cleared_sound;
        audioSource.Play();
    }

    public void TryAgain_Button_Click()
    {
        LevelManager.Instance.StartLevel(LevelManager.Instance.level);
    }

    public void NextLevel_Button_Click()
    {
        LevelManager.Instance.StartLevel(LevelManager.Instance.level + 1);
    }

    public void reset()
    {
        time_up_text.SetActive(false);
        too_loud_text.SetActive(false);
        quiz_failed_text.SetActive(false);
        quiz_timeout_text.SetActive(false);
        blockage_cleared_text.SetActive(false);
        sad_businessguy.SetActive(false);
        sad_nerd.SetActive(false);
    }
}
