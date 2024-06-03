using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using UnityEngine.UI;

public class QuizzManager : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] int Score;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;
    int correctAnswerIndex;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButtons;
    [SerializeField] private Sprite correctAnswerImage;
    [SerializeField] private Sprite defaultAnswerImage;

    [Header("Timer")]
    [SerializeField] private Image timerImage;
    Timer timer;

    [Header("Progress Bar")]
    [SerializeField] private Slider progressBar;
    public WinPanel winpanel;
    public diem diem;



    private void Start()
    {
        //timer = GameObject.Find("TimerManager").GetComponent<Timer>();
        timer = FindObjectOfType<Timer>();

        // Progress bar
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;

    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                winpanel.Show();
            }

            // Tiep tuc load 1 cau hoi moi
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            SetButtonState(true);
            SetDefaultButtonState();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }      
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswer(int index)
    {
        timer.CancelTimer();
        SetButtonState(false);
        Image buttonImage;
        if (index == currentQuestion.GetCorrectAnswer())
        {
            Debug.Log("Correct");
            questionText.text = "Chính xác!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerImage;
        }
        else
        {
            Debug.Log("Wrong");
            correctAnswerIndex = currentQuestion.GetCorrectAnswer();
            string correct = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Sai:\n" + correct;

            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerImage;
            Score = diem.currentDiem - 1;
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonState()
    {
        //for (int i = 0; i < answerButtons.Length; i++)
        //{
        //    Image buttonImage = answerButtons[i].GetComponent<Image>();
        //    buttonImage.sprite = defaultAnswerImage;
        //}

        foreach (GameObject img in answerButtons)
        {
            img.GetComponent<Image>().sprite = defaultAnswerImage;
        }
    }

}

