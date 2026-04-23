using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject enemyPrefab;

    private float spawnrange = 9f;
    public float startDelay = 1;
    public float repeatRate = 3;

    public int waveNumber = 1;

    public int enemyCount;
    public GameObject powerupPrefab;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private void Update()
    {

        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0) { waveNumber++; Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); SpawnEnemyWave(waveNumber); }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnrange, spawnrange);
        float spawnPosZ = Random.Range(-spawnrange, spawnrange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemyWave(int spawn)
    {
        for (int i = 0; i < spawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
