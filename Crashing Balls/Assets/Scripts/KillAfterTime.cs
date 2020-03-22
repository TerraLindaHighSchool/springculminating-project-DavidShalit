using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 5.0f;
    void Start()
    {
        StartCoroutine(Kill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
