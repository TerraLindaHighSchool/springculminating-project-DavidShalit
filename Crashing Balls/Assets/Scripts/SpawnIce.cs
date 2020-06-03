using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIce : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ice;
    void Start()
    {
        InvokeRepeating("spawnIce", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnIce()
    {
        GameObject iceClone = Instantiate(ice, transform.position, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        //iceClone.GetComponent<Rigidbody>().velocity = transform.up * Random.Range(30, 40);
        // iceClone.GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(30, 30);
        //iceClone.GetComponent<Rigidbody>().velocity = transform.right * Random.Range(30, 30);
        iceClone.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-30, 30), Random.Range(5, 10), Random.Range(-30, 30));
    }
}
