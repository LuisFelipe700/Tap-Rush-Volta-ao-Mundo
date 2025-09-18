using UnityEngine;
using System.Collections;
using TMPro;

public class Target : MonoBehaviour
{
    private bool podeSerClicado = true;
    private GameManager gameManager;
    private float tempoDeReacao;
    private float tempoDeAparecimento;

    private void Start()
    {
        // Encontra a única instância do GameManager
        gameManager = GameManager.Instance;
        tempoDeAparecimento = Time.time;
    }

    private void OnMouseDown()
    {
        if (podeSerClicado)
        {
            podeSerClicado = false;
            tempoDeReacao = Time.time - tempoDeAparecimento;

            if (gameManager != null)
            {
                gameManager.AddScore(tempoDeReacao);
            }

            Destroy(gameObject);
        }
    }
}