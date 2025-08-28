using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; // Arraste aqui o seu painel de menu de pausa

    void Update()
    {
        // Se a tecla Escape for pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Esconde o painel
        Time.timeScale = 1f; // Retoma o tempo
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Mostra o painel
        Time.timeScale = 0f; // Para o tempo
        GameIsPaused = true;
    }

    // Este método é útil para o botão de "Voltar ao Menu Principal"
    public void LoadMenu()
    {
        Time.timeScale = 1f; // Garantir que o tempo volte ao normal
        SceneManager.LoadScene("MenuPrincipal");
    }
}