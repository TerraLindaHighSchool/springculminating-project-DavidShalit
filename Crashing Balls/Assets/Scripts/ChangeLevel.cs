using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextLevel;
    public string thisLevel;
    public GameManager gameManager;
    public GameObject spawnPoint;
    public PlayerController playerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(nextLevel);
        }
        if(other.gameObject.tag == "Void")
        {
            gameManager.lives -= 1;
            transform.position = spawnPoint.transform.position;
            playerController.playerRb.velocity = Vector3.zero;
        }
    }
}
