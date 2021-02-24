using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSpawner : MonoBehaviour
{
    public GameObject[] particles;  
    public Transform[] points;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitLevel()
    {
        //red
        GameObject exitlvl = Instantiate(particles[0], points[0]);
        exitlvl.name = "Exit";
        //blue
        GameObject restartlvl = Instantiate(particles[1], points[1]);
        restartlvl.name = "Restart";
    }
    
}
