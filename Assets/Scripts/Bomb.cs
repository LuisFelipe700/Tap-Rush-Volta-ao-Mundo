using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class FakeTarget : MonoBehaviour
{
    private bool podeSerClicado = true;
    private GameManager gameManager;

    private void Start()
    {
        // Pega a inst�ncia do GameManager
        gameManager = GameManager.Instance;
    }

    // Chamado quando o mouse clica no objeto
    private void OnMouseDown()
    {
        if (podeSerClicado)
        {
            podeSerClicado = false;

            if (gameManager != null)
            {
                // Chama a fun��o espec�fica para o fim de jogo da bomba
                gameManager.TriggerGameOver("GameOver");
                SceneManager.LoadScene("GameOver");
                
            }

            // Destr�i a bomba ap�s ser clicada
            Destroy(gameObject);
        }
    }
}