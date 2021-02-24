using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float particleSpeed;

    public GameObject spawner;
    private Spawner spawnerParams;

    // Start is called before the first frame update
    void Start()
    {
        spawnerParams = spawner.GetComponent<Spawner>();
        particleSpeed = spawnerParams.particleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * particleSpeed;     
    
    }


}
