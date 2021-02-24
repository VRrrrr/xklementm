using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject toFollow;
    public GameObject northPole;
    public bool on;

    private void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        Transform v;
        if (!on)
            v = northPole.transform;
        else
            v = toFollow.transform;

        Vector3 relativePos = v.position - transform.position;

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        //arrow always looks forward so it will show correctly to viewer, and world-up changes the rotation
        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = LookAtRotationOnly_Y;
    }
}
