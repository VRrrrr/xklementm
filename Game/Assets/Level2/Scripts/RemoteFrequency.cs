using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoteFrequency : MonoBehaviour
{
    public Material connected;
    public Material disconnected;
    public GameObject sphereControl;
    public float frequency;
    public bool isConnected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (frequency < 2300 || frequency > 2500)
        {
            sphereControl.GetComponent<Renderer>().material = disconnected;
            isConnected = false;
            gameObject.GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            sphereControl.GetComponent<Renderer>().material = connected;
            isConnected = true;
            gameObject.GetComponentInChildren<Button>().interactable = true;
        }
    }
}
