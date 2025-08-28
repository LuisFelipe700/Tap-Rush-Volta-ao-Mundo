using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int record = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float gameDuration = 60f;
    public float timeLeft;
    private int comboCount = 0;
    private bool comboActive = false;
    public Sprite[] fundos;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1f; // Garantir que o tempo do jogo esteja rodando
        timeLeft = gameDuration;
        record = PlayerPrefs.GetInt("Record", 0);
        CriarFundo();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeLeft).ToString();
        }
        else
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

    void CriarFundo()
    {
        if (fundos.Length == 0) return;
        Sprite escolhido = fundos[Random.Range(0, fundos.Length)];
        GameObject fundoObj = new GameObject("Fundo");
        SpriteRenderer sr = fundoObj.AddComponent<SpriteRenderer>();
        sr.sprite = escolhido;
        sr.sortingOrder = -100;
        Camera cam = Camera.main;
        fundoObj.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0f);
        float alturaTela = 2f * cam.orthographicSize;
        float larguraTela = alturaTela * cam.aspect;
        Vector2 tamanhoSprite = escolhido.bounds.size;
        float escala = Mathf.Max(larguraTela / tamanhoSprite.x, alturaTela / tamanhoSprite.y);
        fundoObj.transform.localScale = Vector3.one * escala;
    }
}