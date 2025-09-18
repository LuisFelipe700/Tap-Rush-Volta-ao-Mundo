using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonEvents : MonoBehaviour
{
   

    public void PlayAgain()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TriggerGameOver(); // Ou a fun��o que reinicia o jogo
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}