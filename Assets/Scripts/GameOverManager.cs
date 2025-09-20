using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        // Garante que o jogo n�o est� pausado
        Time.timeScale = 1f;

        // Limpa todos os objetos persistentes
        Destroy(GameManager.Instance.gameObject);
        GameObject fundo = GameObject.Find("Fundo");
        if (fundo != null)
        {
            Destroy(fundo);
        }
    }


}
