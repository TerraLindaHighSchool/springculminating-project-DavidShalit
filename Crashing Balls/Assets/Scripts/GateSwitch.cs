using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gate;
    public Material inactive;
    private MeshRenderer mesh;
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gate.SetActive(false);
            mesh.material = inactive;
        }
    }
}
