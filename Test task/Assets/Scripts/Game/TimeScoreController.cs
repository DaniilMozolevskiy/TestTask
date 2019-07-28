using UnityEngine;
using UnityEngine.UI;

public class TimeScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;
    [SerializeField] private GeneralData data;
    private int totalScore;
    [HideInInspector] public int scoreGenerateCount;
    [HideInInspector] public float timer;

    private void Start()
    {
        scoreGenerateCount = data.ScoreGenerateCount;
        InvokeRepeating("AddScore", 1, data.ScoreGenerateInterval);
        InvokeRepeating("AddSecond", 1, 1);
    }

    private void AddScore()
    {
        totalScore += scoreGenerateCount;
        scoreText.text = totalScore.ToString();
        PlayerPrefs.SetInt("New score", totalScore);
    }

    private void AddSecond()
    {
        timerText.text = (++timer).ToString();
    }
}
