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
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnPoint = GameObject.Find("Spawn Point");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(nextLevel);
        }
        if(other.gameObject.tag == "Void")
        {
            Death();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            Death();
        }
    }

    void Death()
    {
        playerController.playerRb.velocity = Vector3.zero;
        playerController.playerRb.isKinematic = true;
        playerController.playerRb.isKinematic = false;
        playerController.playerRb.rotation = Quaternion.Euler(0, 0, 0);
        gameManager.lives -= 1;
        transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 3, spawnPoint.transform.position.z);
    }
}
