using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 5.0f;
    public float rate = 5.0f;
    public GameObject Missile;
    void Start()
    {
        InvokeRepeating("Shoot", delay, rate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(Missile, transform.position, transform.rotation);
    }
}
