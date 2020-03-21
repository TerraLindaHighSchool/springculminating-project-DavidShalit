using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ableToMove = true;
    public GameObject parent;
    void Start()
    {
        parent = GameObject.Find("Fire Breather");
        InvokeRepeating("CycleCall", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
        }
    }

    void CycleCall()
    {
        StartCoroutine(Cycle());
    }

    IEnumerator Cycle()
    {
        yield return new WaitForSeconds(2.5f);
        ableToMove = false;
        yield return new WaitForSeconds(2.5f);
        ableToMove = true;
        yield return new WaitForSeconds(5);
        transform.position = new Vector3(transform.position.x, transform.position.y, parent.transform.position.z + 12);
    }
}
