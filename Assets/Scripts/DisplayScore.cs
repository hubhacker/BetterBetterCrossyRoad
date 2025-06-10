using UnityEngine;
using UnityEngine.UI;
using TMPro; // Required for accessing UI elements

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        UpdateScore(0); // Initialize score display
    }
    public void UpdateScore(int newScore)
    {
        score = newScore;
        scoreText.text = score.ToString();
    }
}
