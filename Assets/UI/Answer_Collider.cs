using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_Collider : MonoBehaviour
{
    public int answer_id;
    public Quiz quiz;

    void OnMouseDown()
    {
        quiz.give_answer(answer_id);
    }
}
