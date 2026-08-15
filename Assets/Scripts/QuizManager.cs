using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [Header("Quiz UI")]
    public GameObject quizPanel;
    public GameObject resultPanel;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionNumberText;
    public TextMeshProUGUI resultScoreText;

    public Button[] answerButtons;
    public TextMeshProUGUI[] answerTexts;

    [Header("Questions")]
    public Question[] questions;

    private int currentQuestion = 0;

    public bool quizCompleted = false;

    void Start()
    {
        quizPanel.SetActive(false);
        resultPanel.SetActive(false);
    }

    public void StartQuiz()
    {
        Debug.Log("StartQuiz Called");

        if (quizCompleted)
        {
            Debug.Log("Quiz already completed");
            return;
        }

        Debug.Log("Opening Quiz");

        resultPanel.SetActive(false);
        quizPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        currentQuestion = 0;

        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question q = questions[currentQuestion];

        questionText.text = q.question;
        questionNumberText.text = "Question " + (currentQuestion + 1) + " / " + questions.Length;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerTexts[i].text = q.answers[i];
        }
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == questions[currentQuestion].correctAnswer)
        {
            GameManager.Instance.AddScore(10);
        }

        currentQuestion++;

        if (currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            EndQuiz();
        }
    }

    void EndQuiz()
    {
        Debug.Log("EndQuiz Called");

        quizCompleted = true;

        quizPanel.SetActive(false);
        resultPanel.SetActive(true);

        resultScoreText.text = "Your Final Score\n" + GameManager.Instance.score + "/100";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}