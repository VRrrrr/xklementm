using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{

    public Transform leftDoor;
    public Transform rightDoor;

    bool opening;
    // Start is called before the first frame update
    void Start()
    {
        opening = false;
    }

    public void Open() { opening = true; }
        
    

    // Update is called once per frame
    void Update()
    {
        if (opening) { 
        leftDoor.localPosition += Time.deltaTime * transform.forward * 1f;
        rightDoor.localPosition += Time.deltaTime * -1*transform.forward * 1f;
        
            if (leftDoor.localPosition.z > 6 || rightDoor.localPosition.z < 0) {
                opening = false;
            }
        }
    }
}
