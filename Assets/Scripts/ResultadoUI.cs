using UnityEngine;
using TMPro;

public class ResultadoUI : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    public TextMeshProUGUI textoRecorde;

    void Start()
    {
        int pontuacaoFinal = GameManager.Instance.score;
        int recorde = PlayerPrefs.GetInt("Record", 0);

        textoPontuacao.text = "Pontuação Final: " + pontuacaoFinal;
        textoRecorde.text = "Recorde: " + recorde;
    }
}
