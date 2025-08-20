using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject fakeTargetPrefab;
    public float spawnInterval = 1f;
    private float timer;
    private float gameTime;

    void Update()
    {
        gameTime += Time.deltaTime;
        timer += Time.deltaTime;

        AdjustDifficulty();

        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0;
        }
    }

    void AdjustDifficulty()
    {
        if (gameTime > 40) spawnInterval = 0.3f;
        else if (gameTime > 20) spawnInterval = 0.6f;
        else spawnInterval = 1f;
    }

    void SpawnTarget()
    {
        Vector2 position = new Vector2(Random.Range(-2f, 2f), Random.Range(-4f, 4f));
        GameObject prefab = ShouldSpawnFake() ? fakeTargetPrefab : targetPrefab;
        Instantiate(prefab, position, Quaternion.identity);
    }

    bool ShouldSpawnFake()
    {
        if (gameTime < 20) return false;
        float chance = gameTime > 40 ? 0.3f : 0.1f;
        return Random.value < chance;
    }
}
