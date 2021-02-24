using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBalls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;

    // Update is called once per frame
    public void Cube()
    {
        Instantiate(ballPrefab);
    }
}
