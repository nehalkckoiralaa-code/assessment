using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject congratulationsPanel;
    public TextMeshProUGUI congratulationsText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: 0/100";
        congratulationsPanel.SetActive(false);
    }

    public IEnumerator FoundHazard(string hazardName)
    {
        AddScore(10);

        congratulationsText.text =
            "Congratulations!\n\nYou found:\n" +
            hazardName +
            "\n\n+10 Points";

        congratulationsPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        congratulationsPanel.SetActive(false);
    }

    // NEW METHOD
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score + "/100";
    }
}