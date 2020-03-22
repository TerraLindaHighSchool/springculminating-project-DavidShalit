using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    public float lifetime = 1.5f;
    void Start()
    {
        StartCoroutine(Expire());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Explode();
        }
        
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(lifetime);
        Explode();
    }
}
