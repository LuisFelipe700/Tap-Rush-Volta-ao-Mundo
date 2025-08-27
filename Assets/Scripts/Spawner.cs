using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float intervaloBase = 1f;
    public float intervaloMinimo = 0.3f;

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

            _ = Instantiate(targetPrefab, topoDaTela, Quaternion.identity);

            int score = GameManager.Instance.score;
            float intervaloAtual = Mathf.Max(intervaloBase - (score * 0.02f), intervaloMinimo);

            yield return new WaitForSeconds(intervaloAtual);
        }
    }
}
