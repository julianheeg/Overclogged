using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pre_Level_Screen : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;

    public void setLevel(int level)
    {
        image.sprite = sprites[level];
    }
}
