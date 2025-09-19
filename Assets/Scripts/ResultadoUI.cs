using UnityEngine;
using TMPro;

public class ResultadoUI : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    public TextMeshProUGUI textoRecorde;

    void Start()
    {
        // Certifica que o GameManager existe antes de tentar acessar o score
        if (GameManager.Instance != null)
        {
            int pontuacaoFinal = GameManager.Instance.score;
            int recorde = PlayerPrefs.GetInt("Record", 0);

            if (textoPontuacao != null)
            {
                textoPontuacao.text = "Pontua��o Final: " + pontuacaoFinal;
            }

            if (textoRecorde != null)
            {
                textoRecorde.text = "Recorde: " + recorde;
            }
        }
        else
        {
            // Este c�digo � �til para testar a cena de resultado sem o GameManager
            if (textoPontuacao != null)
            {
                textoPontuacao.text = "Pontua��o Final: 0";
            }

            if (textoRecorde != null)
            {
                textoRecorde.text = "Recorde: 0";
            }
        }
    }
}