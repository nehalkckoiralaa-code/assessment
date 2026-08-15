using UnityEngine;

public class QuizStarter : MonoBehaviour
{
    public QuizManager quizManager;

    public void StartQuiz()
    {
        quizManager.StartQuiz();
    }
}