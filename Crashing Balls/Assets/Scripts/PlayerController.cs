using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    public float powerupStrength = 2.0f;
    public GameObject powerupIndicator;
    private float brake = 1;
    public bool onIce = false;
    public GameObject destination;
    private GameManager gameManager;
    private Vector3 currentVelocity;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        if (gameManager.getActive())
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !onIce)
            {
                brake = 0.2f;
                playerRb.velocity = Vector3.one * brake;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                brake = 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerRb.velocity *= 2;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) && !onIce)
            {
                playerRb.velocity /= 2;
            }
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed * brake);
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
        else
        {
            playerRb.velocity = Vector3.zero;
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
        if (other.CompareTag("Teleport1"))
        {
            transform.position = destination.transform.position;
        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wind") && gameManager.getActive())
        {
            transform.Translate(new Vector3(4, 0, 0) * Time.deltaTime, Space.World);
        }
        if (other.CompareTag("Wind2") && gameManager.getActive())
        {
            playerRb.AddForce(gameManager.transform.up * 0.3f, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(15);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            //Debug.Log("Collided with " + collision.gameObject.name + " with Powerup set to " + hasPowerup);
        }
        if (collision.gameObject.CompareTag("Enemy") && !hasPowerup && Input.GetKey(KeyCode.LeftControl))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * 1.3f, ForceMode.Impulse);
            //Debug.Log("Collided with " + collision.gameObject.name + " while speeding up");
        }
        if (collision.gameObject.tag == "Ice")
        {
            onIce = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            onIce = false;
        }
    }
}
