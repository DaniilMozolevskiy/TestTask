using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject panel1GameObject;
    [SerializeField] private GameObject panel2GameObject;
    [SerializeField] private SaveLoadRecords saveRecordsScript;
    private int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("New score");
        scoreText.text = "Your score: " + score;
        inputField.text = "Gamer";
    }

    public void EventEnterName()
    {
        if (inputField.text.Length == 5)
        {
            panel1GameObject.SetActive(false);
            panel2GameObject.SetActive(true);
            saveRecordsScript.AddRecord(score, inputField.text);
        }
    }

    public void RepeatGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
