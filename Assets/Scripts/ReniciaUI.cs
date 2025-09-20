using UnityEngine;
using TMPro;
using System.Collections;

public class ReniciaUI : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacaoFinal;
    public TextMeshProUGUI textoRecorde;

    private ReiniciarJogo reiniciarJogoScript;

    void Awake()
    {
        Time.timeScale = 1f; // garante que não fica pausado
        reiniciarJogoScript = GetComponent<ReiniciarJogo>();
    }

    void Start()
    {
        int pontuacaoFinal = PlayerPrefs.GetInt("LastScore", 0);
        int recorde = PlayerPrefs.GetInt("Record", 0);

        if (textoPontuacaoFinal != null)
        {
            textoPontuacaoFinal.text = "Pontuação Final: " + pontuacaoFinal;
        }

        if (textoRecorde != null)
        {
            textoRecorde.text = "Recorde: " + recorde;
        }

        StartCoroutine(ReiniciarAutomatico(5f));
    }

    private IEnumerator ReiniciarAutomatico(float tempoDeEspera)
    {
        yield return new WaitForSeconds(tempoDeEspera);

        if (reiniciarJogoScript != null)
        {
            reiniciarJogoScript.ReiniciarCompleto();
        }
        else
        {
            // fallback
            UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
