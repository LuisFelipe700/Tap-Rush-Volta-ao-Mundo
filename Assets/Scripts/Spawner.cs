using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject bombPrefab;
    public float intervaloBase = 1f;
    public float intervaloMinimo = 0.3f;
    public float dificuldadeMultiplicador = 0.05f;

    public float chanceBaseBomba = 0.1f;
    public float aumentoChanceBombaPorFase = 0.02f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (GameManager.Instance == null || GameManager.Instance.timeLeft <= 0)
                yield break;

            Vector3 topoDaTela = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 1f, 0f));
            topoDaTela.z = 0f;

            int dificuldade = GameManager.Instance.score / 20;
            float chanceAtual = chanceBaseBomba + (dificuldade * aumentoChanceBombaPorFase);

            if (Random.value < chanceAtual)
            {
                if (bombPrefab != null)
                {
                    Instantiate(bombPrefab, topoDaTela, Quaternion.identity);
                }
            }
            else
            {
                if (targetPrefab != null)
                {
                    Instantiate(targetPrefab, topoDaTela, Quaternion.identity);
                }
            }

            float intervaloAtual = Mathf.Max(intervaloBase - (dificuldade * dificuldadeMultiplicador), intervaloMinimo);

            yield return new WaitForSeconds(intervaloAtual);
        }
    }
}