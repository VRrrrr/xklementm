using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLevel3_Particle : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        
        transform.localPosition += Time.deltaTime * -transform.right * speed;     
    }
}
