using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoconuts : MonoBehaviour
{
    // Start is called before the first frame update
    private float spawnRange = 12.0f;
    public GameObject coconut;
    void Start()
    {
        InvokeRepeating("SpawnCoconut", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange);
        float spawnPosZ = Random.Range(transform.position.z - spawnRange, transform.position.z + spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX + 1, transform.position.y + 1, spawnPosZ + 1);
        return randomPos;
    }

    private void SpawnCoconut()
    {
        Instantiate(coconut, GenerateSpawnPos(), coconut.transform.rotation);
    }
}
