using UnityEngine;
using TMPro;
using System.Collections; // Adicione esta linha para usar Coroutines

public class ReniciaUI : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacaoFinal;
    public TextMeshProUGUI textoRecorde;

    private ReiniciarJogo reiniciarJogoScript;

    void Awake()
    {
        // Garante que o tempo volte ao normal
        Time.timeScale = 1f;
        // Pega a refer�ncia para o script ReiniciarJogo no mesmo GameObject
        reiniciarJogoScript = GetComponent<ReiniciarJogo>();
    }

    void Start()
    {
        // Pega a pontua��o e o recorde salvos
        int pontuacaoFinal = PlayerPrefs.GetInt("LastScore", 0);
        int recorde = PlayerPrefs.GetInt("Record", 0);

        // Exibe a pontua��o final
        if (textoPontuacaoFinal != null)
        {
            textoPontuacaoFinal.text = "Pontua��o Final: " + pontuacaoFinal;
        }

        // Exibe o recorde
        if (textoRecorde != null)
        {
            textoRecorde.text = "Recorde: " + recorde;
        }

        // Inicia a Coroutine para reiniciar o jogo automaticamente
        // O n�mero '5f' � o tempo de espera em segundos. Voc� pode mudar para o valor que quiser.
        StartCoroutine(ReiniciarAutomatico(5f));
    }

    // A Coroutine que espera e reinicia o jogo
    private IEnumerator ReiniciarAutomatico(float tempoDeEspera)
    {
        // Espera pelo tempo definido
        yield return new WaitForSeconds(tempoDeEspera);

        // Garante que o script ReiniciarJogo existe antes de chamar a fun��o
        if (reiniciarJogoScript != null)
        {
            reiniciarJogoScript.ReiniciarCompleto();
        }
    }
}