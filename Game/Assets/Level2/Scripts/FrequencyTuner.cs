using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
using System.Collections;

public class FrequencyTuner : MonoBehaviour
{
    // Start is called before the first frame update
    public Text toDisplay;
    public GameObject remote;

    CircularDrive script;
    RemoteFrequency remoteFrequency;
    float frequency;

    void Start()
    {
        script = gameObject.GetComponentInChildren<CircularDrive>();
        remoteFrequency = remote.GetComponent<RemoteFrequency>();
    }

    // Update is called once per frame
    void Update()
    {
        //Frekvencia v rozmedzi 1000 a 3000 hz
        frequency = 1000f + script.linearMapping.value * 2000f;
        
        toDisplay.text = frequency.ToString() + "Hz";
        remoteFrequency.frequency = frequency;

        
    }
}
