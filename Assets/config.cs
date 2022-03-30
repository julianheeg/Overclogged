using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config
{
    //noise
    public static float NOISE_CHANGE_PER_SECOND = -.07f;
    public static float TOILET_PLUNGE_NOISE = .015f;
    public static float DUCK_QUACK_NOISE = .25f;
    public static float DUCK_QUACK_TIME_MIN_seconds = 2;
    public static float DUCK_QUACK_TIME_MAX_seconds = 7;
    public static float NOISE_FORGET_TIME = 5;
    public static float RECENT_NOISE_FACTOR = .6f;
    public static float QUACK_START_DELAY = 1;

    // plunge progress
    public static float TOILET_PLUNGE_PROGRESS = .005f;
    public static float TOILET_PLUNGE_PROGRESS_PER_SECOND = -.000f;

    // level timer
    public static float LEVEL_TIME = 90;
    public static float TIMER_BLINK_TIME = 15;
    public static float TIMER_BLINK_SWITCH_INTERVAL = .3f;

    // quiz
    public static float QUIZ_ASK_INTERVAL = 10;
    public static float QUIZ_ANSWER_TIME = 5;

    // ducks
    public static float DUCK_SPAWN_MAX_INTERVAL = 4;
    public static float DUCK_SPAWN_MIN_INTERVAL = 2;
    public static float DUCK_MOVEMENT_SPEED = 1;
    public static float DUCK_LEFTMOST_POSITION = -.74f;
    public static float DUCK_RIGHTMOST_POSITION = 8.15f;
    public static float DUCK_UPMOST_POSITION = -1.9f;
    public static float DUCK_DOWNMOST_POSITION = -3.07f;

    // animation
    public static float PLUNGE_ANIMATION_TIME_seconds = .5f;
    public static float QUACK_ANIMATION_TIME_seconds = .75f;
    public static float PLUNGE_SOUND_INTERVAL = .5f;

    public static float LAST_LEVEL = 2;

    public static void loadLevelSettings(int level)
    {
        if (level == 1)
        {
            LEVEL_TIME = 150;
            DUCK_SPAWN_MAX_INTERVAL = 3;
            DUCK_SPAWN_MIN_INTERVAL = .5f;
            DUCK_MOVEMENT_SPEED = 1.5f;

            QUIZ_ASK_INTERVAL = 8;
            //QUIZ_ANSWER_TIME = 3;
            //TOILET_PLUNGE_NOISE = .025f;
            DUCK_QUACK_TIME_MIN_seconds = 1;
            DUCK_QUACK_TIME_MAX_seconds = 4;
            QUACK_START_DELAY = 2;
            TOILET_PLUNGE_PROGRESS = .004f;
        }
    }
}
