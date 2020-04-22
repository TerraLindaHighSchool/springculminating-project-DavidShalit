using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private SpawnManagerX spawnManager;
    GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Void")
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wind"))
        {
            transform.Translate(new Vector3(5, 0, 0) * Time.deltaTime, Space.World); ;
        }
    }
}
