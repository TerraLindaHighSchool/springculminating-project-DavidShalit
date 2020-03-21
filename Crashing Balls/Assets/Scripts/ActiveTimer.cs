using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float interval = 5;
    public ParticleSystem flame;
    void Start()
    {
        flame = gameObject.GetComponent<ParticleSystem>();
        InvokeRepeating("BruhMethodMoment", 0, interval * 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BruhMethodMoment() //random name, its the method to call the IEnumerator
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        flame.Play();
        yield return new WaitForSeconds(interval);
        flame.Stop(false, ParticleSystemStopBehavior.StopEmitting);
    }
}
