﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMoving;
    void Start()
    {
        InvokeRepeating("Movement", 0, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(0, 0, -0.1f));
        }
    }
     IEnumerator MoveCycle()
    {
        isMoving = true;
        yield return new WaitForSeconds(15);
        isMoving = false;
    }

    void Movement()
    {
        StartCoroutine(MoveCycle());
        
        transform.Rotate(Vector3.up * 180);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
