using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLevel3_Spawner : MonoBehaviour
{
    public GameObject[] particles;    
    public Transform[] points;

    public float beat = 2 * (60 / 130);
    private float timer;


    // Update is called once per frame
    void Update()
    {
        //Hra beží až kým tri krát po sebe netrafíme časticu..
        

            if (timer > beat)
            {
                
                GameObject particle = Instantiate(particles[Random.Range(0, 2)], points[Random.Range(0, 4)]);               
                particle.transform.localPosition = Vector3.zero;               
                particle.transform.rotation = Quaternion.Euler(90 * Random.Range(0, 4), 0, 0);
            timer -= beat;                

            }
            timer += Time.deltaTime;      
       
    }
}
