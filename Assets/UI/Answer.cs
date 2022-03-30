using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public int answer_id;
    public Quiz quiz;
    public Text text;

    void OnMouseDown()
    {
        quiz.give_answer(answer_id);
    }

    public void set_text(string text)
    {
        this.text.text = text;
    }
}
