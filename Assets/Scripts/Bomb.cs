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
        // Pega a instância do GameManager
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
                // Chama a função específica para o fim de jogo da bomba
                gameManager.TriggerGameOver("GameOver");
                SceneManager.LoadScene("GameOver");
                
            }

            // Destrói a bomba após ser clicada
            Destroy(gameObject);
        }
    }
}