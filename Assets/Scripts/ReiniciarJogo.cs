using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJogo : MonoBehaviour
{
    public void ReiniciarCompleto()
    {
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        GameObject fundo = GameObject.Find("Fundo");
        if (fundo != null)
        {
            Destroy(fundo);
        }

        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ReiniciarPartida()
    {
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        GameObject fundo = GameObject.Find("Fundo");
        if (fundo != null)
        {
            Destroy(fundo);
        }
        SceneManager.LoadScene("Game");


    }







}
