using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int record = 0;
    public TextMesh scoreText;
    public TextMesh timerText;
    public float gameDuration = 60f;
    private float timeLeft;
    private int comboCount = 0;
    private bool comboActive = false;

    void Awake() => Instance = this;

    void Start()
    {
        timeLeft = gameDuration;
        record = PlayerPrefs.GetInt("Record", 0);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(float reactionTime = 0.5f)
    {
        int points = reactionTime < 0.3f ? 2 : 1;
        score += comboActive ? points * 2 : points;
        scoreText.text = score.ToString();

        if (reactionTime < 0.3f)
        {
            comboCount++;
            if (comboCount >= 5)
                StartCoroutine(ActivateCombo());
        }
        else
        {
            comboCount = 0;
        }
    }

    IEnumerator ActivateCombo()
    {
        comboActive = true;
        yield return new WaitForSeconds(5f);
        comboActive = false;
        comboCount = 0;
    }

    public void EndGame()
    {
        if (score > record)
        {
            PlayerPrefs.SetInt("Record", score);
        }
        SceneManager.LoadScene("Result");
    }

    public void TriggerGameOver()
    {
        SceneManager.LoadScene("Result");
    }
}
