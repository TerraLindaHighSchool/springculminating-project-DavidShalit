using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    private float spawnRange = 5.0f;
    public int levelNumber = 1;
    private GameObject player;
    public int lives = 5;
    private bool gameActive = true;
    private Text livesText;
    public GameObject gameOver;
    public GameObject pause;
    void Start()
    {
        InvokeRepeating("SpawnEnemyWave", 5.0f, 10.0f);
        //DontDestroyOnLoad(this.gameObject);
        livesText = GameObject.Find("Lives").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        if (lives < 1)
        {
            gameActive = false;
            CancelInvoke();
            gameOver.gameObject.SetActive(true);
        }
        livesText.text = "Lives: " + lives;
        if (Input.GetKeyDown(KeyCode.Escape) && lives > 0)
        {
            if (!gameActive)
            {
                gameActive = true;
                pause.gameObject.SetActive(false);
            }
            else
            {
                gameActive = false;
                pause.gameObject.SetActive(true);
            }
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(player.transform.position.x - spawnRange, player.transform.position.x + spawnRange);
        float spawnPosZ = Random.Range(player.transform.position.z - spawnRange, player.transform.position.z + spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX + 1, player.transform.position.y + 1, spawnPosZ + 1);
        return randomPos;
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < levelNumber; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    public bool getActive()
    {
        return gameActive;
    }
}
