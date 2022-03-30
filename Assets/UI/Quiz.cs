using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public GameObject quiz_timer;
    float time_left = 10f;
    bool quiz_active;
    float time_since_last_quiz;
    public AudioSource knock;
    public GameObject Question;
    public Text question_text;
    public GameObject[] Answers;
    new bool enabled;
    int correct_answer;

    string[] questions1 = new string[] { "How is the business going?", "Can I help you?", "Can I bring you something?" };
    string[] answers_correct1 = new string[] { "Jesus would approve it.", "Everything is fine here.", "Thanks for asking, I will come soon." };
    string[] answers_wrong1 = new string[] { "Crap, like my products.", "Only God can help me now.", "Patience is a virtue." };
    string[] questions2 = new string[] { "Are you coming soon?", "Are you scared?", "What two things can you never eat for breakfast?" };
    string[] answers_correct2 = new string[] { "No, I'm coming now.", "Haha, I will defeat you easy.", "Lunch and Dinner." };
    string[] answers_wrong2 = new string[] { "Yeah, I'm cumming.", "Haha, I shit my pants.", "Your mom." };

    void Awake()
    {
        quiz_active = false;
        time_since_last_quiz = 0;
        enabled = false;
    }

    public void Ask()
    {
        knock.Play();
        quiz_active = true;
        time_left = config.QUIZ_ANSWER_TIME;
        quiz_timer.SetActive(true);
        time_since_last_quiz = 0;
        Question.SetActive(true);
        Answers[0].SetActive(true);
        Answers[1].SetActive(true);

        string[] questions = LevelManager.Instance.level == 0 ? questions1 : questions2;
        string[] answers_correct = LevelManager.Instance.level == 0 ? answers_correct1 : answers_correct2;
        string[] answers_wrong = LevelManager.Instance.level == 0 ? answers_wrong1 : answers_wrong2;

        correct_answer = Random.Range(0, 2);

        int index = Random.Range(0, questions.Length);
        question_text.text = questions[index];
        Answers[correct_answer].GetComponent<Answer>().set_text(answers_correct[index]);
        Answers[1-correct_answer].GetComponent<Answer>().set_text(answers_wrong[index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            if (quiz_active)
            {
                time_left -= Time.deltaTime;
                quiz_timer.gameObject.GetComponent<Image>().fillAmount = time_left / config.QUIZ_ANSWER_TIME;
                if (time_left <= 0)
                {
                    LevelManager.Instance.QuizTimeout();
                    quiz_timer.SetActive(false);
                    quiz_active = false;
                }
            }
            else
            {
                time_since_last_quiz += Time.deltaTime;
                if (time_since_last_quiz >= config.QUIZ_ASK_INTERVAL)
                {
                    Ask();
                }
            }
        }
    }

    public void reset()
    {
        quiz_active = false;
        time_since_last_quiz = 0;
        quiz_timer.SetActive(false);
        Question.SetActive(false);
        Answers[0].SetActive(false);
        Answers[1].SetActive(false);
    }

    public void enable(bool enabled)
    {
        this.enabled = enabled;
    }

    public void give_answer(int answer_id)
    {
        if (answer_id == correct_answer)
        {
            reset();
        }
        else
        {
            LevelManager.Instance.QuizFailed();
        }
    }
}
