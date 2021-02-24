using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachCanvasesToPlayer : MonoBehaviour
{
    //Script na prepojenie canvasov z noveho levelu k hracovi
    Canvas[] canvases;
    // Start is called before the first frame update
    void Start()
    {
        canvases = FindObjectsOfType<Canvas>();
        GameObject player = GameObject.Find("Player");
        Camera prPointer = player.GetComponentInChildren<Camera>();
        Debug.Log("player : " + player.name);
        Debug.Log("camera : " + prPointer.name);
        Debug.Log("canvasy : "+ canvases.Length);
        
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].worldCamera = prPointer;
        }

        player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        player.transform.position = new Vector3(1.4f,0,3.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
