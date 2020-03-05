using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    private float spawnRange = 5.0f;
    public int levelNumber = 1;
    public GameObject player;
    void Start()
    {
        InvokeRepeating("SpawnEnemyWave", 5.0f, 10.0f);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(player.transform.position.x - spawnRange, player.transform.position.x + spawnRange);
        float spawnPosZ = Random.Range(player.transform.position.z - spawnRange, player.transform.position.z + spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < levelNumber; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
