using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLevel3_Wall : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {        
        Destroy(collision.gameObject);
    }
}
