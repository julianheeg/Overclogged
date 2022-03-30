using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Noise_Bar noise_bar;
    public Blockage_Bar_Poop blockage_bar;
    public GameObject duck_prefab;
    public GameObject toilet;
    public Timer timer;
    public GameObject level_introduction_panel;
    public GameObject level_over_panel;
    public Player player;
    private bool has_started;
    public int level;
    public DuckSpawner duckSpawner;
    public Quiz quiz;
    public GameObject credits;


    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        has_started = false;
        duckSpawner.enable(false);
    }

    void Start()
    {
        level_introduction_panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!has_started && Input.GetMouseButtonDown(0) && level != config.LAST_LEVEL)
        {
            has_started = true;
            level_introduction_panel.SetActive(false);
            toilet.GetComponent<Toilet>().enable(true);
            timer.gameObject.SetActive(true);
            timer.enable(true);
            noise_bar.gameObject.SetActive(true);
            noise_bar.enable(true);
            blockage_bar.gameObject.SetActive(true);
            blockage_bar.enable(true);
            blockage_bar.changeLevel(level);
            duckSpawner.enable(true);
            quiz.enable(true);
        }

        // DEBUG CODE. TODO: REMOVE
        // skip level by pressing "d"
        if (has_started && Debug.isDebugBuild && Input.GetKeyDown("d"))
        {
            BlockageCleared();
        }
    }

    private void level_over()
    {
        toilet.GetComponent<Toilet>().enable(false);
        timer.enable(false);
        duckSpawner.enable(false);
        noise_bar.enable(false);
        blockage_bar.enable(false);
        level_over_panel.gameObject.SetActive(true);
        quiz.enable(false);
    }

    public void TimeUp()
    {
        level_over();
        level_over_panel.GetComponent<Level_Over_Panel>().Display_TimeUp();
    }

    public void TooLoud()
    {
        level_over();
        level_over_panel.GetComponent<Level_Over_Panel>().Display_TooLoud();
    }

    public void QuizTimeout()
    {
        level_over();
        level_over_panel.GetComponent<Level_Over_Panel>().Display_QuizTimeout();
    }

    public void QuizFailed()
    {
        level_over();
        level_over_panel.GetComponent<Level_Over_Panel>().Display_QuizFailed();
    }

    public void BlockageCleared()
    {
        level_over();
        level_over_panel.GetComponent<Level_Over_Panel>().Display_BlockageCleared();
    }

    public void StartLevel(int level)
    {
        this.level = level;
        config.loadLevelSettings(level);

        level_over_panel.GetComponent<Level_Over_Panel>().reset();
        level_over_panel.SetActive(false);
        level_introduction_panel.SetActive(true);
        level_introduction_panel.GetComponent<Pre_Level_Screen>().setLevel(level);
        has_started = false;
        has_started = false;
        duckSpawner.despawn();
        noise_bar.reset();
        blockage_bar.reset();
        noise_bar.gameObject.SetActive(false);
        blockage_bar.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        quiz.reset();
        player.animator.SetInteger("Player", level);

        if (level == 2)
        {
            level_introduction_panel.SetActive(false);
            credits.SetActive(true);
        }
    }
}
