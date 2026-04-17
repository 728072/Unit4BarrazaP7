using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject enemyPrefab;

    private float spawnrange = 9f;
    public float startDelay = 1;
    public float repeatRate = 3;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnrange, spawnrange);
        float spawnPosZ = Random.Range(-spawnrange, spawnrange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
}
