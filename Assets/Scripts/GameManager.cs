using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;

    // Variáveis de Jogo
    public int score = 0;
    public int record = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float gameDuration = 60f;
    public float timeLeft;
    private int comboCount = 0;
    private bool comboActive = false;
    public Sprite[] fasesDeFundo;
    private SpriteRenderer fundoSpriteRenderer;

    // Variáveis de Pausa
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameplayUI;
    public TextMeshProUGUI pauseButtonText;

    void Awake()
    {
        // SE JÁ EXISTE UMA INSTÂNCIA, DESTRUA ESTE OBJETO PARA EVITAR DUPLICATAS.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // SE NÃO EXISTE, ESTE É A ÚNICA INSTÂNCIA.
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        CriarFundo();
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        MudarFundoAleatorio();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
            timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();

            pauseMenuUI = GameObject.Find("PauseMenuUI");
            gameplayUI = GameObject.Find("GameplayUI");
            pauseButtonText = GameObject.Find("PauseButtonText")?.GetComponent<TextMeshProUGUI>();

            if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
            if (gameplayUI != null) gameplayUI.SetActive(true);

            ResetGameState();
            MudarFundoAleatorio();
        }
    }

    public void ResetGameState()
    {
        score = 0;
        timeLeft = gameDuration;
        comboCount = 0;
        comboActive = false;

        Time.timeScale = 1f;
        isPaused = false;

        UpdateScoreText();
    }

    void Update()
    {
        if (timeLeft > 0 && !isPaused)
        {
            timeLeft -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = Mathf.Ceil(timeLeft).ToString();
            }
        }
        else if (timeLeft <= 0 && !isPaused)
        {
            TriggerGameOver("renicia");
        }
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void AddScore(float reactionTime = 0.5f)
    {
        int points = reactionTime < 0.3f ? 2 : 1;
        score += comboActive ? points * 2 : points;

        UpdateScoreText();

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

    // Função de Fim de Jogo Unificada
    public void TriggerGameOver(string renicia)
    {
        if (score > record)
        {
            PlayerPrefs.SetInt("Record", score);
        }
        PlayerPrefs.SetInt("LastScore", score);
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("renicia");
    }

    void CriarFundo()
    {
        GameObject fundoObj = GameObject.Find("Fundo");
        if (fundoObj == null)
        {
            fundoObj = new GameObject("Fundo");
            fundoSpriteRenderer = fundoObj.AddComponent<SpriteRenderer>();
            DontDestroyOnLoad(fundoObj);
        }
        else
        {
            fundoSpriteRenderer = fundoObj.GetComponent<SpriteRenderer>();
        }
    }

    void MudarFundoAleatorio()
    {
        if (fasesDeFundo.Length > 0 && fundoSpriteRenderer != null)
        {
            Sprite escolhido = fasesDeFundo[Random.Range(0, fasesDeFundo.Length)];
            fundoSpriteRenderer.sprite = escolhido;

            Camera cam = Camera.main;
            fundoSpriteRenderer.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 10);
            fundoSpriteRenderer.sortingOrder = -100;

            if (fundoSpriteRenderer.sprite != null)
            {
                float alturaTela = 2f * cam.orthographicSize;
                float larguraTela = alturaTela * cam.aspect;
                Vector2 tamanhoSprite = fundoSpriteRenderer.sprite.bounds.size;
                float escala = Mathf.Max(larguraTela / tamanhoSprite.x, alturaTela / tamanhoSprite.y);
                fundoSpriteRenderer.transform.localScale = Vector3.one * escala;
            }
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        if (gameplayUI != null) gameplayUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;

        if (pauseButtonText != null)
        {
            pauseButtonText.text = "PAUSE";
        }
    }

    void Pause()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
        if (gameplayUI != null) gameplayUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;

        if (pauseButtonText != null)
        {
            pauseButtonText.text = "CONTINUAR";
        }
    }

   

    public void QuitGame()
    {
        Application.Quit();
    }
}