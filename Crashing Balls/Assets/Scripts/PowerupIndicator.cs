using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public float minScale = 1;
    public float maxScale = 2;
    public float rate = 0.01f;
    public float speed = 1;
    void Start()
    {
        
    }

    public void applyScale()
    {
        transform.localScale += Vector3.one * rate;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < minScale)
        {
            rate = Mathf.Abs(rate);
        }
        else if (transform.localScale.x > maxScale)
        {
            rate = -Mathf.Abs(rate);
        }
        applyScale();
        transform.Rotate(Vector3.up, speed);
    }
}
