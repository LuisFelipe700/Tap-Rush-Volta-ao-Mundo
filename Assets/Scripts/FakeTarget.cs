using UnityEngine;
using System.Collections;
using TMPro;

public class FakeTarget : MonoBehaviour
{
    private bool podeSerClicado = true;
    private GameManager gameManager;

    void Start()
    {
        // Pega a instância do GameManager
        gameManager = GameManager.Instance;
    }

    // Chamado quando o mouse clica no objeto
    void OnMouseDown()
    {
        if (podeSerClicado)
        {
            podeSerClicado = false;

            if (gameManager != null)
            {
                // Chama a função específica para o fim de jogo da bomba
                gameManager.TriggerBombGameOver();
            }

            // Destrói a bomba após ser clicada
            Destroy(gameObject);
        }
    }
}