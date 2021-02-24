using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachCanvasesToPlayer3 : MonoBehaviour
{

    Canvas[] canvases;
    // Start is called before the first frame update
    void Start()
    {
        canvases = FindObjectsOfType<Canvas>();
        GameObject player = GameObject.Find("Player");
        Camera prPointer = player.GetComponentInChildren<Camera>();
        
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].worldCamera = prPointer;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
